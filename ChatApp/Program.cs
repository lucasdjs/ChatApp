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
            // Cria a inst�ncia do servidor
            server = new Server();

            // Inicia o servidor em uma nova thread
            Thread serverThread = new Thread(server.Start);
            serverThread.IsBackground = true; // Permite que o programa termine mesmo que a thread do servidor esteja em execu��o
            serverThread.Start();

            // Inicia a aplica��o Windows Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InitialMenu(server));
        }
    }
}
