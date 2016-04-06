using System.Drawing;

namespace Parolka
{
	partial class BitrixWorker
	{
		private System.ComponentModel.IContainer components = null;
		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
            this.BitrixBrowser = new System.Windows.Forms.WebBrowser();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.CloseImg = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BitrixBrowser
            // 
            this.BitrixBrowser.Location = new Point(0, 30);
            this.BitrixBrowser.MinimumSize = new Size(20, 20);
            this.BitrixBrowser.Name = "BitrixBrowser";
            this.BitrixBrowser.Size = new Size(836, 412);
            this.BitrixBrowser.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = Color.Gainsboro;
            this.label15.Font = new Font("Segoe UI", 12F);
            this.label15.Location = new Point(7, 4);
            this.label15.Name = "label15";
            this.label15.Size = new Size(122, 21);
            this.label15.TabIndex = 35;
            this.label15.Text = "Установка Bitrix";
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = SystemColors.HotTrack;
            this.pictureBox9.Image = global::Parolka.Properties.Resources.appbar_window_minimize;
            this.pictureBox9.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.pictureBox9.Location = new Point(770, 0);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new Size(27, 27);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 33;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            this.pictureBox9.MouseEnter += new System.EventHandler(this.pictureBox9_MouseEnter);
            this.pictureBox9.MouseLeave += new System.EventHandler(this.pictureBox9_MouseLeave);
            // 
            // CloseImg
            // 
            this.CloseImg.BackColor = SystemColors.HotTrack;
            this.CloseImg.Image = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.Location = new Point(799, 0);
            this.CloseImg.Margin = new System.Windows.Forms.Padding(0);
            this.CloseImg.Name = "CloseImg";
            this.CloseImg.Size = new Size(27, 27);
            this.CloseImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseImg.TabIndex = 32;
            this.CloseImg.TabStop = false;
            this.CloseImg.Click += new System.EventHandler(this.CloseImg_Click);
            this.CloseImg.MouseEnter += new System.EventHandler(this.CloseImg_MouseEnter);
            this.CloseImg.MouseLeave += new System.EventHandler(this.CloseImg_MouseLeave);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = Color.Gainsboro;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new Font("Segoe UI", 18F);
            this.textBox3.Location = new Point(0, -1);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(836, 32);
            this.textBox3.TabIndex = 34;
            this.textBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox3_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = SystemColors.HotTrack;
            this.pictureBox1.Image = global::Parolka.Properties.Resources.appbar_database_mysql;
            this.pictureBox1.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.pictureBox1.Location = new Point(741, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(27, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // BitrixWorker
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(836, 444);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.CloseImg);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.BitrixBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BitrixWorker";
            this.Text = "Parolka Bitrix";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.WebBrowser BitrixBrowser;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox CloseImg;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
	}
}
