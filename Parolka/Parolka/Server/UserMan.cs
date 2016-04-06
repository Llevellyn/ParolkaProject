using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace Parolka
{
	public partial class UserMan : Form
	{
		public UserMan()
		{
			InitializeComponent();
            label15.Text = Parolka.Config.ver;
            GetUsers();
		}
        void GetUsers()
        {
            UserBox.Items.Clear();
            Parolka.ServerData.DataMessage = "USERMAN_GET_USERS:";
            Parolka.Server.Server.ParolkaClient();

            string[] sitedata = Parolka.ServerData.ServMessage.Split('|');
            foreach (string id in sitedata)
            {
                UserBox.Items.Add(id);
            }
        }
        private void NewUserButton_Click(object sender, EventArgs e)
        {

        }
        private void RemoveUserButton_Click(object sender, EventArgs e)
        {

        }
        private void ResetPasswordButton_Click(object sender, EventArgs e)
        {

        }
        private void ChangePermsButton_Click(object sender, EventArgs e)
        {
            if (radioButtonAdmin.Checked)
            {
                var updatePass = String.Join("|", "USERMAN_ROLE:", UserBox.SelectedItem.ToString(), "admin");

                Parolka.ServerData.DataMessage = updatePass;
                Parolka.Server.Server.ParolkaClient();
            }
            if (radioButtonUser.Checked)
            {
                var updatePass = String.Join("|", "USERMAN_ROLE:", UserBox.SelectedItem.ToString(), "user");

                Parolka.ServerData.DataMessage = updatePass;
                Parolka.Server.Server.ParolkaClient();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Parolka.ServerData.DataMessage = "QUERY_USERMANAGER_CREATE_USER:" + LoginTextBox.Text;
            Parolka.Server.Server.ParolkaClient();
            GetUsers();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes("_p" + PasswordTextBox.Text.ToString()));
            string pass = BitConverter.ToString(checkSum).Replace("-", String.Empty).ToLower();

            var updatePass = String.Join("|", "QUERY_USERMANAGER_UPDATE_PASSWORD:", UserBox.SelectedItem.ToString(), pass);

            Parolka.ServerData.DataMessage = updatePass;
            Parolka.Server.Server.ParolkaClient();

            PasswordTextBox.Clear();

            MessageBox.Show("Пароль изменен");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && UserBox.SelectedItem != null)
            {
                Parolka.ServerData.DataMessage = "QUERY_USERMANAGER_REMOVE_USER:" + UserBox.SelectedItem.ToString();
                Parolka.Server.Server.ParolkaClient();
                GetUsers();
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

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName("Highlight");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName("HotTrack");
        }

        private void UserMan_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Message n = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref n);
        }
	}
}
