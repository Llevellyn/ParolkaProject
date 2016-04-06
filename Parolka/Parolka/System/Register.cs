/*
 * Created by SharpDevelop.
 * User: user
 * Date: 06.10.2015
 * Time: 14:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Parolka
{
	/// <summary>
	/// Description of Form7.
	/// </summary>
	public partial class Register : Form
	{
        public Register()
		{
            InitializeComponent();

            //this.KeyPreview = true;
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
		}
        //private void Login_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        LoginButtonPressed();      
        //}
        //private void LoginButton_Click(object sender, EventArgs e)
        //{
        //    LoginButtonPressed();
        //}
        //void LoginButtonPressed()
        //{
        //    PasswordManager.LoginData.UserLogin = Login.Text;

        //    Login.Enabled = false;
        //    Password.Enabled = false;
        //    LoginButton.Enabled = false;

        //    string Query = "SELECT login FROM users WHERE login = " + "'" + Login.Text + "'";
        //    using (MySqlConnection conDataBase = new MySqlConnection(PasswordManager.MysqlConnectData.constring))
        //    using (MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase))
        //    {
        //        try
        //        {
        //            conDataBase.Open();
        //            using (MySqlDataReader reader = cmdDataBase.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    if (Login.Text == reader[0].ToString())
        //                    {
        //                        TryLogin();
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Wrong User");
        //                        Login.Enabled = true;
        //                        Password.Enabled = true;
        //                        LoginButton.Enabled = true;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            Login.Enabled = true;
        //            Password.Enabled = true;
        //            LoginButton.Enabled = true;
        //        }
        //    }
        //}
        //void TryLogin()
        //{
        //    string Query = "SELECT password,role FROM users WHERE login = " + "'" + Login.Text + "'";
        //    using (MySqlConnection conDataBase = new MySqlConnection(PasswordManager.MysqlConnectData.constring))
        //    using (MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase))
        //    {
        //        try
        //        {
        //            conDataBase.Open();
        //            using (MySqlDataReader reader = cmdDataBase.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    if (Password.Text == ((string)reader[0]))
        //                    {
        //                        PasswordManager.LoginData.UserRole = (string)reader[1];
        //                        Form MainForm = new MainForm();
        //                        MainForm.Show();

        //                        this.Hide();
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Wrong Password");
        //                        Login.Enabled = true;
        //                        Password.Enabled = true;
        //                        LoginButton.Enabled = true;
        //                    }
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            Login.Enabled = true;
        //            Password.Enabled = true;
        //            LoginButton.Enabled = true;
        //        }
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {

        }
	}
}
