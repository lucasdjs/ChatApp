using ChatApp.Entities;
using System;
using System.Net;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class InitialMenu : Form
    {
        private Server server;
        private Log logs = new Log();

        public InitialMenu(Server server)
        {
            InitializeComponent();
            this.server = server; // Inicialize o objeto server com o parâmetro passado para o construtor
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nameClient = NameTextBox.Text;
            if(nameClient != null && nameClient != string.Empty)
            {
                Client client = new Client();
                client.Name = nameClient;
                client.Connect("127.0.0.1", 10000, client.Name);

                logs.Info(nameClient, "127.0.0.1", "", $"Logando com o usuário {nameClient}");

                if (server != null) // Verifique se o objeto server foi inicializado antes de usá-lo
                {
                    server.AddUser(nameClient);
                }

                ChatForm chatForm = new ChatForm(server,client, client.Name);
                chatForm.Text = $"Sockets TCP - {client.Name}";         
                MessageBox.Show($"Usuário {nameClient} conectado.");
                logs.Info(nameClient, "127.0.0.1", "", $"Usuário {nameClient} logado.");
                chatForm.Show();

                NameTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Por favor insira seu nome para conectar ao chat.");
            }
           
        }
    }
}
