using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Parolka
{
    public partial class Login : Form
	{
        static bool saveLogin = false;
        static bool usrLoaded = false;

        public Login()
		{
            InitializeComponent();
            label15.Text = Config.ver;
            if (File.Exists("last.user") && usrLoaded == false)
            {
                string[] usr = File.ReadAllLines("last.user");

                LoginString.Text = usr[0];
                PasswordString.Text = "passValue";
                ServerData.UserPass = usr[1];
                usrLoaded = true;
            }
            comboBox1.Text = "parolka.simpo.biz";
            ServerTypeBox.Text = "http";

            Random rand = new Random();
            BackColor = Color.FromName(MainFormSites.BackColor[rand.Next(1,12)]);

            KeyDown += new KeyEventHandler(Login_KeyDown);

            if (File.Exists("updater.exe"))
            {
                File.Delete("updater.exe");
            }

            Thread loadVer = new Thread(new ThreadStart(Server.Updater.UpdateCheck));
            loadVer.Start();
        }
        void ConfigLoad()
        {
            try
            {
                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    string line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            LoginAction();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (saveLogin == true && PasswordString.Text != "passValue")
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes("_p" + PasswordString.Text.ToString()));
                ServerData.UserPass = BitConverter.ToString(checkSum).Replace("-", string.Empty).ToLower();
            
                string[] data = { LoginString.Text, ServerData.UserPass };
            
                File.WriteAllLines("last.user", data, Encoding.UTF8);
            }

            ServerData.SessionHash = null;
            Config.ServerType = ServerTypeBox.Text;
            Config.serverIP = comboBox1.Text;
            LoginAction();
        }
        void LoginAction()
        {
            ServerData.UserName = LoginString.Text.ToString().Trim();

            if (usrLoaded == false)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes("_p" + PasswordString.Text.ToString()));
                ServerData.UserPass = BitConverter.ToString(checkSum).Replace("-", string.Empty).ToLower();
            }

            ServerData.DataMessage = "QUERY_USER_LOGIN";
            Server.Server.ParolkaClient();
            
            if (ServerData.ServMessage.Contains("REPLY_USER_LOGIN_ACCEPTED"))
            {
                if (Config.ServerType == "http")
                {
                    ServerData.SessionHash = ":" + ServerData.ServMessageData;
                }
                ServerData.DataMessage = "QUERY_USER_AUTH_LOGIN:" + ServerData.UserName;
                Server.Server.ParolkaClient();
            }
            if (ServerData.ServMessage.Contains("REPLY_USER_AUTH_LOGIN_INCORRECT") || ServerData.ServMessage == "REPLY_USER_AUTH_PASSWORD_INCORRECT")
            {
                MessageBox.Show("Имя пользователя или пароль неверны!");
            }
            if (ServerData.ServMessage.Contains("REPLY_USER_AUTH_LOGIN_CORRECT"))
            {
                ServerData.DataMessage = "QUERY_USER_AUTH_PASSWORD:" + ServerData.UserPass + ServerData.SessionHash;
                Server.Server.ParolkaClient();
            }
            if (ServerData.ServMessage.Contains("REPLY_USER_AUTH_PASSWORD_CORRECT"))
            {
                ServerData.DataMessage = "QUERY_USER_ROLE:" + ServerData.UserName + ServerData.SessionHash;
                Server.Server.ParolkaClient();
            }
            if (ServerData.ServMessage.Contains("REPLY_USER_ROLE"))
            {
                ServerData.UserRole = ServerData.ServMessageData;

                Form Client = new Client();
                Client.Show();

                ServerData.UserPass = null;
                LoginString.Clear();
                PasswordString.Clear();
                usrLoaded = false;

                Hide();
            }
            if (ServerData.ServMessage.Contains("REPLY_USER_ROLE:BILLING"))
            {
                ServerData.UserRole = "manager";
                Form Billing = new Billing();
                Billing.Show();

                ServerData.UserPass = null;
                LoginString.Clear();
                PasswordString.Clear();
                usrLoaded = false;

                Hide();
            }
        }
        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            LoginString.Clear();
            PasswordString.Clear();
        }

        private void CloseImg_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void CloseImg_MouseEnter(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void CloseImg_MouseLeave(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.Red;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Message n = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref n);
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromName("HotTrack");
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("Highlight");
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("HotTrack");
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(saveLogin == true)
            {
                pictureBox2.BackColor = Color.FromName("HotTrack");
                saveLogin = false;
            }
            else
            {
                pictureBox2.BackColor = Color.FromName("Highlight");
                saveLogin = true;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            ServerData.DataMessage = textBox1.Text;
            Config.ServerType = ServerTypeBox.Text;
            Config.serverIP = comboBox1.Text;
            Server.Server.ParolkaClient();

            MessageBox.Show(ServerData.ServMessage);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button1.Visible = true;
        }
    }
}
