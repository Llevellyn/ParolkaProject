using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentAce.Compression.ZipForge;
using System.IO;
using System.Net;

namespace Parolka
{
    public partial class Client : Form
	{
        static int ftpData = 0;
        static string ftpLogin;
        static string ftpPass;

        public Client()
		{
			InitializeComponent();
            label15.Text = Config.ver;
            Random rand = new Random();
            BackColor = Color.FromName(MainFormSites.BackColor[rand.Next(1, 12)]);
            HideElements();

            username.Text = ServerData.UserName;
		}
        void HideElements()
        {
            if (Parolka.ServerData.UserRole == "user")
            {
                Controls.Remove(pictureBox10);
                Controls.Remove(label5);
                Controls.Remove(pictureBox11);

                Controls.Remove(pictureBox2);
                Controls.Remove(label2);
                Controls.Remove(pictureBox3);

                Controls.Remove(pictureBox5);
                Controls.Remove(label3);
                Controls.Remove(pictureBox6);

                Controls.Remove(pictureBox15);
                
                PictureBox Bill = new PictureBox();
                Bill.BackColor = Color.Gainsboro;
                Bill.BackgroundImage = global::Parolka.Properties.Resources.appbar_cancel;
                Bill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                Bill.InitialImage = global::Parolka.Properties.Resources.appbar_cancel;
                Bill.Location = new Point(248, 93);
                Bill.Name = "BillStop";
                Bill.Size = new Size(177, 109);
                Bill.TabIndex = 56;
                Bill.TabStop = false;
                Controls.Add(Bill);
                Bill.BringToFront();

                PictureBox Serv = new PictureBox();
                Serv.BackColor = Color.Gainsboro;
                Serv.BackgroundImage = global::Parolka.Properties.Resources.appbar_cancel;
                Serv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                Serv.InitialImage = global::Parolka.Properties.Resources.appbar_cancel;
                Serv.Location = new Point(431, 93);
                Serv.Name = "BillStop";
                Serv.Size = new Size(177, 109);
                Serv.TabIndex = 56;
                Serv.TabStop = false;
                Controls.Add(Serv);
                Serv.BringToFront();

                PictureBox Inv = new PictureBox();
                Inv.BackColor = Color.Gainsboro;
                Inv.BackgroundImage = global::Parolka.Properties.Resources.appbar_cancel;
                Inv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                Inv.InitialImage = global::Parolka.Properties.Resources.appbar_cancel;
                Inv.Location = new Point(248, 208);
                Inv.Name = "BillStop";
                Inv.Size = new Size(177, 109);
                Inv.TabIndex = 56;
                Inv.TabStop = false;
                Controls.Add(Inv);
                Inv.BringToFront();
            }
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void CloseImg_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.FromName("HotTrack");
        }

        private void CloseImg_MouseEnter(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.FromName("Highlight");
        }

        private void CloseImg_MouseLeave(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.FromName("HotTrack");
        }

