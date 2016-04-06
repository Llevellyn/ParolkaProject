using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Parolka
{
	public partial class Client : Form
	{
		public Client()
		{
			InitializeComponent();
		}

        void ParolkaClient()
        {
            try
            {
                SendMessageFromSocket(11000, textBox1.Text.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        static void SendMessageFromSocket(int port, string message)
        {
            byte[] bytes = new byte[1024];

            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            sender.Connect(ipEndPoint);

            MessageBox.Show(sender.RemoteEndPoint.ToString());
            byte[] msg = Encoding.UTF8.GetBytes(message);

            int bytesSent = sender.Send(msg);

            int bytesRec = sender.Receive(bytes);

            MessageBox.Show(Encoding.UTF8.GetString(bytes, 0, bytesRec));

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParolkaClient();
        }
	}
}
