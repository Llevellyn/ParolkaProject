/*
 * Created by SharpDevelop.
 * User: user
 * Date: 06.10.2015
 * Time: 14:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Drawing;

namespace Parolka
{
    partial class ServicesManager
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
            this.ServiceList = new System.Windows.Forms.ListBox();
            this.ServiceIP = new System.Windows.Forms.TextBox();
            this.ServiceLogin = new System.Windows.Forms.TextBox();
            this.ServicePassword = new System.Windows.Forms.TextBox();
            this.ServiceComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SiteBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CloseImg = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            this.SuspendLayout();
            // 
            // ServiceList
            // 
            this.ServiceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServiceList.Font = new Font("Segoe UI", 11F);
            this.ServiceList.FormattingEnabled = true;
            this.ServiceList.ItemHeight = 20;
            this.ServiceList.Location = new Point(48, 39);
            this.ServiceList.Name = "ServiceList";
            this.ServiceList.ScrollAlwaysVisible = true;
            this.ServiceList.Size = new Size(150, 240);
            this.ServiceList.TabIndex = 0;
            this.ServiceList.SelectedIndexChanged += new System.EventHandler(this.ServiceList_SelectedIndexChanged);
            // 
            // ServiceIP
            // 
            this.ServiceIP.BackColor = Color.WhiteSmoke;
            this.ServiceIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServiceIP.Font = new Font("Segoe UI", 15F);
            this.ServiceIP.Location = new Point(387, 61);
            this.ServiceIP.Name = "ServiceIP";
            this.ServiceIP.ReadOnly = true;
            this.ServiceIP.Size = new Size(175, 27);
            this.ServiceIP.TabIndex = 1;
            // 
            // ServiceLogin
            // 
            this.ServiceLogin.BackColor = Color.WhiteSmoke;
            this.ServiceLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServiceLogin.Font = new Font("Segoe UI", 15F);
            this.ServiceLogin.Location = new Point(387, 111);
            this.ServiceLogin.Name = "ServiceLogin";
            this.ServiceLogin.ReadOnly = true;
            this.ServiceLogin.Size = new Size(177, 27);
            this.ServiceLogin.TabIndex = 2;
            // 
            // ServicePassword
            // 
            this.ServicePassword.BackColor = Color.WhiteSmoke;
            this.ServicePassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServicePassword.Font = new Font("Segoe UI", 15F);
            this.ServicePassword.Location = new Point(387, 164);
            this.ServicePassword.Name = "ServicePassword";
            this.ServicePassword.ReadOnly = true;
            this.ServicePassword.Size = new Size(177, 27);
            this.ServicePassword.TabIndex = 3;
            // 
            // ServiceComment
            // 
            this.ServiceComment.BackColor = Color.WhiteSmoke;
            this.ServiceComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServiceComment.Font = new Font("Segoe UI", 11F);
            this.ServiceComment.Location = new Point(208, 61);
            this.ServiceComment.Multiline = true;
            this.ServiceComment.Name = "ServiceComment";
            this.ServiceComment.ReadOnly = true;
            this.ServiceComment.Size = new Size(174, 218);
            this.ServiceComment.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 11F);
            this.label1.Location = new Point(204, 38);
            this.label1.Name = "label1";
            this.label1.Size = new Size(107, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Комментарий";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI", 11F);
            this.label2.Location = new Point(383, 141);
            this.label2.Name = "label2";
            this.label2.Size = new Size(62, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Segoe UI", 11F);
            this.label3.Location = new Point(383, 91);
            this.label3.Name = "label3";
            this.label3.Size = new Size(52, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Логин";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Segoe UI", 11F);
            this.label4.Location = new Point(383, 38);
            this.label4.Name = "label4";
            this.label4.Size = new Size(53, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "IP/URL";
            // 
            // SiteBox
            // 
            this.SiteBox.BackColor = Color.WhiteSmoke;
            this.SiteBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SiteBox.Font = new Font("Segoe UI", 15F);
            this.SiteBox.Location = new Point(387, 252);
            this.SiteBox.Name = "SiteBox";
            this.SiteBox.Size = new Size(144, 27);
            this.SiteBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Segoe UI", 11F);
            this.label5.Location = new Point(383, 229);
            this.label5.Name = "label5";
            this.label5.Size = new Size(112, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Новый сервис:";
            // 
            // CloseImg
            // 
            this.CloseImg.BackColor = SystemColors.HotTrack;
            this.CloseImg.Image = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.Location = new Point(535, 0);
            this.CloseImg.Margin = new System.Windows.Forms.Padding(0);
            this.CloseImg.Name = "CloseImg";
            this.CloseImg.Size = new Size(27, 27);
            this.CloseImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseImg.TabIndex = 37;
            this.CloseImg.TabStop = false;
            this.CloseImg.Click += new System.EventHandler(this.CloseImg_Click);
            this.CloseImg.MouseEnter += new System.EventHandler(this.CloseImg_MouseEnter);
            this.CloseImg.MouseLeave += new System.EventHandler(this.CloseImg_MouseLeave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = Color.WhiteSmoke;
            this.label15.Font = new Font("Segoe UI", 12F);
            this.label15.Location = new Point(4, 5);
            this.label15.Name = "label15";
            this.label15.Size = new Size(87, 21);
            this.label15.TabIndex = 36;
            this.label15.Text = "Parolka 2.0";
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
            this.textBox3.Size = new Size(571, 32);
            this.textBox3.TabIndex = 35;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = SystemColors.HotTrack;
            this.pictureBox1.Image = global::Parolka.Properties.Resources.appbar_add;
            this.pictureBox1.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.pictureBox1.Location = new Point(535, 252);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(27, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.AddButton_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = SystemColors.HotTrack;
            this.pictureBox2.Image = global::Parolka.Properties.Resources.appbar_edit;
            this.pictureBox2.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.pictureBox2.Location = new Point(8, 162);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(27, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.ChangeButton_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = SystemColors.HotTrack;
            this.pictureBox3.Image = global::Parolka.Properties.Resources.appbar_save;
            this.pictureBox3.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.pictureBox3.Location = new Point(8, 192);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(27, 27);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 40;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.SaveButton_Click);
            this.pictureBox3.MouseEnter += new System.EventHandler(this.pictureBox3_MouseEnter);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = SystemColors.HotTrack;
            this.pictureBox4.Image = global::Parolka.Properties.Resources.appbar_cancel;
            this.pictureBox4.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.pictureBox4.Location = new Point(8, 222);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new Size(27, 27);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 41;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.CancelButton_Click);
            this.pictureBox4.MouseEnter += new System.EventHandler(this.pictureBox4_MouseEnter);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = SystemColors.HotTrack;
            this.pictureBox5.Image = global::Parolka.Properties.Resources.appbar_delete;
            this.pictureBox5.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.pictureBox5.Location = new Point(8, 252);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new Size(27, 27);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 42;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.RemoveButton_Click);
            this.pictureBox5.MouseEnter += new System.EventHandler(this.pictureBox5_MouseEnter);
            this.pictureBox5.MouseLeave += new System.EventHandler(this.pictureBox5_MouseLeave);
            // 
            // pictureBox16
            // 
            this.pictureBox16.BackColor = SystemColors.HotTrack;
            this.pictureBox16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox16.Image = global::Parolka.Properties.Resources.appbar_arrow_left;
            this.pictureBox16.Location = new Point(8, 39);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new Size(27, 27);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox16.TabIndex = 69;
            this.pictureBox16.TabStop = false;
            this.pictureBox16.Click += new System.EventHandler(this.pictureBox16_Click);
            this.pictureBox16.MouseEnter += new System.EventHandler(this.pictureBox16_MouseEnter);
            this.pictureBox16.MouseLeave += new System.EventHandler(this.pictureBox16_MouseLeave);
            // 
            // ServicesManager
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(571, 296);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CloseImg);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SiteBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServiceComment);
            this.Controls.Add(this.ServicePassword);
            this.Controls.Add(this.ServiceLogin);
            this.Controls.Add(this.ServiceIP);
            this.Controls.Add(this.ServiceList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServicesManager";
            this.Text = "Сервисы и сайты";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ServicesManager_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox ServiceList;
        private System.Windows.Forms.TextBox ServiceIP;
        private System.Windows.Forms.TextBox ServiceLogin;
        private System.Windows.Forms.TextBox ServicePassword;
        private System.Windows.Forms.TextBox ServiceComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SiteBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox CloseImg;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox16;
    }
}
