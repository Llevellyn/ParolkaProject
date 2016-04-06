using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Threading;
using System.Drawing;

namespace Parolka
{
    public partial class Billing : Form
	{
        static string h;
        static string x;
        static string[] arr;
        static string desc;

        public Billing()
		{
			InitializeComponent();
            h = "К продлению";
            button1.Paint += new PaintEventHandler(Button1Vertical);
            x = "Просрочены";
            button2.Paint += new PaintEventHandler(Button2Vertical);
            

            Random rand = new Random();
            this.BackColor = Color.FromName(MainFormSites.BackColor[rand.Next(1, 12)]);

            this.FormClosing += new FormClosingEventHandler(Login_FormClosing);

            Thread loadData = new Thread(new ThreadStart(loadAll));
            loadData.Start();

            HideElements();
        }
        private void Check_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '@' && e.KeyChar != '.' && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void CostCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        void HideElements()
        {
            if (ServerData.UserRole == "manager")
            {
                Controls.Remove(pictureBox16);
            }
        }
        void LoadStatistics()
        {
            try
            {
                ServicesExpireBox.Items.Clear();
                ExpiredBox.Items.Clear();
                string stat = null;

                List<string> ClientData = new List<string>();


                ServerData.ServMessage = null;
                ServerData.DataMessage = null;

                ServerData.DataMessage = "QUERY_BILLING_LOAD_COUNT_STATISTICS";
                Server.Server.ParolkaClient();

                if (ServerData.ServMessage.Contains("REPLY_BILLING_LOAD_COUNT_STATISTICS"))
                {
                    List<string> TransferFromServerSites = new List<string>();
                    string[] Sites = ServerData.ServMessageData.Split('|');
                    foreach (string id in Sites)
                    {
                        TransferFromServerSites.Add(id);
                    }

                    int x = TransferFromServerSites.Count;
                    int h = 0;

                    while (h <= x)
                    {
                        ServerData.DataMessage = "QUERY_BILLING_LOAD_STATISTICS:" + TransferFromServerSites[h];

                        Server.Server.ParolkaClient();

                        ClientData.Add(ServerData.ServMessage);
                        
                        h++;

                        if (h == x)
                        {
                            break;
                        }
                    }
                    int i = 0;

                    int CostExpiredMoney = 0;
                    int CostExpireMoney = 0;
                    int CostExpiredMoneyFull = 0;

                    foreach (string id in ClientData)
                    {
                        string[] ClientDataExpire = id.Split(':');

                        if (ClientDataExpire[2].Length > 0)
                        {
                            DateTime ExDate = DateTime.Parse(ClientDataExpire[2]);
                            DateTime CurDate = DateTime.Now;
                            DateTime ExpDate = CurDate.AddDays(10);

                            if (ExDate >= CurDate && ExDate <= ExpDate)
                            {
                                ServicesExpireBox.Items.Add(ClientDataExpire[0].Trim() + ", " + ClientDataExpire[1].Trim() + ", " + ClientDataExpire[2].Trim());
                                i++;
                                if (ClientDataExpire[3].Length >= 1)
                                {
                                    CostExpireMoney = CostExpireMoney + Convert.ToInt32(ClientDataExpire[3]);
                                }
                            }

                            if (ExDate < CurDate)
                            {
                                ExpiredBox.Items.Add(ClientDataExpire[0].Trim() + ", " + ClientDataExpire[1].Trim() + ", " + ClientDataExpire[2].Trim());
                                i++;
                                if (ClientDataExpire[3].Length >= 1)
                                {
                                    CostExpiredMoney = CostExpiredMoney + Convert.ToInt32(ClientDataExpire[3]);
                                }
                            }
                        }
                    }

                    CostExpiredMoneyFull = CostExpiredMoney + CostExpireMoney;
                    ExpireMoney.Text = CostExpireMoney.ToString();
                    ExpiredMoney.Text = CostExpiredMoney.ToString();
                    MoneyExpired.Text = CostExpiredMoneyFull.ToString();

                    pictureBox8.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                pictureBox8.Visible = true;
            }
        }
        void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.OfType<MainForm>().Any())
            { }
            else
                Environment.Exit(0);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Parolka.ServerData.DataMessage = "QUERY_BILLING_SAVE:" + ClientBox.SelectedItem + "|" + ServicesBox.SelectedItem + "|" + ServiceStartBox.Value.Date.ToString("yyyy-MM-dd") + "|" + ServiceEndBox.Value.Date.ToString("yyyy-MM-dd") + "|" + ManagerBox.Text + "|" + CostBox.Text + "|" + InitialsBox.Text + "|" + CompanyBox.Text + "|" + PhoneBox.Text + "|" + MailBox.Text;
                Parolka.Server.Server.ParolkaClient();

