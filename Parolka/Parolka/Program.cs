using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Parolka
{
    internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login());

            //ServerTest();
        }
        static void ServerTest()
        {
            try
            {
                Config.serverIP = File.ReadAllText("server.ip");
                ServerTestConnect();
            }
            catch
            {
                Server.Broadcast.SendBroadcast();
                File.WriteAllText("server.ip", Config.serverIP);
                Config.serverIP = File.ReadAllText("server.ip");
                ServerTestConnect();
            }
        }
        static void ServerTestConnect()
        {
            try
            {
                ServerData.DataMessage = "QUERY_PING";

                Server.Server.ParolkaClient();

                if (ServerData.ServMessage == "REPLY_PONG")
                {
                    Application.Run(new Login());
                }
                else
                {
                    File.Delete("server.ip");
                    ServerTest();
                }
            }
            catch
            {
                File.Delete("server.ip");
                ServerTest();
            }
        }
    }
    static class ServerData
    {
        public static string SessionHash;

        public static string DataMessage;
        public static string ServMessage;
        public static string ServMessageData;

        public static string SitesCount;

        public static string UserName;
        public static string UserPass;
        public static string UserRole;
    }
    static class Whois
    {
        public static string WhoisSingle;
    }
    static class Ping
    {
        public static string PingSingle;
    }
    static class MainFormSites
    {
        public static string CMSHost;
        public static string CMSUser;
        public static string CMSPassword;
        public static string CMSAdd;
        public static string HostingHost;
        public static string HostingUser;
        public static string HostingPassword;
        public static string HostingAdd;
        public static string DBHost;
        public static string DBUser;
        public static string DBPassword;
        public static string DBBase;
        public static string FTPHost;
        public static string FTPUser;
        public static string FTPPassword;
        public static string FTPPort;
        public static string Comments;

        public static string AddedSite;

        public static string SelectedSite;

        public static string BrowserNavigate;

        public static string[] BackColor = { "Brown", "CornflowerBlue", "Crimson", "DarkBlue", "DarkCyan", "Purple", "MidnightBlue", "ForestGreen", "DarkViolet", "DarkOrchid", "DarkOliveGreen", "DarkGray" };

        public static string GrantVar;
        public static List<string> SitesCollection = new List<string>();
    }
    static class Config
    {
        public static string ver = "Parolka " + Application.ProductVersion.ToString(); 
        public static string serverIP;
        public static string principalObj = "sa";
        public static string ServerType;
    }
}