        private void Client_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Message n = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref n);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("Highlight");
            pictureBox4.BackColor = Color.FromName("Highlight");
            label1.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("HotTrack");
            pictureBox4.BackColor = Color.FromName("HotTrack");
            label1.BackColor = Color.FromName("HotTrack");
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName("Highlight");
            pictureBox3.BackColor = Color.FromName("Highlight");
            label2.BackColor = Color.FromName("Highlight");
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName("ForestGreen");
            pictureBox3.BackColor = Color.FromName("ForestGreen");
            label2.BackColor = Color.FromName("ForestGreen");
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromName("Highlight");
            pictureBox6.BackColor = Color.FromName("Highlight");
            label3.BackColor = Color.FromName("Highlight");
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromName("DodgerBlue");
            pictureBox6.BackColor = Color.FromName("DodgerBlue");
            label3.BackColor = Color.FromName("DodgerBlue");
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.FromName("Highlight");
            pictureBox11.BackColor = Color.FromName("Highlight");
            label5.BackColor = Color.FromName("Highlight");
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.FromName("Indigo");
            pictureBox11.BackColor = Color.FromName("Indigo");
            label5.BackColor = Color.FromName("Indigo");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Parolka.ServerData.UserName = null;
            Form Login = new Login();
            Login.Show();
            this.Hide();
        }

        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            pictureBox14.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            pictureBox14.BackColor = Color.Transparent;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form MainForm = new MainForm();
            MainForm.Show();

            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form ServicesManager = new ServicesManager();
            ServicesManager.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Config.ServerType != "http")
            {
                Form Billing = new Billing();
                Billing.Show();

                Hide();
            }
            else
            {
                DialogResult result1 = MessageBox.Show("Для HTTP-сервера пока не доступно. Продолжить?", "Achtung!", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    Form Billing = new Billing();
                    Billing.Show();

                    Hide();
                }
            }
        }

        private void username_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Form ServicesManager = new ServicesManager();
            ServicesManager.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form Inventarize = new Inventarize.Inventarize();
            Inventarize.Show();
            this.Hide();
        }

        private void pictureBox15_MouseEnter(object sender, EventArgs e)
        {
            pictureBox15.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
            pictureBox15.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            ftpDataBox.Visible = true;
            AcceptFtpData.Visible = true;
        }

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            AcceptFtpData.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            AcceptFtpData.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if (ftpData == 1)
            {
                ftpPass = ftpDataBox.Text;
                ftpDataBox.Clear();
                ftpDataBox.Visible = false;
                AcceptFtpData.Visible = false;

                PrepareUpdater();
            }
            if (ftpData == 0)
            {
                ftpLogin = ftpDataBox.Text;
                ftpData = 1;
                ftpDataBox.Clear();
            }
        }

        private void PrepareUpdater()
        {
            ZipForge archiver = new ZipForge();

            if (File.Exists("ver.html"))
                File.Delete("ver.html");

            if (File.Exists("Parolka.exe.upd"))
                File.Delete("Parolka.exe.upd");

            if (File.Exists("Parolka.zip"))
                File.Delete("Parolka.zip");

            if (File.Exists("updater.exe"))
                File.Delete("updater.exe");


            File.Copy("Parolka.exe", "Parolka.exe.upd");
            File.WriteAllText("ver.html", Application.ProductVersion);

            ////////////////////////////////
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile("http://parolka.simpo.biz/updater.exe", "updater.exe");
            }
            ////////////////////////////////

            archiver.FileName = "Parolka.zip";
            archiver.OpenArchive(FileMode.Create);
            archiver.BaseDir = Directory.GetCurrentDirectory();
            archiver.AddFiles("Parolka.exe.upd");
            archiver.AddFiles("updater.exe");
            archiver.CloseArchive();

            try
            {
                string[] files = new string[] { "ver.html", "Parolka.zip" };
                foreach (string file in files)
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://parolka.simpo.biz/public_html/" + file.ToString());
                    request.Method = WebRequestMethods.Ftp.UploadFile;

                    request.Credentials = new NetworkCredential(ftpLogin, ftpPass);

                    byte[] fileContents = File.ReadAllBytes(file);

                    request.ContentLength = fileContents.Length;

                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(fileContents, 0, fileContents.Length);
                    requestStream.Close();

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                    response.Close();

                    ftpData = 0;
                }
            }
            catch (Exception ex)
            {
                if (File.Exists("Parolka.zip"))
                    File.Delete("Parolka.zip");

                if (File.Exists("ver.html"))
                    File.Delete("ver.html");

                if (File.Exists("Parolka.exe.upd"))
                    File.Delete("Parolka.exe.upd");

                MessageBox.Show(ex.Message);
                ftpData = 0;
            }
            finally
            {
                MessageBox.Show("Обновление загружено!");
            }
        }
    }
}