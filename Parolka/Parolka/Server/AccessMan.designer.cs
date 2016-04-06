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
    partial class AccessMan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessMan));
            this.AllowedUsersList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AllUsersList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CloseImg = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AllowedUsersList
            // 
            this.AllowedUsersList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AllowedUsersList.Font = new Font("Segoe UI", 10F);
            this.AllowedUsersList.FormattingEnabled = true;
            this.AllowedUsersList.ItemHeight = 17;
            this.AllowedUsersList.Location = new Point(27, 72);
            this.AllowedUsersList.Name = "AllowedUsersList";
            this.AllowedUsersList.Size = new Size(140, 204);
            this.AllowedUsersList.TabIndex = 0;
            this.AllowedUsersList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AllowedUsersList_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 12F);
            this.label1.Location = new Point(23, 48);
            this.label1.Name = "label1";
            this.label1.Size = new Size(112, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Разрешенные:";
            // 
            // AllUsersList
            // 
            this.AllUsersList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AllUsersList.Font = new Font("Segoe UI", 10F);
            this.AllUsersList.FormattingEnabled = true;
            this.AllUsersList.ItemHeight = 17;
            this.AllUsersList.Location = new Point(229, 72);
            this.AllUsersList.Name = "AllUsersList";
            this.AllUsersList.Size = new Size(141, 204);
            this.AllUsersList.TabIndex = 2;
            this.AllUsersList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AllUsersList_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI", 12F);
            this.label2.Location = new Point(225, 48);
            this.label2.Name = "label2";
            this.label2.Size = new Size(37, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Все:";
            // 
            // CloseImg
            // 
            this.CloseImg.BackColor = Color.Red;
            this.CloseImg.Image = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.Location = new Point(364, 0);
            this.CloseImg.Margin = new System.Windows.Forms.Padding(0);
            this.CloseImg.Name = "CloseImg";
            this.CloseImg.Size = new Size(27, 27);
            this.CloseImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseImg.TabIndex = 65;
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
            this.textBox3.Size = new Size(400, 32);
            this.textBox3.TabIndex = 66;
            // 
            // pictureBox17
            // 
            this.pictureBox17.BackColor = SystemColors.HotTrack;
            this.pictureBox17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox17.Image = global::Parolka.Properties.Resources.appbar_arrow_right;
            this.pictureBox17.Location = new Point(173, 178);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new Size(50, 98);
            this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox17.TabIndex = 70;
            this.pictureBox17.TabStop = false;
            this.pictureBox17.Click += new System.EventHandler(this.pictureBox17_Click);
            this.pictureBox17.MouseEnter += new System.EventHandler(this.pictureBox17_MouseEnter);
            this.pictureBox17.MouseLeave += new System.EventHandler(this.pictureBox17_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = SystemColors.HotTrack;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Parolka.Properties.Resources.appbar_arrow_left;
            this.pictureBox1.Location = new Point(173, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(50, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = Color.WhiteSmoke;
            this.label3.Font = new Font("Segoe UI", 12F);
            this.label3.Location = new Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new Size(62, 21);
            this.label3.TabIndex = 72;
            this.label3.Text = "Parolka";
            // 
            // AccessMan
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(400, 300);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox17);
            this.Controls.Add(this.CloseImg);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AllUsersList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AllowedUsersList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccessMan";
            this.Text = "Управление пользователями";
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox AllowedUsersList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox AllUsersList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox CloseImg;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}
