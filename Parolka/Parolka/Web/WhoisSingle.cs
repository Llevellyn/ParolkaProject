using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Parolka.Web
{
    static class WhoisSingle
    {
        public static void WhoisReq()
        {
            TcpClient WhoisServ = new TcpClient("whois.ripn.net", 43);
            BufferedStream BufferedStreamWhoisServ = new BufferedStream(WhoisServ.GetStream());
            StreamWriter swSend = new StreamWriter(BufferedStreamWhoisServ);
            swSend.WriteLine(Parolka.MainFormSites.SelectedSite);
            swSend.Flush();

            StreamReader srReceive = new StreamReader(BufferedStreamWhoisServ);

            string DomainInfo = String.Empty;

            try
            {
                while (!srReceive.EndOfStream)
                    DomainInfo += srReceive.ReadLine() +
                        Environment.NewLine;
            }
            catch (IOException)
            {

            }
            finally
            {
                WhoisServ.Close();
            }

            Parolka.Whois.WhoisSingle = DomainInfo;
        }
    }
}
