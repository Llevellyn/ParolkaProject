using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Parolka
{
	public partial class ServicesManager : Form
	{
        public ServicesManager()
		{
			InitializeComponent();

            label15.Text = Parolka.Config.ver;
            LoadServices();
		}
        void LoadServices()
        {
            ServerData.ServMessage = null;
            ServerData.DataMessage = null;

            ServiceList.Items.Clear();

            ServerData.DataMessage = "QUERY_SERVICE_GET_COUNT";
            Server.Server.ParolkaClient();

            if (ServerData.ServMessage.Contains("REPLY_SERVICE_GET_COUNT"))
            {
                ServerData.SitesCount = ServerData.ServMessageData;
                int i = int.Parse(ServerData.SitesCount);
                int h = 0;
                while (h <= i)
                {
                    ServerData.ServMessage = null;
                    ServerData.DataMessage = null;

                    ServerData.DataMessage = "QUERY_SERVICE_LOAD:" + h.ToString();
                    Server.Server.ParolkaClient();

                    ServiceList.Items.Add(ServerData.ServMessage);
                    h++;
                    if (h == i)
                    {
                        ServerData.SitesCount = null;
                        ServerData.ServMessage = null;
                        ServerData.DataMessage = null;
                        ServiceList.Sorted = true;
                        h = 0;
                        break;
                    }
                }
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            ServerData.DataMessage = "QUERY_SERVICE_ADD:" + SiteBox.Text.Trim();
            Server.Server.ParolkaClient();
            if (ServerData.ServMessage == "REPLY_SERVICE_ADDED")
            {
                ServerData.ServMessage = null;
                ServerData.DataMessage = null;
                LoadServices();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                ServerData.DataMessage = "QUERY_SERVICE_DELETE:" + ServiceList.SelectedItem.ToString();
                Server.Server.ParolkaClient();
                if (ServerData.ServMessage == "REPLY_SERVICE_DELETED")
                {
                    ServiceList.Items.Remove(ServiceList.SelectedItem.ToString());
                    ServiceList.SetSelected(0, true);

                    ServerData.ServMessage = null;
                    ServerData.DataMessage = null;
                }
            }
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            ServiceIP.ReadOnly = false;
            ServiceLogin.ReadOnly = false;
            ServicePassword.ReadOnly = false;
            ServiceComment.ReadOnly = false;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            ServiceIP.ReadOnly = true;
            ServiceLogin.ReadOnly = true;
            ServicePassword.ReadOnly = true;
            ServiceComment.ReadOnly = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Parolka.ServerData.ServMessage = null;
            Parolka.ServerData.DataMessage = null;

            List<string> TransferToServerSiteData = new List<string>();
            TransferToServerSiteData.Add(ServiceList.SelectedItem.ToString());
            TransferToServerSiteData.Add(ServiceIP.Text.Trim());
            TransferToServerSiteData.Add(ServiceLogin.Text.Trim());
            TransferToServerSiteData.Add(ServicePassword.Text.Trim());
            TransferToServerSiteData.Add(ServiceComment.Text);

            var SiteInfoToServer = string.Join(",", TransferToServerSiteData);

            ServerData.DataMessage = "QUERY_SERVICE_UPDATE:" + SiteInfoToServer.ToString();

            Server.Server.ParolkaClient();
            if (ServerData.ServMessage == "REPLY_SERVICE_UPDATED")
            {
                MessageBox.Show("Обновлено");
            }
            ServerData.ServMessage = null;
            ServerData.DataMessage = null;

            ServiceIP.ReadOnly = true;
            ServiceLogin.ReadOnly = true;
            ServicePassword.ReadOnly = true;
            ServiceComment.ReadOnly = true;
        }

        private void ServiceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ServiceList.SelectedItem != null)
            {
                ServerData.ServMessage = null;
                ServerData.DataMessage = null;

                ServerData.DataMessage = "QUERY_SERVICE_GET_DESC:" + ServiceList.SelectedItem;

                Server.Server.ParolkaClient();

                List<string> TransferFromServerSiteData = new List<string>();
                string[] SiteData = Parolka.ServerData.ServMessage.Split('|');
                foreach (string id in SiteData)
                {
                    TransferFromServerSiteData.Add(id);
                }

                try
                {
                    ServiceIP.Text = TransferFromServerSiteData[0];
                    ServiceLogin.Text = TransferFromServerSiteData[1];
                    ServicePassword.Text = TransferFromServerSiteData[2];
                    ServiceComment.Text = TransferFromServerSiteData[3];
                }
                catch {}

                SiteData = null;
                TransferFromServerSiteData.Clear();
                Parolka.ServerData.ServMessage = null;
                Parolka.ServerData.DataMessage = null;
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Form Client = new Client();
            Client.Show();

            this.Hide();
        }

        private void ServicesManager_MouseDown(object sender, MouseEventArgs e)
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

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromName("HotTrack");
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

        private void CloseImg_MouseEnter(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.FromName("Highlight");
        }

        private void CloseImg_MouseLeave(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("HotTrack");
        }

        private void CloseImg_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}