/*
 * Created by SharpDevelop.
 * User: user
 * Date: 06.10.2015
 * Time: 14:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Drawing;

namespace Parolka
{
	partial class UserMan
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMan));
            this.UserBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Права = new System.Windows.Forms.GroupBox();
            this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
            this.radioButtonUser = new System.Windows.Forms.RadioButton();
            this.ChangePermsButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.CloseImg = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Права.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // UserBox
            // 
            this.UserBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserBox.Font = new Font("Segoe UI", 10F);
            this.UserBox.FormattingEnabled = true;
            this.UserBox.ItemHeight = 17;
            this.UserBox.Location = new Point(9, 59);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new Size(177, 289);
            this.UserBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 12F);
            this.label1.Location = new Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new Size(110, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пользователи";
            // 
            // Права
            // 
            this.Права.Controls.Add(this.radioButtonAdmin);
            this.Права.Controls.Add(this.radioButtonUser);
            this.Права.Controls.Add(this.ChangePermsButton);
            this.Права.Enabled = false;
            this.Права.Font = new Font("Segoe UI", 12F);
            this.Права.Location = new Point(194, 142);
            this.Права.Name = "Права";
            this.Права.Size = new Size(156, 131);
            this.Права.TabIndex = 5;
            this.Права.TabStop = false;
            this.Права.Text = "Права";
            this.Права.Visible = false;
            // 
            // radioButtonAdmin
            // 
            this.radioButtonAdmin.AutoSize = true;
            this.radioButtonAdmin.Location = new Point(7, 43);
            this.radioButtonAdmin.Name = "radioButtonAdmin";
            this.radioButtonAdmin.Size = new Size(54, 25);
            this.radioButtonAdmin.TabIndex = 2;
            this.radioButtonAdmin.TabStop = true;
            this.radioButtonAdmin.Text = "null";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // radioButtonUser
            // 
            this.radioButtonUser.AutoSize = true;
            this.radioButtonUser.Location = new Point(7, 20);
            this.radioButtonUser.Name = "radioButtonUser";
            this.radioButtonUser.Size = new Size(54, 25);
            this.radioButtonUser.TabIndex = 1;
            this.radioButtonUser.TabStop = true;
            this.radioButtonUser.Text = "null";
            this.radioButtonUser.UseVisualStyleBackColor = true;
            // 
            // ChangePermsButton
            // 
            this.ChangePermsButton.Location = new Point(7, 74);
            this.ChangePermsButton.Name = "ChangePermsButton";
            this.ChangePermsButton.Size = new Size(121, 51);
            this.ChangePermsButton.TabIndex = 0;
            this.ChangePermsButton.Text = "Изменить";
            this.ChangePermsButton.UseVisualStyleBackColor = true;
            this.ChangePermsButton.Click += new System.EventHandler(this.ChangePermsButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTextBox.Font = new Font("Segoe UI", 14F);
            this.PasswordTextBox.Location = new Point(194, 111);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new Size(210, 25);
            this.PasswordTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI", 12F);
            this.label2.Location = new Point(190, 87);
            this.label2.Name = "label2";
            this.label2.Size = new Size(136, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Изменить пароль";
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginTextBox.Font = new Font("Segoe UI", 14F);
            this.LoginTextBox.Location = new Point(194, 59);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new Size(210, 25);
            this.LoginTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Segoe UI", 12F);
            this.label3.Location = new Point(190, 35);
            this.label3.Name = "label3";
            this.label3.Size = new Size(169, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Создать пользователя";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = Color.WhiteSmoke;
            this.label15.Font = new Font("Segoe UI", 12F);
            this.label15.Location = new Point(5, 4);
            this.label15.Name = "label15";
            this.label15.Size = new Size(87, 21);
            this.label15.TabIndex = 36;
            this.label15.Text = "Parolka 2.0";
            // 
            // CloseImg
            // 
            this.CloseImg.BackColor = Color.Red;
            this.CloseImg.Image = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.Location = new Point(410, 0);
            this.CloseImg.Margin = new System.Windows.Forms.Padding(0);
            this.CloseImg.Name = "CloseImg";
            this.CloseImg.Size = new Size(25, 25);
            this.CloseImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseImg.TabIndex = 34;
            this.CloseImg.TabStop = false;
            this.CloseImg.Click += new System.EventHandler(this.CloseImg_Click);
            this.CloseImg.MouseEnter += new System.EventHandler(this.CloseImg_MouseEnter);
            this.CloseImg.MouseLeave += new System.EventHandler(this.CloseImg_MouseLeave);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = Color.WhiteSmoke;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new Font("Segoe UI", 18F);
            this.textBox3.Location = new Point(0, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(446, 32);
            this.textBox3.TabIndex = 35;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = SystemColors.HotTrack;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Parolka.Properties.Resources.appbar_add;
            this.pictureBox3.Location = new Point(410, 59);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 37;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.MouseEnter += new System.EventHandler(this.pictureBox3_MouseEnter);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = SystemColors.HotTrack;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Parolka.Properties.Resources.appbar_arrow_right;
            this.pictureBox1.Location = new Point(410, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = SystemColors.HotTrack;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Parolka.Properties.Resources.appbar_delete;
            this.pictureBox2.Location = new Point(194, 308);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // UserMan
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(446, 373);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.CloseImg);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.Права);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserMan";
            this.Text = "Управление пользователями";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserMan_MouseDown);
            this.Права.ResumeLayout(false);
            this.Права.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.ListBox UserBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Права;
        private System.Windows.Forms.RadioButton radioButtonAdmin;
        private System.Windows.Forms.RadioButton radioButtonUser;
        private System.Windows.Forms.Button ChangePermsButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox CloseImg;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
	}
}
