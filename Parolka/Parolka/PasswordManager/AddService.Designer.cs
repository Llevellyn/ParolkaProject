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
	partial class AddService
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
            this.AddSiteButton = new System.Windows.Forms.Button();
            this.SiteBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddSiteButton
            // 
            this.AddSiteButton.Location = new Point(229, 12);
            this.AddSiteButton.Name = "AddSiteButton";
            this.AddSiteButton.Size = new Size(75, 41);
            this.AddSiteButton.TabIndex = 0;
            this.AddSiteButton.Text = "Добавить";
            this.AddSiteButton.UseVisualStyleBackColor = true;
            this.AddSiteButton.Click += new System.EventHandler(this.AddSiteButton_Click);
            // 
            // SiteBox
            // 
            this.SiteBox.Location = new Point(12, 31);
            this.SiteBox.Name = "SiteBox";
            this.SiteBox.Size = new Size(192, 20);
            this.SiteBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название";
            // 
            // AddService
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(316, 65);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SiteBox);
            this.Controls.Add(this.AddSiteButton);
            this.Name = "AddService";
            this.Text = "Добавить сайт";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.Button AddSiteButton;
        private System.Windows.Forms.TextBox SiteBox;
        private System.Windows.Forms.Label label1;
	}
}
