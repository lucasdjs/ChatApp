using ChatApp.Entities;
using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class ChatForm : Form
    {
        private Server server;
        private Client client;
        private string username;

        public ChatForm(Server server, Client client, string username)
        {
            InitializeComponent();
            this.server = server;
            this.client = client;
            this.username = username;

            // Inscreva-se no evento MessageReceived do servidor para exibir as mensagens recebidas
            server.MessageReceived += Server_MessageReceived;
            server.UserListUpdated += Server_UserListUpdated;

            // Inicialize a lista de usu�rios conectados
            UpdateConnectedUsers();
        }

        // M�todo para atualizar a lista de usu�rios conectados na richTextBox2
        private void UpdateConnectedUsers()
        {
            richTextBox2.Clear();
            var connectedUsers = server.GetConnectedUsers();

            foreach (var user in connectedUsers)
            {
                richTextBox2.AppendText(user + Environment.NewLine);
            }
        }

        // Manipulador de eventos para exibir as mensagens recebidas
        private void Server_MessageReceived(object sender, string message)
        {
            // Verifica se � necess�rio invocar a atualiza��o da UI
            if (richTextBox1.InvokeRequired)
            {
                // Se sim, invoca a verifica��o na thread de UI
                richTextBox1.BeginInvoke(new Action(() =>
                {
                    if (!richTextBox1.Text.Contains(message))
                    {
                        richTextBox1.AppendText(message + Environment.NewLine);
                    }
                }));
            }
            else
            {
                // Se n�o, verifica diretamente na thread de UI
                if (!richTextBox1.Text.Contains(message))
                {
                    richTextBox1.AppendText(message + Environment.NewLine);
                }
            }
        }


        // Manipulador de eventos para o clique no bot�o "Enviar"
        private void EnviarMessage_Click(object sender, EventArgs e)
        {
            // Obtenha o texto digitado na caixa de texto EnvioMessage
            string message = EnvioMessage.Text;

            // Adicione o nome do usu�rio ao texto da mensagem
            string formattedMessage = $"{username}: {message}";

            // Adicione a mensagem � richTextBox1
            richTextBox1.AppendText(formattedMessage + Environment.NewLine);

            // Envie a mensagem para o servidor
            client.SendMessage(formattedMessage);

            // Limpe a caixa de texto EnvioMessage
            EnvioMessage.Clear();
        }

        // Manipulador de eventos para altera��es no texto da caixa de texto EnvioMessage
        private void EnvioMessage_TextChanged(object sender, EventArgs e)
        {
            // Este evento � acionado sempre que o texto da caixa de texto EnvioMessage � alterado
            // Voc� pode adicionar qualquer l�gica adicional aqui, se necess�rio
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Este evento � acionado sempre que o texto da RichTextBox richTextBox1 � alterado
            // Voc� pode adicionar qualquer l�gica adicional aqui, se necess�rio
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            // Este evento � acionado sempre que o texto da RichTextBox richTextBox1 � alterado
            // Voc� pode adicionar qualquer l�gica adicional aqui, se necess�rio
        }
        private void Server_UserListUpdated(object sender, EventArgs e)
        {
            // Atualizar a lista de usu�rios conectados
            UpdateConnectedUsers();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            server.RemoveUser(username);
            this.Close();
        }

        private void Arquivo_Click(object sender, EventArgs e)
        {
            // Crie uma janela de di�logo para permitir que o usu�rio selecione o local de salvamento do arquivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Salvar Arquivo";
            saveFileDialog.Filter = "Todos os arquivos (*.*)|*.*"; // Filtro para todos os tipos de arquivos

            // Exiba a janela de di�logo
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obt�m o caminho do arquivo selecionado pelo usu�rio
                string filePath = saveFileDialog.FileName;

                // Salva o arquivo no disco
                SaveFile(filePath, client.tcpClient);
            }
        }

        private void SaveFile(string filePath, TcpClient tcpClient)
        {
            // Crie um FileStream para escrever o arquivo no disco
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                // Receba os dados do arquivo do servidor e escreva no FileStream
                NetworkStream networkStream = tcpClient.GetStream();
            }

            // Exiba uma mensagem ao usu�rio informando que o arquivo foi salvo com sucesso
            MessageBox.Show("Arquivo salvo com sucesso em: " + filePath, "Salvar Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
