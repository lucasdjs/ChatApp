using System;
using System.Windows.Forms;
using ChatApp.Entities;

namespace ChatApp
{
    internal static class Program
    {
        private static Server server;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Cria a instância do servidor
            server = new Server();

            // Inicia o servidor em uma nova thread
            Thread serverThread = new Thread(server.Start);
            serverThread.IsBackground = true; // Permite que o programa termine mesmo que a thread do servidor esteja em execução
            serverThread.Start();

            // Inicia a aplicação Windows Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InitialMenu(server));
        }
    }
}
