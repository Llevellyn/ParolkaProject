using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ParolkaServer
{
    class Broadcast
    {
        public static void ReceiveBroadcast()
        {
            byte[] buffer = new byte[1024];

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            var iep = new IPEndPoint(IPAddress.Any, 10002);

            socket.Bind(iep);

            while (true)
            {
                Console.WriteLine("\nBroadcast waiting...");
                var ep = iep as EndPoint;
                socket.ReceiveFrom(buffer, ref ep);
                var data = Encoding.UTF8.GetString(buffer);

                Console.WriteLine("\nReceived broadcast query");

                buffer = UTF8Encoding.UTF8.GetBytes(connectData.ipHost);
                socket.SendTo(buffer, ep);

                Console.WriteLine("\nIP " + connectData.ipHost + " Sended to " + ep.ToString());

                socket.Dispose();

                ReceiveBroadcast();
            }
        }
    }
}
