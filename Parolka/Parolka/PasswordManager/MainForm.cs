using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Drawing;

namespace Parolka
{
    public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
            label22.Text = Parolka.Config.ver;
            ToolTip();

            ColorChange();
            timerLoadSites();

            this.FormClosing += new FormClosingEventHandler(Login_FormClosing);

            if (Parolka.ServerData.UserRole != "admin")
            {
                pictureBox17.Visible = false;
                pictureBox18.Visible = false;
            }
        }
        void ToolTip()
        {
            MainToolTip.SetToolTip(pictureBox13, "Добавить сайт");
            MainToolTip.SetToolTip(pictureBox2, "Редактировать");
            MainToolTip.SetToolTip(pictureBox4, "Сохранить");
            MainToolTip.SetToolTip(pictureBox12, "Удалить");
            MainToolTip.SetToolTip(pictureBox5, "Обновить");
            MainToolTip.SetToolTip(pictureBox3, "Отменить редактирование");
            MainToolTip.SetToolTip(pictureBox11, "Войти в админ-панель bitrix");
            MainToolTip.SetToolTip(pictureBox6, "Установить bitrix");
            MainToolTip.SetToolTip(pictureBox7, "Резервное копирование bitrix");
            MainToolTip.SetToolTip(pictureBox8, "Тест сервера");
            MainToolTip.SetToolTip(pictureBox18, "Управление пользователями");
            MainToolTip.SetToolTip(pictureBox17, "Управление правами на выбранный сайт");
            MainToolTip.SetToolTip(pictureBox15, "PEREKRAS'TE ETO");
            MainToolTip.SetToolTip(pictureBox9, "Пинг сервера");
            MainToolTip.SetToolTip(pictureBox10, "Whois");
            MainToolTip.SetToolTip(pictureBox14, "Ответ сервера");
        }
        void timerLoadSites()
        {
            timerLoad.Interval = 1000;
            timerLoad.Tick += new EventHandler(timer1_Tick);
            timerLoad.Start();
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Thread GetSites = new Thread(new ThreadStart(GetSitesFromServer));
                GetSites.Start();
            }
            catch
            {
                Thread GetSites = new Thread(new ThreadStart(GetSitesFromServer));
                GetSites.Start();
            }
            timerLoad.Stop();
        }
        void ColorChange()
        {
            Random rand = new Random();
            this.BackColor = Color.FromName(Parolka.MainFormSites.BackColor[rand.Next(1, 12)]);
        }
        void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        public void StartLoad(string h)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(StartLoad), new object[] { h });
                return;
            }
            SitesBox.Items.Clear();
            MainFormSites.SitesCollection.Clear();

            Load.Visible = true;
            LoadBg.Visible = true;
        }
        public void LoadComplete(string h)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(LoadComplete), new object[] { h });
                return;
            }
            foreach (string site in MainFormSites.SitesCollection)
            {
                SitesBox.Items.Add(site);
            }
            SitesBox.Sorted = true;
            Load.Visible = false;
            LoadBg.Visible = false;
        }
        public void ServerError(string h)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ServerError), new object[] { h });
                return;
            }

            Load.Visible = false;
            LoadBg.Visible = false;
        }
        public void GetSitesFromServer()
        {
            StartLoad("^_^");
            try
            {
                ServerData.DataMessage = "QUERY_SITES_CHECK_ACCESS:" + ServerData.UserName.ToString() + ServerData.SessionHash;
                Server.Server.ParolkaClient();

                if (ServerData.ServMessage.Contains("REPLY_SITES_ROOT_ACCESS"))
                {
                    string SitesCount = ServerData.ServMessageData;
                    int i = int.Parse(SitesCount);
                    int h = 0;
                    
                    while (h <= i)
                    {
                        ServerData.ServMessage = null;
                        ServerData.DataMessage = null;
                        ServerData.DataMessage = "QUERY_SITES_LOAD_ROOT:" + h.ToString();
                        Server.Server.ParolkaClient();

                        MainFormSites.SitesCollection.Add(ServerData.ServMessage);
                        h++;
                        if (h == i)
                        {
                            LoadComplete("");
                            h = 0;
                            Thread.CurrentThread.Abort();
                            break;
                        }
                    }
                }
                if (ServerData.ServMessage.Contains("REPLY_SITES_USER_ACCESS"))
                {
                    List<string> TransferFromServerSites = new List<string>();
                    string[] Sites = ServerData.ServMessage.Substring(22).Split('|');
                    foreach (string id in Sites)
                    {
                        TransferFromServerSites.Add(id);
                    }

                    int i = TransferFromServerSites.Count;
                    int h = 0;

                    while (h <= i)
                    {
                        ServerData.ServMessage = null;
                        ServerData.DataMessage = null;

                        ServerData.DataMessage = "QUERY_SITES_LOAD_USER:" + TransferFromServerSites[h];

                        Server.Server.ParolkaClient();

                        MainFormSites.SitesCollection.Add(ServerData.ServMessage);

                        h++;
                        if (h == i)
                        {
                            ServerData.SitesCount = null;
                            ServerData.ServMessage = null;
                            ServerData.DataMessage = null;
                            LoadComplete("");
                            h = 0;
                            Thread.CurrentThread.Abort();

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ServerError(ex.Message + ServerData.ServMessage);
            }
        }
        private void EndSessionPoint_Click(object sender, EventArgs e)
        {
            Parolka.ServerData.UserName = null;
            Form Login = new Login();
            Login.Show();
            this.Hide();
        }

        private void CloseProgramPoint_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BXSetupPoint_Click(object sender, EventArgs e)
        {
            if (DBUser.TextLength > 1 && DBPassword.TextLength > 1 && DBBase.TextLength > 1)
            {

                Parolka.MainFormSites.DBHost = DBHost.Text;
                Parolka.MainFormSites.DBUser = DBUser.Text;
                Parolka.MainFormSites.DBPassword = DBPassword.Text;
                Parolka.MainFormSites.DBBase = DBBase.Text;

                if (FTPHost.TextLength < 1)
                {
                    Parolka.MainFormSites.DBHost = "localhost";
                }
                if (FTPHost.TextLength > 1)
                {
                    Parolka.MainFormSites.FTPHost = FTPHost.Text;
                    Parolka.MainFormSites.FTPUser = FTPUser.Text;
                    Parolka.MainFormSites.FTPPassword = FTPPassword.Text;

                    Parolka.BitrixRequest.BitrixSetup();
                }
                else
                {
                    if (MessageBox.Show("FTP-хост не указан. Можно попробовать подключиться по URI, но это работает не везде. Продолжаем?", "Опасно!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && SitesBox.SelectedItem != null)
                    {
                        Parolka.MainFormSites.FTPHost = Parolka.MainFormSites.SelectedSite.ToString();
                        Parolka.MainFormSites.FTPUser = FTPUser.Text;
                        Parolka.MainFormSites.FTPPassword = FTPPassword.Text;

                        Parolka.BitrixRequest.BitrixSetup();
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Нет доступов к БД, автоматически установить не получится!", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && SitesBox.SelectedItem != null)
                {
                    if (FTPHost.TextLength > 1)
                    {
                        Parolka.MainFormSites.FTPHost = FTPHost.Text;
                        Parolka.MainFormSites.FTPUser = FTPUser.Text;
                        Parolka.MainFormSites.FTPPassword = FTPPassword.Text;

                        Parolka.BitrixRequest.BitrixSetup();
                    }
                    else
                    {
                        if (MessageBox.Show("FTP-хост не указан. Можно попробовать подключиться по URI, но это работает не везде. Продолжаем?", "Опасно!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && SitesBox.SelectedItem != null)
                        {
                            Parolka.MainFormSites.FTPHost = Parolka.MainFormSites.SelectedSite.ToString();
                            Parolka.MainFormSites.FTPUser = FTPUser.Text;
                            Parolka.MainFormSites.FTPPassword = FTPPassword.Text;

                            Parolka.BitrixRequest.BitrixSetup();
                        }
                    }
                }
            }
        }

        private void BXLoginPoint_Click(object sender, EventArgs e)
        {
            if (FTPHost.TextLength > 1)
            {
                Parolka.MainFormSites.FTPHost = FTPHost.Text;
                Parolka.MainFormSites.FTPUser = FTPUser.Text;
                Parolka.MainFormSites.FTPPassword = FTPPassword.Text;

                Parolka.BitrixRequest.BitrixLogin();
            }
            else
            {
                if (MessageBox.Show("FTP-хост не указан. Можно попробовать подключиться по URI, но это работает не везде. Продолжаем?", "Опасно!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && SitesBox.SelectedItem != null)
                {
                    Parolka.MainFormSites.FTPHost = Parolka.MainFormSites.SelectedSite.ToString();
                    Parolka.MainFormSites.FTPUser = FTPUser.Text;
                    Parolka.MainFormSites.FTPPassword = FTPPassword.Text;

                    Parolka.BitrixRequest.BitrixLogin();
                }
            }
        }

        private void BXBackupPoint_Click(object sender, EventArgs e)
        {
            if (FTPHost.TextLength > 1)
            {
                Parolka.MainFormSites.FTPHost = FTPHost.Text;
                Parolka.MainFormSites.FTPUser = FTPUser.Text;
                Parolka.MainFormSites.FTPPassword = FTPPassword.Text;

                Parolka.BitrixRequest.BitrixBackup();
            }
            else
            {
                if (MessageBox.Show("FTP-хост не указан. Можно попробовать подключиться по URI, но это работает не везде. Продолжаем?", "Опасно!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && SitesBox.SelectedItem != null)
                {
                    Parolka.MainFormSites.FTPHost = Parolka.MainFormSites.SelectedSite.ToString();
                    Parolka.MainFormSites.FTPUser = FTPUser.Text;
                    Parolka.MainFormSites.FTPPassword = FTPPassword.Text;

                    Parolka.BitrixRequest.BitrixBackup();
                }
            }
        }

        private void BXServerTestPoint_Click(object sender, EventArgs e)
        {
            if (FTPHost.TextLength > 1)
            {
                Parolka.MainFormSites.FTPHost = FTPHost.Text;
                Parolka.MainFormSites.FTPUser = FTPUser.Text;
                Parolka.MainFormSites.FTPPassword = FTPPassword.Text;

                Parolka.BitrixRequest.BitrixServerTest();
            }
            else
            {
                if (MessageBox.Show("FTP-хост не указан. Можно попробовать подключиться по URI, но это работает не везде. Продолжаем?", "Опасно!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && SitesBox.SelectedItem != null)
                {
                    Parolka.MainFormSites.FTPHost = Parolka.MainFormSites.SelectedSite.ToString();
                    Parolka.MainFormSites.FTPUser = FTPUser.Text;
                    Parolka.MainFormSites.FTPPassword = FTPPassword.Text;

                    Parolka.BitrixRequest.BitrixServerTest();
                }
            }
        }
        private void AddSitePoint_Click(object sender, EventArgs e)
        {
            Form AddSite = new AddSite();
            AddSite.Show();
        }
        private void RemovePoint_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && SitesBox.SelectedItem != null)
            {
                ServerData.ServMessage = null;
                ServerData.DataMessage = null;

                if (ServerData.UserRole == "admin")
                {
                    ServerData.DataMessage = "QUERY_SITE_FULL_DELETE:" + SitesBox.SelectedItem.ToString();
                    Server.Server.ParolkaClient();
                    if (ServerData.ServMessage == "REPLY_SITE_FULL_DELETED")
                    {
                        SitesBox.Items.Remove(SitesBox.SelectedItem.ToString());
                        SitesBox.SetSelected(0, true);

                        ServerData.ServMessage = null;
                        ServerData.DataMessage = null;
                    }
                }
                else
                {
                    Parolka.ServerData.DataMessage = "QUERY_SITE_USER_DELETE:" + SitesBox.SelectedItem.ToString() + ":" + Parolka.ServerData.UserName;
                    Parolka.Server.Server.ParolkaClient();

                    if (Parolka.ServerData.ServMessage == "REPLY_SITE_USER_DELETED")
                    {
                        SitesBox.Items.Remove(SitesBox.SelectedItem.ToString());
                        SitesBox.SetSelected(0, true);

                        Parolka.ServerData.ServMessage = null;
                        Parolka.ServerData.DataMessage = null;
                    }
                }
            }
        }
        private void PingPoint_Click(object sender, EventArgs e)
        {
            if (SitesBox.SelectedItem != null)
            {
                Parolka.Web.SinglePing.SinglePingReq();
                MessageBox.Show(Parolka.Ping.PingSingle);
            }
            else
            {
                MessageBox.Show("Сайт не выбран!");
            }
        }
        private void MassPingPoint_Click(object sender, EventArgs e)
        {

        }

        private void WhoisPoint_Click(object sender, EventArgs e)
        {
            if (SitesBox.SelectedItem != null)
            {
                Parolka.Web.WhoisSingle.WhoisReq();
                MessageBox.Show(Parolka.Whois.WhoisSingle);
            }
            else
            {
                MessageBox.Show("Сайт не выбран!");
            }
        }

        private void ExpiringPoint_Click(object sender, EventArgs e)
        {

        }

        private void MassWhoisPoint_Click(object sender, EventArgs e)
        {

        }
        private void ServerReplyPoint_Click(object sender, EventArgs e)
        {
            int statusCode;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + SitesBox.SelectedItem.ToString().Trim());
                request.Method = WebRequestMethods.Http.Head;
                request.Accept = @"*/*";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                statusCode = (int)response.StatusCode;
                response.Close();
                MessageBox.Show(statusCode.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddUserPoint_Click(object sender, EventArgs e)
        {

        }
        private void AccessManPoint_Click(object sender, EventArgs e)
        {


        }
        private void UserManPoint_Click(object sender, EventArgs e)
        {

        }
        private void NetworkDrivePoint_Click(object sender, EventArgs e)
        {

        }
        private void WebDAVPoint_Click(object sender, EventArgs e)
        {

        }
        private void PSREINST_Click(object sender, EventArgs e)
        {

        }
        private void EditMainButton_Click(object sender, EventArgs e)
        {
            // этот бред переписать

            CMSHost.ReadOnly = false;
            CMSUser.ReadOnly = false;
            CMSPassword.ReadOnly = false;
            CMSAdd.ReadOnly = false;
            HostingHost.ReadOnly = false;
            HostingUser.ReadOnly = false;
            HostingPassword.ReadOnly = false;
            HostingAdd.ReadOnly = false;
            DBHost.ReadOnly = false;
            DBUser.ReadOnly = false;
            DBPassword.ReadOnly = false;
            DBBase.ReadOnly = false;
            FTPHost.ReadOnly = false;
            FTPUser.ReadOnly = false;
            FTPPassword.ReadOnly = false;
            FtpPort.ReadOnly = false;
            Comments.ReadOnly = false;

            Parolka.MainFormSites.CMSHost = CMSHost.Text;
            Parolka.MainFormSites.CMSUser = CMSUser.Text;
            Parolka.MainFormSites.CMSPassword = CMSPassword.Text;
            Parolka.MainFormSites.CMSAdd = CMSAdd.Text;
            Parolka.MainFormSites.HostingHost = HostingHost.Text;
            Parolka.MainFormSites.HostingUser = HostingUser.Text;
            Parolka.MainFormSites.HostingPassword = HostingPassword.Text;
            Parolka.MainFormSites.HostingAdd = HostingAdd.Text;
            Parolka.MainFormSites.DBHost = DBHost.Text;
            Parolka.MainFormSites.DBUser = DBUser.Text;
            Parolka.MainFormSites.DBPassword = DBPassword.Text;
            Parolka.MainFormSites.DBBase = DBBase.Text;
            Parolka.MainFormSites.FTPHost = FTPHost.Text;
            Parolka.MainFormSites.FTPUser = FTPUser.Text;
            Parolka.MainFormSites.FTPPassword = FTPPassword.Text;
            Parolka.MainFormSites.FTPPort = FtpPort.Text;
            Parolka.MainFormSites.Comments = Comments.Text;
        }
        private void CancelMainButton_Click(object sender, EventArgs e)
        {

            // этот тоже
            CMSHost.Text = Parolka.MainFormSites.CMSHost;
            CMSUser.Text = Parolka.MainFormSites.CMSUser;
            CMSPassword.Text = Parolka.MainFormSites.CMSPassword;
            CMSAdd.Text = Parolka.MainFormSites.CMSAdd;
            HostingHost.Text = Parolka.MainFormSites.HostingHost;
            HostingUser.Text = Parolka.MainFormSites.HostingUser;
            HostingPassword.Text = Parolka.MainFormSites.HostingPassword;
            HostingAdd.Text = Parolka.MainFormSites.HostingAdd;
            DBHost.Text = Parolka.MainFormSites.DBHost;
            DBUser.Text = Parolka.MainFormSites.DBUser;
            DBPassword.Text = Parolka.MainFormSites.DBPassword;
            DBBase.Text = Parolka.MainFormSites.DBBase;
            FTPHost.Text = Parolka.MainFormSites.FTPHost;
            FTPUser.Text = Parolka.MainFormSites.FTPUser;
            FTPPassword.Text = Parolka.MainFormSites.FTPPassword;
            FtpPort.Text = Parolka.MainFormSites.FTPPort;
            Comments.Text = Parolka.MainFormSites.Comments;

            CMSHost.ReadOnly = true;
            CMSUser.ReadOnly = true;
            CMSPassword.ReadOnly = true;
            CMSAdd.ReadOnly = true;
            HostingHost.ReadOnly = true;
            HostingUser.ReadOnly = true;
            HostingPassword.ReadOnly = true;
            HostingAdd.ReadOnly = true;
            DBHost.ReadOnly = true;
            DBUser.ReadOnly = true;
            DBPassword.ReadOnly = true;
            DBBase.ReadOnly = true;
            FTPHost.ReadOnly = true;
            FTPUser.ReadOnly = true;
            FTPPassword.ReadOnly = true;
            FtpPort.ReadOnly = true;
            Comments.ReadOnly = true;
        }
        private void GetSitesButton_Click(object sender, EventArgs e)
        {
            Thread GetSites = new Thread(new ThreadStart(GetSitesFromServer));
            GetSites.Start();
        }
        private void SitesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Parolka.MainFormSites.SelectedSite = SitesBox.SelectedItem.ToString();
            GetSiteInfo();
        }
        void GetSiteInfo()
        {
            try
            {
                Parolka.ServerData.ServMessage = null;
                Parolka.ServerData.DataMessage = null;

                Parolka.ServerData.DataMessage = "QUERY_SITE_DESCRIPTION:" + SitesBox.SelectedItem.ToString().Trim();

                Parolka.Server.Server.ParolkaClient();

                List<string> TransferFromServerSiteData = new List<string>();
                string[] SiteData = Parolka.ServerData.ServMessage.Split('|');
                foreach (string id in SiteData)
                {
                    TransferFromServerSiteData.Add(id);
                }
                CMSHost.Text = TransferFromServerSiteData[0];
                CMSUser.Text = TransferFromServerSiteData[1];
                CMSPassword.Text = TransferFromServerSiteData[2];
                CMSAdd.Text = TransferFromServerSiteData[3];
                HostingHost.Text = TransferFromServerSiteData[4];
                HostingUser.Text = TransferFromServerSiteData[5];
                HostingPassword.Text = TransferFromServerSiteData[6];
                HostingAdd.Text = TransferFromServerSiteData[7];
                DBHost.Text = TransferFromServerSiteData[8];
                DBUser.Text = TransferFromServerSiteData[9];
                DBPassword.Text = TransferFromServerSiteData[10];
                DBBase.Text = TransferFromServerSiteData[11];
                FTPHost.Text = TransferFromServerSiteData[12];
                FTPUser.Text = TransferFromServerSiteData[13];
                FTPPassword.Text = TransferFromServerSiteData[14];
                FtpPort.Text = TransferFromServerSiteData[15];
                Comments.Text = TransferFromServerSiteData[16];

                SiteData = null;
                TransferFromServerSiteData.Clear();
                Parolka.ServerData.ServMessage = null;
                Parolka.ServerData.DataMessage = null;

            }
            catch
            {
            }
        }

        private void SaveMainButton_Click(object sender, EventArgs e)
        {
            List<string> TransferToServerSiteData = new List<string>();
            TransferToServerSiteData.Add(SitesBox.SelectedItem.ToString());
            TransferToServerSiteData.Add(CMSHost.Text.Trim());
            TransferToServerSiteData.Add(CMSUser.Text.Trim());
            TransferToServerSiteData.Add(CMSPassword.Text.Trim());
            TransferToServerSiteData.Add(CMSAdd.Text);
            TransferToServerSiteData.Add(HostingHost.Text.Trim());
            TransferToServerSiteData.Add(HostingUser.Text.Trim());
            TransferToServerSiteData.Add(HostingPassword.Text.Trim());
            TransferToServerSiteData.Add(HostingAdd.Text);
            TransferToServerSiteData.Add(DBHost.Text.Trim());
            TransferToServerSiteData.Add(DBUser.Text.Trim());
            TransferToServerSiteData.Add(DBPassword.Text.Trim());
            TransferToServerSiteData.Add(DBBase.Text.Trim());
            TransferToServerSiteData.Add(FTPHost.Text.Trim());
            TransferToServerSiteData.Add(FTPUser.Text.Trim());
            TransferToServerSiteData.Add(FTPPassword.Text.Trim());
            TransferToServerSiteData.Add(FtpPort.Text.Trim());
            TransferToServerSiteData.Add(Comments.Text);

            var SiteInfoToServer = String.Join(",", TransferToServerSiteData);

            Parolka.ServerData.ServMessage = null;
            Parolka.ServerData.DataMessage = null;

            Parolka.ServerData.DataMessage = "QUERY_SITE_DESCRIPTION_UPDATE:" + SiteInfoToServer.ToString();

            Parolka.Server.Server.ParolkaClient();

            CMSHost.ReadOnly = true;
            CMSUser.ReadOnly = true;
            CMSPassword.ReadOnly = true;
            CMSAdd.ReadOnly = true;
            HostingHost.ReadOnly = true;
            HostingUser.ReadOnly = true;
            HostingPassword.ReadOnly = true;
            HostingAdd.ReadOnly = true;
            DBHost.ReadOnly = true;
            DBUser.ReadOnly = true;
            DBPassword.ReadOnly = true;
            DBBase.ReadOnly = true;
            FTPHost.ReadOnly = true;
            FTPUser.ReadOnly = true;
            FTPPassword.ReadOnly = true;
            FtpPort.ReadOnly = true;
            Comments.ReadOnly = true;
        }

        private void ServicesPoint_Click(object sender, EventArgs e)
        {

        }

        private void SitesBox_DoubleClick(object sender, EventArgs e)
        {
            if (SitesBox.SelectedItem != null)
                Clipboard.SetText(SitesBox.SelectedItem.ToString());

        }
        private void CMSHost_MouseMove(object sender, MouseEventArgs e)
        {
            if (CMSHost.Text.Length > 1)
            {
                CMSHost.SelectAll();
                Clipboard.SetText(CMSHost.Text.ToString());
            }
        }
        private void CMSUser_MouseMove(object sender, EventArgs e)
        {
            if (CMSUser.Text.Length > 1)
            {
                CMSUser.SelectAll();
                Clipboard.SetText(CMSUser.Text.ToString());
            }
        }

        private void CMSPassword_MouseMove(object sender, MouseEventArgs e)
        {
            if (CMSPassword.Text.Length > 1)
            {
                CMSPassword.SelectAll();
                Clipboard.SetText(CMSPassword.Text.ToString());
            }
        }

        private void CMSAdd_MouseMove(object sender, MouseEventArgs e)
        {
            if (CMSAdd.Text.Length > 1)
            {
                CMSAdd.SelectAll();
                Clipboard.SetText(CMSAdd.Text.ToString());
            }
        }

        private void HostingHost_MouseMove(object sender, MouseEventArgs e)
        {
            if (HostingHost.Text.Length > 1)
            {
                HostingHost.SelectAll();
                Clipboard.SetText(HostingHost.Text.ToString());
            }
        }

        private void HostingUser_MouseMove(object sender, MouseEventArgs e)
        {
            if (HostingUser.Text.Length > 1)
            {
                HostingUser.SelectAll();
                Clipboard.SetText(HostingUser.Text.ToString());
            }
        }

        private void HostingPassword_MouseMove(object sender, MouseEventArgs e)
        {
            if (HostingPassword.Text.Length > 1)
            {
                HostingPassword.SelectAll();
                Clipboard.SetText(HostingPassword.Text.ToString());
            }
        }

        private void HostingAdd_MouseMove(object sender, MouseEventArgs e)
        {
            if (HostingAdd.Text.Length > 1)
            {
                HostingAdd.SelectAll();
                Clipboard.SetText(HostingAdd.Text.ToString());
            }
        }

        private void DBHost_MouseMove(object sender, MouseEventArgs e)
        {
            if (DBHost.Text.Length > 1)
            {
                DBHost.SelectAll();
                Clipboard.SetText(DBHost.Text.ToString());
            }
        }

        private void DBUser_MouseMove(object sender, MouseEventArgs e)
        {
            if (DBUser.Text.Length > 1)
            {
                DBUser.SelectAll();
                Clipboard.SetText(DBUser.Text.ToString());
            }
        }

        private void DBPassword_MouseMove(object sender, MouseEventArgs e)
        {
            if (DBPassword.Text.Length > 1)
            {
                DBPassword.SelectAll();
                Clipboard.SetText(DBPassword.Text.ToString());
            }
        }

        private void DBBase_MouseMove(object sender, MouseEventArgs e)
        {
            if (DBBase.Text.Length > 1)
            {
                DBBase.SelectAll();
                Clipboard.SetText(DBBase.Text.ToString());
            }
        }

        private void FTPHost_MouseMove(object sender, MouseEventArgs e)
        {
            if (FTPHost.Text.Length > 1)
            {
                FTPHost.SelectAll();
                Clipboard.SetText(FTPHost.Text.ToString());
            }
        }

        private void FTPUser_MouseMove(object sender, MouseEventArgs e)
        {
            if (FTPUser.Text.Length > 1)
            {
                FTPUser.SelectAll();
                Clipboard.SetText(FTPUser.Text.ToString());
            }
        }

        private void FTPPassword_MouseMove(object sender, MouseEventArgs e)
        {
            if (FTPPassword.Text.Length > 1)
            {
                FTPPassword.SelectAll();
                Clipboard.SetText(FTPPassword.Text.ToString());
            }
        }

        private void FtpPort_MouseMove(object sender, MouseEventArgs e)
        {
            if (FtpPort.Text.Length > 1)
            {
                FtpPort.SelectAll();
                Clipboard.SetText(FtpPort.Text.ToString());
            }
        }

        private void BillingPoint_Click(object sender, EventArgs e)
        {
            Form Billing = new Billing();
            Billing.Show();
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

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Message n = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref n);
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(192, 0, 0);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Message n = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref n);
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            pictureBox12.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            pictureBox12.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox13_MouseEnter(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            pictureBox11.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            pictureBox14.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            pictureBox14.BackColor = Color.FromName("HotTrack");
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
            ColorChange();
        }

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            pictureBox16.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            pictureBox16.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Form Client = new Client();
            Client.Show();

            this.Hide();
        }

        private void pictureBox17_MouseEnter(object sender, EventArgs e)
        {
            if (SitesBox.SelectedItem != null)
            {
                pictureBox17.BackColor = Color.FromName("Highlight");
            }
        }

        private void pictureBox17_MouseLeave(object sender, EventArgs e)
        {
            pictureBox17.BackColor = Color.FromName("HotTrack");
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            if (SitesBox.SelectedItem != null)
            {
                Form AccessMan = new AccessMan();
                AccessMan.Show();
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Form UserMan = new UserMan();
            UserMan.Show();
        }

        private void pictureBox18_MouseEnter(object sender, EventArgs e)
        {
            pictureBox18.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox18_MouseLeave(object sender, EventArgs e)
        {
            pictureBox18.BackColor = Color.FromName("HotTrack");
        }
    }
}
