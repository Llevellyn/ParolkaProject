using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Parolka.Server
{
    class Broadcast
    {
        public static void SendBroadcast()
        {
            byte[] buffer = new byte[64];

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

            socket.Connect(new IPEndPoint(IPAddress.Broadcast, 10002));
            socket.Send(Encoding.UTF8.GetBytes("Parolka, where you are?"));

            var ep = socket.LocalEndPoint;

            socket.Close();

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Bind(ep);
            socket.Receive(buffer);

            Config.serverIP = Encoding.UTF8.GetString(buffer).TrimEnd('\0');

            socket.Close();
        }
    }
}
