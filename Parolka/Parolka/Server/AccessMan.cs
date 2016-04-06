using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Parolka
{
	public partial class AccessMan : Form
	{
        public AccessMan()
		{
			InitializeComponent();
            label3.Text = Parolka.Config.ver;
            Parolka.ServerData.DataMessage = "QUERY_USERMANAGER_GET";
            Parolka.Server.Server.ParolkaClient();

            string[] sitedata = Parolka.ServerData.ServMessage.Split('|');
            foreach (string id in sitedata)
            {
                AllUsersList.Items.Add(id);
            }

            AllowedUsersList.Items.Clear();

            Parolka.ServerData.DataMessage = "QUERY_USERMANAGER_CURRENT_SITE:" + Parolka.MainFormSites.SelectedSite;
            Parolka.Server.Server.ParolkaClient();

            string[] siteusdata = Parolka.ServerData.ServMessage.Split('|');
            foreach (string id in siteusdata)
            {
                AllowedUsersList.Items.Add(id);
            }
		}
        private void AllUsersList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GrantAccess();
        }
        private void AllowedUsersList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RemoveAccess();
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveAccess();
        }
        void GrantAccess()
        {
            MainFormSites.GrantVar = AllUsersList.SelectedItem.ToString();
            if (!AllowedUsersList.Items.Contains(MainFormSites.GrantVar))
            {
                AllowedUsersList.Items.Add(MainFormSites.GrantVar);

                var SitesListToUser = string.Join("|", "QUERY_USERMANAGER_GRANT:", MainFormSites.SelectedSite, MainFormSites.GrantVar);
                ServerData.DataMessage = SitesListToUser;
                Server.Server.ParolkaClient();
            }
        }
        void RemoveAccess()
        {
            MainFormSites.GrantVar = AllowedUsersList.SelectedItem.ToString();
            AllowedUsersList.Items.Remove(AllowedUsersList.SelectedItem);

            var SitesListToUser = string.Join("|", "QUERY_USERMANAGER_REVOKE:", MainFormSites.SelectedSite, Parolka.MainFormSites.GrantVar);
            ServerData.DataMessage = SitesListToUser;
            Server.Server.ParolkaClient();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GrantAccess();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            RemoveAccess();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("HotTrack");
        }

        private void pictureBox17_MouseEnter(object sender, EventArgs e)
        {
            pictureBox17.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox17_MouseLeave(object sender, EventArgs e)
        {
            pictureBox17.BackColor = Color.FromName("HotTrack");
        }

        private void CloseImg_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CloseImg_MouseEnter(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void CloseImg_MouseLeave(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.Red;
        }
	}
}
