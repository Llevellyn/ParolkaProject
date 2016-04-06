using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace ParolkaServer
{
    public class DownUploader
    {
        public static void downloadFileFromHTTP()
        {
            string remoteUri = ParolkaServer.fileData.URi;
            string fileName = ParolkaServer.fileData.TransferFileName, myStringWebResource = null;
            WebClient myWebClient = new WebClient();
            myStringWebResource = remoteUri + fileName;
            myWebClient.DownloadFile(myStringWebResource, fileName);
        }
        public static void uploadFile()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + ParolkaServer.fileData.URi + ParolkaServer.fileData.TransferFileName);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            StreamReader sourceStream = new StreamReader(ParolkaServer.fileData.TransferFileName);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            response.Close();
        }
    }
    static class fileData
    {
        public static string URi;

        public static string TransferFileName;
        public static string TransferError;

        public static string TransferToServer;
        public static string TransferFromServer;
    }
}