                if (Parolka.ServerData.ServMessage == "REPLY_BILLING_SAVE")
                {
                    MessageBox.Show("Сохранено!");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения!");
                loadAll();
            }

        }
        private void NewClientButton_Click(object sender, EventArgs e)
        {
            if (ClientBox.Items.Contains("Новый шаблон клиента") == false)
            {
                Parolka.ServerData.DataMessage = "QUERY_BILLING_CREATE_NEW_CLIENT";

                Parolka.Server.Server.ParolkaClient();

                if (Parolka.ServerData.ServMessage == "REPLY_BILLING_TEMPLATE_CREATED")
                {
                    ClientBox.Items.Add("Новый шаблон клиента");
                    int i = ClientBox.Items.IndexOf("Новый шаблон клиента");
                    ClientBox.SetSelected(i, true);
                }
            }
            else
            {
                int i = ClientBox.Items.IndexOf("Новый шаблон клиента");
                ClientBox.SetSelected(i, true);
            }

        }
        private void ReoveClientButton_Click(object sender, EventArgs e)
        {
            Parolka.ServerData.DataMessage = "QUERY_BILLING_REMOVE_CLIENT:" + CompanyBox.Text;
            Parolka.Server.Server.ParolkaClient();

            if (Parolka.ServerData.ServMessage == "REPLY_BILLING_CLIENT_REMOVED")
            {
                ServiceBox.Text = null;
                ServiceStartBox.Text = null;
                ServiceEndBox.Text = null;
                ManagerBox.Text = null;
                CostBox.Text = null;

                loadAll();
            }
        }

