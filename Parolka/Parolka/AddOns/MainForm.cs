using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.DirectoryServices;
using System.IO;
using Microsoft.Win32;
using System.ServiceProcess;
using ComponentAce.Compression.Archiver;
using ComponentAce.Compression.ZipForge;
using System.Threading;
using System.ComponentModel;

namespace PhotoshopUninstaller
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

            string WinVer = Environment.OSVersion.ToString();

            string driveLetter = Path.GetPathRoot(Environment.CurrentDirectory);

            DriveInfo di = new DriveInfo(@driveLetter);
            double Ffree = (di.AvailableFreeSpace / 1024) / 1024;
            int FreeSpace = System.Int32.Parse(Ffree.ToString());

            if (FreeSpace > 7000 && !Directory.Exists("Photoshop"))
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                Uri uri = new Uri("http://parolka.simpo.biz/Photozhop.zip");
                webClient.DownloadFileAsync(uri, @"Photozhop.zip");
                webClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Downloaded);
            }
            if (Directory.Exists("Photoshop"))
            {
                label1.Text = "Установка...";
                Thread newThread = new Thread(Parolka.AddOns.Unpacker.PSInstaller);
                newThread.Start(1);
            }
		}
        void webClient_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            label1.Text = e.ProgressPercentage.ToString() + "% загружено";
        }
        void Downloaded(object sender, AsyncCompletedEventArgs e)
        {
            Thread newThread = new Thread(Parolka.AddOns.Unpacker.PSInstaller);
            newThread.Start(1);
            label1.Text = "Установка...";
        }

        private void CloseImg_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CloseImg_MouseEnter(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.FromName("Highlight");
        }

        private void CloseImg_MouseLeave(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.FromName("HotTrack");
        }
	}
}