using log4net;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Entities
{
    public class Log
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Log));

        public void Info(string nomeRemetente, string ipsDestinatario, string nomesDestinatario, string acao)
        {
            IPAddress[] localIPs = Dns.GetHostAddresses("localhost");
            string meuIp ="";

            foreach (IPAddress ipAddress in localIPs)
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    meuIp = ipAddress.ToString();
                    break;
                }
            }
            string dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string ipsDestinatariosString = string.Join("-", ipsDestinatario);
            string nomesDestinatariosString = string.Join("-", nomesDestinatario);
            string logMessage = $"{dataHora}; {meuIp}; {nomeRemetente}; {ipsDestinatariosString}; {nomesDestinatariosString}; {acao}";
            log.Info(logMessage);
        }
    }
}
