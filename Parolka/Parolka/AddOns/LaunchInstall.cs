using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.IO;

namespace Parolka.Server
{
    public static class BeAdmin
    {
        public static void LogIn()
        {
            ImpersonateUser iu = new ImpersonateUser();
            iu.Impersonate(System.Environment.UserDomainName.ToString(), "sa", "simpoadminpassword");

            OperatingSystem OS = Environment.OSVersion;
            if (OS.Version.Major > 5.9)
            {
                // =============== using cleaner ===============
                System.Threading.Thread.Sleep(2000);
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C Photoshop\\uninstaller.exe --removeAll=CREATIVECLOUDCS6PRODUCTS";
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                // =============== try to delete files ===============
                System.Threading.Thread.Sleep(2000);
                string[] filePaths = Directory.GetDirectories(@"c:\Users");
                string[] winNEWER = { "C:", "Users", "AppData", "Local", "Roaming", "Program Files", "Program Files (x86)", "Common Files", "ProgramData", "Adobe" };
                for (int i = 0; i < filePaths.Length; i++)
                {
                    try
                    {
                        DirectoryInfo localset = new DirectoryInfo(@"" + filePaths[i] + "\\" + winNEWER[2] + "\\" + winNEWER[3] + "\\" + winNEWER[9]);
                        localset.Delete(true);
                    }
                    catch
                    {
                    }
                    try
                    {
                        DirectoryInfo localset = new DirectoryInfo(@"" + filePaths[i] + "\\" + winNEWER[2] + "\\" + winNEWER[4] + "\\" + winNEWER[9]);
                        localset.Delete(true);
                    }
                    catch
                    {
                    }
                }
                try
                {
                    DirectoryInfo localset = new DirectoryInfo(@"" + winNEWER[0] + "\\" + winNEWER[8] + "\\" + winNEWER[9]);
                    localset.Delete(true);
                }
                catch
                {
                }
                try
                {
                    DirectoryInfo localset = new DirectoryInfo(@"" + winNEWER[0] + "\\" + winNEWER[5] + "\\" + winNEWER[9]);
                    localset.Delete(true);
                }
                catch
                {
                }
                try
                {
                    DirectoryInfo localset = new DirectoryInfo(@"" + winNEWER[0] + "\\" + winNEWER[6] + "\\" + winNEWER[9]);
                    localset.Delete(true);
                }
                catch
                {
                }
                try
                {
                    DirectoryInfo localset = new DirectoryInfo(@"" + winNEWER[0] + "\\" + winNEWER[5] + "\\" + winNEWER[7] + "\\" + winNEWER[9]);
                    localset.Delete(true);
                }
                catch
                {
                }
                try
                {
                    DirectoryInfo localset = new DirectoryInfo(@"" + winNEWER[0] + "\\" + winNEWER[6] + "\\" + winNEWER[7] + "\\" + winNEWER[9]);
                    localset.Delete(true);
                }
                catch
                {
                }

                // =============== cleaning registry ===============
                try
                {
                    Microsoft.Win32.RegistryKey AdminRegLocMach = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\", true);
                    AdminRegLocMach.DeleteSubKeyTree("Adobe");
                    AdminRegLocMach.Close();
                }
                catch
                {
                }

                Microsoft.Win32.RegistryKey UserRegCurUs = Microsoft.Win32.Registry.CurrentUser;
                try
                {
                    UserRegCurUs.DeleteSubKeyTree(@"SOFTWARE\Adobe");
                    UserRegCurUs.Close();
                }
                catch
                {
                }

                // =============== installing ===============
                System.Threading.Thread.Sleep(2000);
                System.Diagnostics.Process processInstall = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInstall = new System.Diagnostics.ProcessStartInfo();
                startInstall.FileName = "cmd.exe";
                startInstall.Arguments = "/C" + Directory.GetCurrentDirectory() + "\\Photoshop\\Set-up.exe --mode=Silent --deploymentFile=" + Directory.GetCurrentDirectory() + "\\Photoshop\\install.xml --overrideFile=" + Directory.GetCurrentDirectory() + "\\Photoshop\\application.xml.override";
                processInstall.StartInfo = startInstall;
                processInstall.Start();
                processInstall.WaitForExit();
            }
            else
            {
                // =============== using cleaner ===============
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C" + Directory.GetCurrentDirectory() + "\\Photoshop\\uninstaller.exe --removeAll=CREATIVECLOUDCS6PRODUCTS";
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                System.Threading.Thread.Sleep(2000);
                // =============== try to delete files ===============

                string[] filePaths = Directory.GetDirectories(@"c:\Documents and Settings");
                string[] winXP = { "C:", "Documents and Settings", "Application Data", "Local Settings", "Program Files", "Common Files", "Adobe" };
                for (int i = 0; i < filePaths.Length; i++)
                {
                    // APPDATA
                    try
                    {
                        DirectoryInfo localset = new DirectoryInfo(@"" + filePaths[i] + "\\" + winXP[3] + "\\" + winXP[2] + "\\" + winXP[6] + "\\");
                        localset.Delete(true);
                    }
                    catch
                    {
                    }
                    // LOCALSET
                    System.Threading.Thread.Sleep(2000);
                    try
                    {
                        DirectoryInfo appdata = new DirectoryInfo(@"" + filePaths[i] + "\\" + winXP[2] + "\\" + winXP[6] + "\\");
                        appdata.Delete(true);
                    }
                    catch
                    {
                    }
                }
                // PROGFILES
                try
                {
                    DirectoryInfo localset = new DirectoryInfo(@"" + winXP[0] + "\\" + winXP[4] + "\\" + winXP[6] + "\\");
                    localset.Delete(true);
                }
                catch
                {
                }
                System.Threading.Thread.Sleep(2000);
                // COMMONFILES
                try
                {
                    DirectoryInfo appdata = new DirectoryInfo(@"" + winXP[0] + "\\" + winXP[4] + "\\" + winXP[5] + "\\" + winXP[6] + "\\");
                    appdata.Delete(true);
                }
                catch
                {
                }
                System.Threading.Thread.Sleep(2000);
                // =============== cleaning registry ===============
                Microsoft.Win32.RegistryKey UserRegCurUs = Microsoft.Win32.Registry.CurrentUser;
                try
                {
                    UserRegCurUs.DeleteSubKeyTree(@"SOFTWARE\Adobe");
                    UserRegCurUs.Close();
                }
                catch
                {
                }
                System.Threading.Thread.Sleep(2000);
                try
                {
                    Microsoft.Win32.RegistryKey AdminRegLocMach = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\", true);
                    AdminRegLocMach.DeleteSubKeyTree("Adobe");
                    AdminRegLocMach.Close();
                }
                catch
                {
                }
                // =============== installing ===============
                System.Threading.Thread.Sleep(2000);
                System.Diagnostics.Process processInstall = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInstall = new System.Diagnostics.ProcessStartInfo();
                startInstall.FileName = "cmd.exe";
                startInstall.Arguments = "/C" + Directory.GetCurrentDirectory() + "\\Photoshop\\set-up.exe --mode=Silent --deploymentFile=" + Directory.GetCurrentDirectory() + "\\Photoshop\\install.xml --overrideFile=" + Directory.GetCurrentDirectory() + "\\Photoshop\\application.xml.override";
                processInstall.StartInfo = startInstall;
                processInstall.Start();
                processInstall.WaitForExit();
            }

            iu.Undo();
        }
    }
    public class ImpersonateUser
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(
        String lpszUsername,
        String lpszDomain,
        String lpszPassword,
        int dwLogonType,
        int dwLogonProvider,
        ref IntPtr phToken);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
        private static IntPtr tokenHandle = new IntPtr(0);
        private static WindowsImpersonationContext impersonatedUser;

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public void Impersonate(string domainName, string userName, string password)
        {
            {
                // Use the unmanaged LogonUser function to get the user token for
                // the specified user, domain, and password.
                const int LOGON32_PROVIDER_DEFAULT = 0;
                // Passing this parameter causes LogonUser to create a primary token.
                const int LOGON32_LOGON_INTERACTIVE = 2;
                tokenHandle = IntPtr.Zero;
                // ---- Step - 1
                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = LogonUser(
                userName,
                domainName,
                password,
                LOGON32_LOGON_INTERACTIVE,
                LOGON32_PROVIDER_DEFAULT,
                ref tokenHandle); // tokenHandle - new security token
                if (false == returnValue)
                {
                    int ret = Marshal.GetLastWin32Error();                   
                    throw new System.ComponentModel.Win32Exception(ret);
                }
                // ---- Step - 2
                WindowsIdentity newId = new WindowsIdentity(tokenHandle);
                // ---- Step - 3
                impersonatedUser = newId.Impersonate();
            }
        }
        // Stops impersonation
        public void Undo()
        {
            impersonatedUser.Undo();
            // Free the tokens.
            if (tokenHandle != IntPtr.Zero)
                CloseHandle(tokenHandle);
        }
    }
}