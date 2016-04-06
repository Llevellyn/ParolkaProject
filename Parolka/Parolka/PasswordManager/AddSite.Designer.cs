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
    partial class AddSite
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
            this.SiteBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseImg = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SiteBox
            // 
            this.SiteBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SiteBox.Font = new Font("Segoe UI", 15F);
            this.SiteBox.Location = new Point(16, 51);
            this.SiteBox.Name = "SiteBox";
            this.SiteBox.Size = new Size(258, 27);
            this.SiteBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 12F);
            this.label1.Location = new Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new Size(39, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL";
            // 
            // CloseImg
            // 
            this.CloseImg.BackColor = Color.Red;
            this.CloseImg.Image = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.Location = new Point(280, 0);
            this.CloseImg.Margin = new System.Windows.Forms.Padding(0);
            this.CloseImg.Name = "CloseImg";
            this.CloseImg.Size = new Size(27, 27);
            this.CloseImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseImg.TabIndex = 66;
            this.CloseImg.TabStop = false;
            this.CloseImg.Click += new System.EventHandler(this.CloseImg_Click);
            this.CloseImg.MouseEnter += new System.EventHandler(this.CloseImg_MouseEnter);
            this.CloseImg.MouseLeave += new System.EventHandler(this.CloseImg_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = SystemColors.HotTrack;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Parolka.Properties.Resources.appbar_add;
            this.pictureBox1.Location = new Point(280, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(27, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 72;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new Font("Segoe UI", 10F);
            this.status.Location = new Point(12, 81);
            this.status.Name = "status";
            this.status.Size = new Size(46, 19);
            this.status.TabIndex = 73;
            this.status.Text = "status";
            this.status.Visible = false;
            // 
            // AddSite
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(316, 113);
            this.Controls.Add(this.status);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CloseImg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SiteBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddSite";
            this.Text = "Добавить сайт";
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox SiteBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox CloseImg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label status;
	}
}
