using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using MySql.Data.MySqlClient;

namespace ParolkaServer
{
    class Program
    {
        public static void Main()
        {
            CheckConfig();

            Thread Broadcast = new Thread(ParolkaServer.Broadcast.ReceiveBroadcast);
            Broadcast.Start();

            ActiveServer();
        }
        static void CheckConfig()
        {
            try
            {
                connectData.ipHost = File.ReadAllText("server.ip");
            }
            catch
            {
                Console.WriteLine("Config file not found. Trying to generate...");
                SetupIP();
            }
            try
            {
                string[] data = File.ReadAllLines("db.ip");

                MysqlConnectData.Datasource = data[0];
                MysqlConnectData.Database = data[1];
                MysqlConnectData.Username = data[2];
                MysqlConnectData.Password = data[3];

                MysqlConnectData.Constring = "datasource=" + MysqlConnectData.Datasource + ";" + "Database=" + MysqlConnectData.Database + ";" + "port=" + MysqlConnectData.Port + ";" + "username=" + MysqlConnectData.Username + ";" + "password=" + MysqlConnectData.Password + ";" + "charset=" + MysqlConnectData.Charset;
            }
            catch
            {
                Console.WriteLine("SQL Config file not found. Trying to generate...");
                SetupSQL();
            }

            using (MySqlConnection conDataBase = new MySqlConnection(ParolkaServer.MysqlConnectData.Constring))
            {
                try
                {
                    conDataBase.Open();
                    conDataBase.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySQL Connection: Error occured. " + ex.Message + "\nTryng to rewrite config...");

                    try
                    {
                        File.Delete("db.ip");
                        SetupSQL();
                    }
                    catch (Exception bug)
                    {
                        Console.WriteLine("\nConfig correction bug. Check permissions, and send screenshot to developer, please. \n" + bug.Message);
                    }
                }
            }
        }
        static void SetupIP()
        {
            String strHostName = Dns.GetHostName();
            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);

            int i = 1;

            List<string> IPs = new List<string>();

            Console.WriteLine("\nYour Server IPs here: \n");

            foreach (IPAddress ip in iphostentry.AddressList)
            {
                IPs.Add(ip.ToString());

                Console.WriteLine(i.ToString() + ". " + ip);
                i++;
            }
            Console.WriteLine("\nWhich IP-address server must use? \n");
            try
            {
                ConsoleKeyInfo h = Console.ReadKey(true);
                int x = Int32.Parse(h.KeyChar.ToString());

                x = x - 1; // bicycle ((

                connectData.ipHost = IPs[x];

                Console.WriteLine("\nSave? [Y/N]\n");

                ConsoleKeyInfo save;
                save = Console.ReadKey(true);

                if (save.Key == ConsoleKey.Y)
                {
                    File.WriteAllText("server.ip", IPs[x]);
                    Console.WriteLine("\nSaved, launch...");
                }
                if (save.Key == ConsoleKey.N)
                {
                    Console.WriteLine("\nOkay, only launch on " + IPs[x] + "...  \n\n");
                }
                if (save.Key != ConsoleKey.N && save.Key != ConsoleKey.Y)
                {
                    Console.WriteLine("\nBad key pressed, try again!");
                    SetupIP();
                }
            }
            catch
            {
                Console.WriteLine("\n\nBad IP selected, try again! \n");
                SetupIP();
            }
            CheckConfig();
        }
        static void SetupSQL()
        {
            List<string> SQLData = new List<string>();

            try
            {
                Console.WriteLine("\nEnter MySQL host IP/Domain: \n");
                string sqlhost = Console.ReadLine();
                SQLData.Add(sqlhost);
                MysqlConnectData.Datasource = sqlhost;

                Console.WriteLine("\nEnter MySQL Database Name: \n");
                string sqldb = Console.ReadLine();
                SQLData.Add(sqldb);
                MysqlConnectData.Database = sqldb;

                Console.WriteLine("\nEnter MySQL Username: \n");
                string sqluser = Console.ReadLine();
                SQLData.Add(sqluser);
                MysqlConnectData.Username = sqluser;

                Console.WriteLine("\nEnter MySQL Password: \n");
                string sqlpassword = Console.ReadLine();
                SQLData.Add(sqlpassword);
                MysqlConnectData.Password = sqlpassword;

                File.WriteAllLines("db.ip", SQLData);

                CheckConfig();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAutoconfig bug. Check permissions, and send screenshot to developer, please. \n" + ex.Message);
            }
        } 
        public static void ActiveServer()
        {
            var ipAddr = IPAddress.Parse(connectData.ipHost);
            connectData.ipEndPoint = new IPEndPoint(ipAddr, connectData.port);

            connectData.sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                connectData.sListener.Bind(connectData.ipEndPoint);
                connectData.sListener.Listen(10);

                Thread Connect = new Thread(ServWorker.SocketConnect);
                Connect.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
    static class connectData
    {
        public static Socket sListener;
        public static IPEndPoint ipEndPoint;
        
        public static string ipHost = "127.0.0.1";
        public static int port = 10000;
    }
}