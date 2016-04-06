using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.DirectoryServices;
using System.IO;
using Microsoft.Win32;
using ComponentAce.Compression.Archiver;
using ComponentAce.Compression.ZipForge;
using System.Threading;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace Parolka.AddOns
{
    class Unpacker
    {
        public static void PSInstaller(object principalObj)
        {
            Microsoft.Win32.RegistryKey UserRegCurUs = Microsoft.Win32.Registry.CurrentUser;
            try
            {
                UserRegCurUs.DeleteSubKeyTree(@"SOFTWARE\Adobe");
                UserRegCurUs.Close();
            }
            catch
            {
            }
            if (File.Exists("Photozhop.zip"))
            {
                ZipForge archiver = new ZipForge();

                System.IO.Directory.CreateDirectory("Photoshop");
                archiver.FileName = "Photozhop.zip";
                archiver.OpenArchive(System.IO.FileMode.Open);
                archiver.BaseDir = Directory.GetCurrentDirectory() + "\\Photoshop";
                archiver.ExtractFiles("*.*");
                archiver.CloseArchive();

                System.IO.File.Delete("Photozhop.zip");
            }
            
            Parolka.Server.BeAdmin.LogIn();
        }
    }
}