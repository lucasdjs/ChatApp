using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using log4net;

namespace ChatApp.Entities
{
    public class Server
    {
        private TcpListener listener;
        private List<TcpClient> clients = new List<TcpClient>();
        private List<string> connectedUsers = new List<string>();
        private Thread listenThread;
        public event EventHandler UserListUpdated;
        public event EventHandler<string> MessageReceived;
        private Dictionary<TcpClient, string> clientUsernames = new Dictionary<TcpClient, string>();
        private Log logs = new Log();

        public Server()
        {
            listener = new TcpListener(IPAddress.Any, 10000);
            listenThread = new Thread(new ThreadStart(ListenForClients));
        }

        private void SetUsername(TcpClient client, string username)
        {
            clientUsernames[client] = username;
        }

        private List<string> GetUsername(TcpClient client)
        {
            return clientUsernames.Values.ToList();
        }

        public void Start()
        {
            listenThread.Start();
        }

        private void ListenForClients()
        {
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                clients.Add(client);
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            string username = "";

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                string data = Encoding.ASCII.GetString(message, 0, bytesRead);
                var text = data.Split(':');
                var sender = text[0];
                var newText = text[1];

                if (string.IsNullOrEmpty(username))
                {
                    username = sender;
                    SetUsername(tcpClient, username);
                }

                if (newText.StartsWith(" @"))
                {
                    string[] partes = newText.Split(' ');
                    if (partes[1].StartsWith('@') && partes[1].Length > 1)
                    {
                        var recipient = partes[1].Split('@')[1];
                        var messageText = string.Join(" ", partes, 2, partes.Length - 2);

                        SendPrivateMessage(sender, recipient, messageText);
                    }
                }

                OnMessageReceived(data);
            }

            connectedUsers.Remove(username);
            OnUserListUpdated();

            tcpClient.Close();
        }


        private void SendPrivateMessage(string senderName, string recipient, string message)
        {
            foreach (var client in clients)
            {
                var usernames = GetUsername(client);
                if (usernames.Contains(recipient))
                {

                    NetworkStream clientStream = client.GetStream();
                    byte[] buffer = Encoding.ASCII.GetBytes($"{senderName} (privado para {recipient}): {message}");
                    clientStream.Write(buffer, 0, buffer.Length);
                    clientStream.Flush();
                    break;
                }
            }
        }


        private void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, message);
        }

        public void Broadcast(string message)
        {
            foreach (TcpClient client in clients)
            {
                NetworkStream clientStream = client.GetStream();
                byte[] buffer = Encoding.ASCII.GetBytes(message);
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
        }

        public void AddUser(string username)
        {
            connectedUsers.Add(username);
            OnUserListUpdated();
        }

        public List<string> GetConnectedUsers()
        {
            return connectedUsers;
        }

        public void RemoveUser(string userName)
        {
            connectedUsers.Remove(userName);
            OnUserListUpdated();
        }

        private void OnUserListUpdated()
        {
            UserListUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