        private void ServicesSortClear(string h)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ServicesSortClear), new object[] { h });
                return;
            }
            ServicesList.Items.Clear();
        }
        private void ServicesListClear(string h)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ServicesListClear), new object[] { h });
                return;
            }
            ServicesSort.Items.Clear();
            ServicesSort.Items.Add("Все клиенты");
        }
        private void ClientBoxClear(string h)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ClientBoxClear), new object[] { h });
                return;
            }
            ClientBox.Items.Clear();
        }
        private void ItemsAdd(string h)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ItemsAdd), new object[] { h });
                return;
            }
            ServicesList.Items.Add(h);
            ServicesSort.Items.Add(h);
        }
        private void ClientsItemsAdd(string desc)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ClientsItemsAdd), new object[] { desc });
                return;
            }
            ClientBox.Items.Add(desc);
        }
        public void LoadComplete(string h)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(LoadComplete), new object[] { h });
                return;
            }
            ServicesList.Sorted = true;
            ServicesSort.Sorted = true;
        }
        public void ToArr(string h)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ToArr), new object[] { h });
                return;
            }

            arr = new string[ClientBox.Items.Count];
            for (int i = 0; i < ClientBox.Items.Count; i++)
            {
                arr[i] = ClientBox.Items[i].ToString();
            }

            ClientBox.Items.Clear();

            for (int i = 0; i < arr.Length; i++)
            {
                ClientBox.Items.Add(arr[i].Remove(arr[i].IndexOf('|')).Trim());
            }
            ClientBox.Sorted = true;
            
            LoadStatistics();
        }
        public void loadAll()
        {
            ServicesSortClear(null);
            ServicesListClear(null);
            ServerData.DataMessage = "QUERY_BILLING_SERVICES_COUNT";
            Server.Server.ParolkaClient();

            if (ServerData.ServMessage.Contains("REPLY_BILLING_SERVICES_COUNT"))
            {
                MessageBox.Show(ServerData.ServMessageData);
                ServerData.SitesCount = ServerData.ServMessageData;
                int i = int.Parse(ServerData.SitesCount);
                int h = 0;
                while (h <= i)
                {
                    ServerData.ServMessage = null;
                    ServerData.DataMessage = null;

                    ServerData.DataMessage = "QUERY_BILLING_GET_SERVICE:" + h.ToString();
                    Server.Server.ParolkaClient();

                    ItemsAdd(ServerData.ServMessage);

                    h++;
                    if (h == i)
                    {
                        ServerData.SitesCount = null;
                        ServerData.ServMessage = null;
                        ServerData.DataMessage = null;
                        LoadComplete(null);
                        h = 0;
                        break;
                    }
                }
            }

            ClientBoxClear(null);

            ServerData.DataMessage = "QUERY_BILLING_CLIENTS_COUNT";
            Server.Server.ParolkaClient();

            if (ServerData.ServMessage.Contains("REPLY_BILLING_CLIENTS_COUNT"))
            {
                int i = int.Parse(ServerData.ServMessageData);
                int h = 0;
                while (h <= i)
                {
                    ServerData.ServMessage = null;
                    ServerData.DataMessage = null;

                    ServerData.DataMessage = "QUERY_BILLING_GET_CLIENT:" + h.ToString();
                    Server.Server.ParolkaClient();

                    desc = ServerData.ServMessage.Trim() + " | ";

                    ServerData.DataMessage = "QUERY_BILLING_GET_CLIENT_ACTIVE_PERIODS:" + ServerData.ServMessage;

                    Server.Server.ParolkaClient();

                    if (ServerData.ServMessage.Length > 4)
                    {
                        string[] list = ServerData.ServMessage.Split('|');
                        foreach (string id in list)
                        {
                            desc = desc + id;
                        }
                    }
                    ClientsItemsAdd(desc);
                    h++;
                    if (h == i)
                    {
                        ServerData.SitesCount = null;
                        ServerData.ServMessage = null;
                        ServerData.DataMessage = null;
                        LoadComplete(null);
                        h = 0;
                        break;
                    }
                }
            }
            ToArr(null);
        }

        private void ClientBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClientBox.SelectedItem != null)
            {
                try
                {
                    InitialsBox.Text = null;
                    MailBox.Text = null;
                    PhoneBox.Text = null;

                    ServiceBox.Text = null;
                    ServiceStartBox.Value = System.DateTime.Now.Date;
                    ServiceEndBox.Value = System.DateTime.Now.Date;
                    ManagerBox.Text = null;
                    CostBox.Text = null;

                    Parolka.ServerData.DataMessage = "QUERY_BILLING_GET_CLIENT_DESCRIPTION:" + ClientBox.SelectedItem;

                    Parolka.Server.Server.ParolkaClient();

                    List<string> TransferFromServerSiteData = new List<string>();
                    string[] SiteData = Parolka.ServerData.ServMessage.Split('|');

                    foreach (string id in SiteData)
                    {
                        TransferFromServerSiteData.Add(id);
                    }

                    InitialsBox.Text = TransferFromServerSiteData[0];
                    MailBox.Text = TransferFromServerSiteData[1];
                    PhoneBox.Text = TransferFromServerSiteData[2];
                    CompanyBox.Text = ClientBox.SelectedItem.ToString();

                    SiteData = null;
                    TransferFromServerSiteData.Clear();

                    ServicesBoxLoad();
                }
                catch
                {
                }

            }
        }
        void ServicesBoxLoad()
        {
            ServicesBox.Items.Clear();

            Parolka.ServerData.DataMessage = "BILLING_GET_CLDE:" + ClientBox.SelectedItem;
            Parolka.ServerData.ServMessage = null;
            Parolka.Server.Server.ParolkaClient();

            if (Parolka.ServerData.ServMessage.Length > 4)
            {
                List<string> TransferFromServerServData = new List<string>();
                string[] list = Parolka.ServerData.ServMessage.Split('|');
                foreach (string id in list)
                {
                    ServicesBox.Items.Add(id);
                }
                ServicesBox.Enabled = true;
            }
            else
            {
                ServicesBox.Items.Clear();
                ServicesBox.Items.Add("Нет услуг");
                ServicesBox.Enabled = false;
            }
        }
        private void ServicesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ClientBox.SelectedItem != null)
                {
                    ServiceBox.Text = null;
                    ServiceStartBox.Text = null;
                    ServiceEndBox.Text = null;
                    ManagerBox.Text = null;
                    CostBox.Text = null;

                    Parolka.ServerData.DataMessage = "QUERY_BILLING_GET_SERVICE_DESCRIPTION:" + ClientBox.SelectedItem.ToString() + "|" + ServicesBox.SelectedItem.ToString();

                    Parolka.Server.Server.ParolkaClient();

                    List<string> TransferFromServerSiteData = new List<string>();
                    string[] SiteData = Parolka.ServerData.ServMessage.Split('|');
                    foreach (string id in SiteData)
                    {
                        TransferFromServerSiteData.Add(id);
                    }
                    ServiceBox.Text = ServicesBox.SelectedItem.ToString();
                    ServiceStartBox.Text = TransferFromServerSiteData[0];
                    ServiceEndBox.Text = TransferFromServerSiteData[1];
                    ManagerBox.Text = TransferFromServerSiteData[3];
                    CostBox.Text = TransferFromServerSiteData[4];

                    SiteData = null;
                    TransferFromServerSiteData.Clear();
                }
            }
            catch
            {

            }
        }

        private void ServiceApplyButton_Click(object sender, EventArgs e)
        {
            if (ServicesBox.Items.Contains(ServicesList.SelectedItem))
            {
                MessageBox.Show("Услуга уже оказывается!");
            }
            else
            {
                if (ServicesBox.Items.Contains("Нет услуг"))
                {
                    ServicesBox.Items.Remove("Нет услуг");
                }
                ServicesBox.Items.Add(ServicesList.SelectedItem);

                string[] items = ServicesBox.Items
                           .OfType<object>()
                           .Select(item => item.ToString())
                           .ToArray();
                string result = string.Join(",", items);

                Parolka.ServerData.DataMessage = "QUERY_BILLING_ADD_NEW_SERVICE:" + ClientBox.SelectedItem + "|" + ServicesList.SelectedItem + "|" + result;

                Parolka.Server.Server.ParolkaClient();

                ServicesBoxLoad();
            }
        }

        private void ServiceRemoveButton_Click(object sender, EventArgs e)
        {
            Parolka.ServerData.DataMessage = "QUERY_BILLING_REMOVE_SERVICE:" + CompanyBox.Text + "|" + ServicesBox.SelectedItem.ToString();
            Parolka.Server.Server.ParolkaClient();

            if (Parolka.ServerData.ServMessage == "REPLY_BILLING_SERVICE_DELETED")
            {
                ServiceBox.Text = null;
                ServiceStartBox.Text = null;
                ServiceEndBox.Text = null;
                ManagerBox.Text = null;
                CostBox.Text = null;

                var ToRemove = ServicesBox.SelectedItem.ToString();
                ServicesBox.SetSelected(0, true);
                ServicesBox.Items.Remove(ToRemove);
            }
        }
        private void CloseImg_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void CloseImg_MouseEnter(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.FromName("Highlight");
        }
        private void CloseImg_MouseLeave(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.FromName("HotTrack");
        }
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Message n = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref n);
        }
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromName("Highlight");
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromName("HotTrack");
        }
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromName("Highlight");
        }
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromName("HotTrack");
        }
        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.FromName("Highlight");
        }
        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.FromName("HotTrack");
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.FromName("Highlight");
        }
        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.FromName("HotTrack");
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName("Highlight");
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName("HotTrack");
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("Highlight");
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("HotTrack");
        }
        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Message n = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref n);
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
        private void ServicesExpireBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string trimmed = ServicesExpireBox.SelectedItem.ToString().Trim();

                int i = ClientBox.Items.IndexOf(trimmed.Substring(0, trimmed.IndexOf(',')));
                ClientBox.SetSelected(i, true);
            }
            catch
            { }
        }
        private void ExpiredBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string trimmed = ExpiredBox.SelectedItem.ToString().Trim();

            int i = ClientBox.Items.IndexOf(trimmed.Substring(0, trimmed.IndexOf(',')));
            ClientBox.SetSelected(i, true);
            }
            catch
            { }
        }

        private void ServicesSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ServicesSort.Text == "Все клиенты")
            {
                ExpiredBox.Enabled = true;
                ServicesExpireBox.Enabled = true;

                ClientBox.Items.Clear();
                string s = null;

                foreach (string i in arr)
                {
                    if (i.IndexOf('|') != -1)
                        s = i.Remove(i.IndexOf('|'));

                    ClientBox.Items.Add(s.Trim());
                }
                ClientBox.Sorted = true;
            }
            else
            {
                ClientBox.Items.Clear();
                string s = null;

                ExpiredBox.Enabled = false;
                ServicesExpireBox.Enabled = false;

                List<string> List = new List<string>();
                foreach (string i in arr)
                {
                    if (i.ToString().Contains(ServicesSort.Text))
                    {
                        if (i.IndexOf('|') != -1)
                            s = i.Remove(i.IndexOf('|'));

                        ClientBox.Items.Add(s.Trim());
                    }
                }
                ClientBox.Sorted = true;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.Visible = false;
            Thread loadData = new Thread(new ThreadStart(loadAll));
            loadData.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServicesExpireBox.Visible = true;
            ExpiredBox.Visible = false;
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ServicesExpireBox.Visible = false;
            ExpiredBox.Visible = true;
        }
        void Button1Vertical(object sender, PaintEventArgs e)
        {
            FontFamily fontFamily = new FontFamily("Segoe UI");
            Font font = new Font(fontFamily, 12, FontStyle.Regular, GraphicsUnit.Point);
            PointF pointF = new PointF();
            StringFormat stringFormat = new StringFormat();
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            e.Graphics.DrawString(h, font, solidBrush, pointF, stringFormat);
        }
        void Button2Vertical(object sender, PaintEventArgs e)
        {
            FontFamily fontFamily = new FontFamily("Segoe UI");
            Font font = new Font(fontFamily, 12, FontStyle.Regular, GraphicsUnit.Point);
            PointF pointF = new PointF();
            StringFormat stringFormat = new StringFormat();
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            e.Graphics.DrawString(x, font, solidBrush, pointF, stringFormat);
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.FromName("Highlight");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> Data = new List<string>();
            Data.Add("Компания;Ответственное лицо;E-mail;Телефон;Услуга;Дата начала;Дата окончания;Комментарий;Ответственный менеджер;Сумма");
            int h = 0;
            int i = ClientBox.Items.Count;

            while(h <= i)
            {
                try
                {
                    ///////////GET CLIENT DATA/////////////////////////

                    ServerData.DataMessage = "BILLING_GET_INFO:" + ClientBox.Items[h];
                    Server.Server.ParolkaClient();

                    string info = ServerData.ServMessage;

                    ///////////GET CLIENT SERVICES/////////////////////

                    ServerData.DataMessage = "BILLING_GET_CLDE:" + ClientBox.Items[h];
                    Server.Server.ParolkaClient();

                    if (ServerData.ServMessage.Length > 4)
                    {
                        List<string> Service = new List<string>();
                        string[] ServiceData = ServerData.ServMessage.Split('|');

                        foreach (string id in ServiceData)
                        {
                            ServerData.DataMessage = "BILLING_GET_DESC:" + ClientBox.Items[h] + "|" + id;
                            Server.Server.ParolkaClient();

                            string dataAll = ClientBox.Items[h] + ";" + info + ";" + id + ";" + ServerData.ServMessage;

                            dataAll = dataAll.Replace('|',';');

                            Data.Add(dataAll);
                        }
                    }

                    h++;

                    if (h == i)
                    {
                        break;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            SaveFileDialog path = new SaveFileDialog();
            path.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            path.FileName = "export.csv";
            path.ShowDialog();
            try
            {
                File.WriteAllLines(path.FileName, Data);
            }
            catch
            {
            }
        }
    }
}