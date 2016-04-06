using System;
using System.Drawing;
using System.Windows.Forms;

namespace Parolka
{
	public partial class AddSite : Form
	{
        public AddSite()
		{
			InitializeComponent();
		}
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Parolka.ServerData.DataMessage = "QUERY_SITES_ADD_NEW:" + SiteBox.Text.Trim() + ":" + ServerData.UserName;
            Parolka.MainFormSites.AddedSite = Parolka.ServerData.DataMessage;

            Parolka.Server.Server.ParolkaClient();
            if (Parolka.ServerData.ServMessage == "REPLY_SITE_ADDED")
            {
                Parolka.ServerData.ServMessage = null;
                Parolka.ServerData.DataMessage = null;

                SiteBox.Clear();
                status.Text = "Сайт добавлен!";
                status.Visible = true;
            }
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

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromName("HotTrack");
        }
	}
}