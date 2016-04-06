using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Specialized;

namespace Parolka.Server
{
    static class Server
    {
        public static void ParolkaClient()
        {
            try
            {
                if (Config.ServerType == "http")
                {
                    SendMessageFromHTTP(ServerData.DataMessage.ToString());
                }
                if (Config.ServerType == "socket")
                {
                    SendMessageFromSocket(10000, ServerData.DataMessage.ToString(), Config.serverIP);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }

        public static void SendMessageFromSocket(int port, string message, string addr)
        {
            byte[] bytes = new byte[1024];
            var serverIP = IPAddress.Parse(addr);
            IPEndPoint ipEndPoint = new IPEndPoint(serverIP, port);
            Socket sender = new Socket(serverIP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            sender.Connect(ipEndPoint);
            
            byte[] msg = Encoding.UTF8.GetBytes(message);
            int bytesSent = sender.Send(msg);

            sender.ReceiveTimeout = 700;

            int bytesRec = sender.Receive(bytes);

            ServerData.ServMessage = Encoding.UTF8.GetString(bytes, 0, bytesRec);

            try
            {
                ServerData.ServMessageData = ServerData.ServMessage.Substring(ServerData.ServMessage.IndexOf(':') + 1);
            }
            catch
            {
                ServerData.ServMessageData = "no data";
            }

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
        public static void SendMessageFromHTTP(string message)
        {
            string URL = "http://" + Config.serverIP + "/ParolkaNewBackend.php";
            WebClient webClient = new WebClient();

            NameValueCollection formData = new NameValueCollection();
            formData["data"] = message;

            byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
            ServerData.ServMessage = Encoding.UTF8.GetString(responseBytes);
            ServerData.ServMessageData = ServerData.ServMessage.Substring(ServerData.ServMessage.IndexOf(':'));
            webClient.Dispose();
        }
    }
}
