using System;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using ComponentAce.Compression.ZipForge;
using System.Threading;

namespace Parolka.Server
{
    static class Updater
    {
        public static void UpdateCheck()
        {
            while (true)
            {
                try
                {
                    string urlAddress = "http://parolka.simpo.biz/ver.html";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream receiveStream = response.GetResponseStream();
                        StreamReader readStream = null;

                        if (response.CharacterSet == null)
                        {
                            readStream = new StreamReader(receiveStream);
                        }
                        else
                        {
                            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                        }

                        Version remoteVersion = new Version(readStream.ReadToEnd());
                        Version thisVersion = new Version(Application.ProductVersion);

                        response.Close();
                        readStream.Close();

                        if (thisVersion < remoteVersion)
                        {
                            ParolkaUpdater();
                        }
                    }
                    Thread.Sleep(240000);
                }
                catch
                {
                }
            }
        }
        public static void ParolkaUpdater()
        {
            string remoteUri = "http://parolka.simpo.biz/";
            string fileName = "Parolka.zip", StringWebResource = null;
            WebClient WebClient = new WebClient();
            StringWebResource = remoteUri + fileName;
            WebClient.DownloadFile(StringWebResource, fileName);

            ZipForge archiver = new ZipForge();

            archiver.FileName = "Parolka.zip";
            archiver.OpenArchive(FileMode.Open);
            archiver.BaseDir = Directory.GetCurrentDirectory();
            archiver.ExtractFiles("*.*");
            archiver.CloseArchive();

            System.Diagnostics.Process.Start("updater.exe");
            Environment.Exit(0);
        }
    }
}
