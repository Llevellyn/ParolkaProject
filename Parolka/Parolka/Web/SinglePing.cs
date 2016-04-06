using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Parolka.Web
{
    static class SinglePing
    {
        public static void SinglePingReq()
        {
            try
            {
                Thread.Sleep(100);
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply pingReply = ping.Send(Parolka.MainFormSites.SelectedSite);
                Parolka.Ping.PingSingle = pingReply.Status.ToString() + " " + pingReply.RoundtripTime.ToString() + " ms, IP " + pingReply.Address.ToString();
            }
            catch
            {
                Parolka.Ping.PingSingle = "Сайт недоступен!";
            }
        }
    }
}
