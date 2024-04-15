using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using log4net;

namespace ChatApp.Entities
{
    public class Client
    {
        public TcpClient tcpClient;
        private Thread receiveThread;
        public string Name;
        private Dictionary<TcpClient, string> clientUsernames = new Dictionary<TcpClient, string>();
        public event EventHandler<string> PrivateMessageReceived;

        private void SetUsername(TcpClient client, string username)
        {
            clientUsernames[client] = username;
        }

        public string GetUsername(TcpClient client)
        {
            if (clientUsernames.ContainsKey(client))
            {
                return clientUsernames[client];
            }
            return null;
        }

        public event EventHandler<string> MessageReceived;

        public void Connect(string serverIP, int port, string nameUser)
        {
            tcpClient = new TcpClient();
            SetUsername(tcpClient, nameUser);
            tcpClient.Connect(serverIP, port);
            receiveThread = new Thread(ReceiveMessages);
            receiveThread.Start();
        }

        public void SendMessage(string message)
        {
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private void ReceiveMessages()
        {
            NetworkStream clientStream = tcpClient.GetStream();
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
                OnMessageReceived(data);
            }

            tcpClient.Close();
        }

        private void ReceivePrivateMessage(string message)
        {
            PrivateMessageReceived?.Invoke(this, message);
        }

        public void SendPrivateMessage(string recipient, string message)
        {
            // Construa a mensagem formatada com o nome do remetente e do destinatário
            string formattedMessage = $"@{recipient}: {message}";

            // Envie a mensagem para o servidor
            SendMessage(formattedMessage);
        }

        private void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, message);
        }

        public void Disconnect()
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                tcpClient.Close();
            }
        }
    }
}
