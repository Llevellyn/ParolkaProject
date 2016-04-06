using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text;

namespace Parolka
{
    public partial class BitrixWorker : Form
	{
		public BitrixWorker()
		{
			InitializeComponent();
            BitrixBrowser.Navigate(Parolka.MainFormSites.BrowserNavigate);
		}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            foreach (HtmlElement element in BitrixBrowser.Document.GetElementsByTagName("input"))
            {
                if (element.Name == "__wiz_host")
                {
                    element.SetAttribute("value", Parolka.MainFormSites.DBHost);
                    break;
                }
            }
            foreach (HtmlElement element in BitrixBrowser.Document.GetElementsByTagName("input"))
            {
                if (element.Name == "__wiz_user")
                {
                    element.SetAttribute("value", Parolka.MainFormSites.DBUser);
                    break;
                }
            }
            foreach (HtmlElement element in BitrixBrowser.Document.GetElementsByTagName("input"))
            {
                if (element.Name == "__wiz_password")
                {
                    element.SetAttribute("value", Parolka.MainFormSites.DBPassword);
                    break;
                }
            }
            foreach (HtmlElement element in BitrixBrowser.Document.GetElementsByTagName("input"))
            {
                if (element.Name == "__wiz_database")
                {
                    element.SetAttribute("value", Parolka.MainFormSites.DBBase);
                    break;
                }
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("HotTrack");
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CloseImg_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Message n = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref n);
        }
    }
    static class BitrixRequest
    {
        public static void BitrixSetup()
        {
            try
            {
            //FtpWebRequest GetFoldersReq = (FtpWebRequest)WebRequest.Create("ftp://" + PasswordManager.FormEdit.selectedsite.ToString());
            //GetFoldersReq.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            //GetFoldersReq.Credentials = new NetworkCredential(PasswordManager.FormEdit.ftp_login_var.ToString(), PasswordManager.FormEdit.ftp_password_var.ToString());

            //FtpWebResponse response = (FtpWebResponse)GetFoldersReq.GetResponse();

            //Stream responseStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(responseStream);
            //MessageBox.Show(reader.ReadToEnd());
            //reader.Close();
            //response.Close();

            //StatusText.Text = "Ответ сервера: " + response.StatusDescription;

            //Thread.Sleep(550);
            //StatusText.Text = "Определяем, что и где лежит на сервере...";

            string remoteUri = "http://1c-bitrix.ru/download/scripts/";
            string fileName = "bitrixsetup.php", myStringWebResource = null;
            WebClient myWebClient = new WebClient();
            myStringWebResource = remoteUri + fileName;
            myWebClient.DownloadFile(myStringWebResource, fileName);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Parolka.MainFormSites.FTPHost + "/bitrixsetup.php");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential(Parolka.MainFormSites.FTPUser, Parolka.MainFormSites.FTPPassword);

            StreamReader sourceStream = new StreamReader("bitrixsetup.php");
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            response.Close();

            Parolka.MainFormSites.BrowserNavigate = "http://" + Parolka.MainFormSites.FTPHost + "/bitrixsetup.php";

            Form BitrixWorker = new BitrixWorker();
            BitrixWorker.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void BitrixBackup()
        {
            try
            {
                string remoteUri = "http://parolka.simpo.biz/";
                string fileName = "root_backup.cfg", myStringWebResource = null;
                WebClient myWebClient = new WebClient();
                myStringWebResource = remoteUri + fileName;
                myWebClient.DownloadFile(myStringWebResource, fileName);

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Parolka.MainFormSites.FTPHost + "/root_backup.php");
                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.Credentials = new NetworkCredential(Parolka.MainFormSites.FTPUser, Parolka.MainFormSites.FTPPassword);

                StreamReader sourceStream = new StreamReader("root_backup.cfg");
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                response.Close();

                System.Diagnostics.Process.Start("http://" + Parolka.MainFormSites.SelectedSite.ToString() + "/root_backup.php");

                File.Delete("root_backup.cfg");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void BitrixServerTest()
        {
            try
            {
            string remoteUri = "http://1c-bitrix.ru/download/scripts/";
            string fileName = "bitrix_server_test.php", myStringWebResource = null;
            WebClient myWebClient = new WebClient();
            myStringWebResource = remoteUri + fileName;
            myWebClient.DownloadFile(myStringWebResource, fileName);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Parolka.MainFormSites.FTPHost + "/bitrix_server_test.php");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential(Parolka.MainFormSites.FTPUser, Parolka.MainFormSites.FTPPassword);

            StreamReader sourceStream = new StreamReader("bitrix_server_test.php");
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            response.Close();

            File.Delete("bitrix_server_test.php");

            Parolka.MainFormSites.BrowserNavigate = "http://" + Parolka.MainFormSites.FTPHost + "/bitrix_server_test.php";

            Form BitrixWorker = new BitrixWorker();
            BitrixWorker.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void BitrixLogin()
        {
                try
                {
                    string remoteUri = "http://parolka.simpo.biz/";
                    string fileName = "root_auth.cfg", myStringWebResource = null;
                    WebClient myWebClient = new WebClient();
                    myStringWebResource = remoteUri + fileName;
                    myWebClient.DownloadFile(myStringWebResource, fileName);

                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Parolka.MainFormSites.FTPHost + "/root_auth.php");
                    request.Method = WebRequestMethods.Ftp.UploadFile;

                    request.Credentials = new NetworkCredential(Parolka.MainFormSites.FTPUser, Parolka.MainFormSites.FTPPassword);

                    StreamReader sourceStream = new StreamReader("root_auth.cfg");
                    byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                    sourceStream.Close();
                    request.ContentLength = fileContents.Length;

                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(fileContents, 0, fileContents.Length);
                    requestStream.Close();

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                    response.Close();

                    System.Diagnostics.Process.Start("http://" + Parolka.MainFormSites.SelectedSite.ToString() + "/root_auth.php");

                    File.Delete("root_auth.cfg");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }