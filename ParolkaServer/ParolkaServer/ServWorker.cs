using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace ParolkaServer
{
    class ServWorker
    {
        static string SitesCost;
        static string ReceivedDataRoleGetSites;
        static int SitesArrayCost;
        static string ReceivedDataLogin;
        static string ReceivedDataPassword;
        static string ClientUserRole;

        public static void SocketConnect()
        {
            while (true)
            {
                Console.WriteLine("Port Listened: " + connectData.ipEndPoint + "\n");
                Socket handler = connectData.sListener.Accept();
                Console.WriteLine("Connected from " + connectData.ipEndPoint.ToString() + "\n");

                Thread SqlSelectSingle = new Thread(SQL.SqlSelectSingle);
                Thread SqlSelectSingleSecond = new Thread(SQL.SqlSelectSingle);
                Thread SqlSelectMultiple = new Thread(SQL.SqlSelectMultiple);
                Thread SqlSelectRows = new Thread(SQL.SqlSelectRows);
                Thread SqlSelectBilling = new Thread(SQL.SqlSelectBilling);
                Thread SqlSelectDesc = new Thread(SQL.SqlSelectDesc);
                Thread SqlSelectServices = new Thread(SQL.SqlSelectServices);
                Thread SqlInsert = new Thread(SQL.SqlInsert);
                Thread SqlDelete = new Thread(SQL.SqlDelete);
                Thread SqlUpdate = new Thread(SQL.SqlUpdate);
                Thread SqlUpdateSecond = new Thread(SQL.SqlUpdate);

                try
                {
                    byte[] bytes = new byte[2048];
                    int bytesRec = handler.Receive(bytes);

                    string ClientMessage = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    string ClientQuery = null; 

                    if (ClientMessage.Contains(":"))
                    {
                        ClientQuery = ClientMessage.Substring(ClientMessage.IndexOf(':') + 1);
                    }
                    Console.WriteLine("Received message " + ClientMessage + "\n");

                    // SERVER TEST
                    if (ClientMessage.Contains("QUERY_PING"))
                    {
                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_PONG");
                        handler.Send(msg);
                        Console.WriteLine("QUERY_PING");
                    }
                    // LOGIN FLAG
                    if (ClientMessage.Contains("QUERY_USER_LOGIN"))
                    {
                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_USER_LOGIN_ACCEPTED");
                        handler.Send(msg);
                    }
                    // AUTH FLAG, TEST USER IN DB
                    if (ClientMessage.Contains("QUERY_USER_AUTH_LOGIN"))
                    {
                        ReceivedDataLogin = ClientQuery;

                        string req = "SELECT login FROM users WHERE login = " + "'" + ReceivedDataLogin + "'";

                        Console.WriteLine(ReceivedDataLogin + " auth request;\n");

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();

                        string LoginFromDB = MysqlData.TransferFromServerSingle;
                        if (LoginFromDB == ReceivedDataLogin)
                        {
                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_USER_AUTH_LOGIN_CORRECT");

                            Console.WriteLine(ReceivedDataLogin + " found in database;\n");

                            handler.Send(msg);
                        }
                        else
                        {
                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_USER_AUTH_LOGIN_INCORRECT");
                            handler.Send(msg);
                        }
                    }
                    //// PASSWORD FLAG, VERIFY PASSWORD
                    if (ClientMessage.Contains("QUERY_USER_AUTH_PASSWORD"))
                    {
                        ReceivedDataPassword = ClientQuery;
                        string req = "SELECT password FROM users WHERE login = " + "'" + ReceivedDataLogin + "'";

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();

                        string PasswordFromDB = MysqlData.TransferFromServerSingle.ToString();

                        if (PasswordFromDB == ReceivedDataPassword)
                        {
                            Console.WriteLine(ReceivedDataLogin + " password correct\n");
                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_USER_AUTH_PASSWORD_CORRECT");
                            handler.Send(msg);

                        }
                        else
                        {
                            Console.WriteLine(ReceivedDataLogin + " password incorrect\n");
                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_USER_AUTH_PASSWORD_INCORRECT");
                            handler.Send(msg);
                        }
                    }
                    // GET ROLE USER
                    if (ClientMessage.Contains("QUERY_USER_ROLE"))
                    {
                        string req = "SELECT role FROM users WHERE login = '" + ReceivedDataLogin + "'";

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();

                        ClientUserRole = MysqlData.TransferFromServerSingle;

                        if (ClientUserRole == "admin")
                        {
                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_USER_ROLE:admin");
                            Console.WriteLine(ReceivedDataLogin + " logged in;\n");
                            handler.Send(msg);
                        }
                        if (ClientUserRole == "user")
                        {
                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_USER_ROLE:user");
                            Console.WriteLine(ReceivedDataLogin + " logged in;\n");
                            handler.Send(msg);
                        }
                        if (ClientUserRole == "manager")
                        {
                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_USER_ROLE:BILLING");
                            Console.WriteLine(ReceivedDataLogin + " logged in;\n");
                            handler.Send(msg);
                        }
                    }
                    //
                    // BILLING
                    //
                    // QUERY TO GET COUNT OF BILLING RECORDS
                    // QUERY TO GET COUNT OF SERVICES
                    if (ClientMessage.Contains("QUERY_BILLING_SERVICES_COUNT"))
                    {
                        try
                        {
                            string req = "SELECT COUNT(*) FROM client_services_list";

                            SqlSelectSingle.Start(req);
                            SqlSelectSingle.Join();

                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_BILLING_SERVICES_COUNT:" + MysqlData.TransferFromServerSingle);

                            handler.Send(msg);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    // QUERY TO DOWNLOAD BILLING SERVICES
                    if (ClientMessage.Contains("QUERY_BILLING_GET_SERVICE"))
                    {
                        int i = int.Parse(ClientQuery);

                        string req = "SELECT `service` FROM `client_services_list`";

                        SqlSelectMultiple.Start(req);
                        SqlSelectMultiple.Join();

                        byte[] msg = Encoding.UTF8.GetBytes(MysqlData.TransferFromServerMultiple[i]);

                        handler.Send(msg);
                    }
                    // QUERY TO DOWNLOAD BILLING CLIENTS
                    if (ClientMessage.Contains("QUERY_BILLING_CLIENTS_COUNT"))
                    {
                        string req = "SELECT COUNT(*) FROM clients";

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();
                        SitesCost = MysqlData.TransferFromServerSingle;

                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_BILLING_CLIENTS_COUNT:" + SitesCost);
                        handler.Send(msg);
                    }
                    // QUERY TO DOWNLOAD BILLING CLIENTS
                    if (ClientMessage.Contains("QUERY_BILLING_GET_CLIENT"))
                    {
                        int i = int.Parse(ClientQuery);
                        string req = "SELECT `company` FROM `clients`";

                        SqlSelectMultiple.Start(req);
                        SqlSelectMultiple.Join();
                        byte[] msg = Encoding.UTF8.GetBytes(MysqlData.TransferFromServerMultiple[i]);
                        handler.Send(msg);
                    }
                    // QUERY TO GET SERVICES
                    if (ClientMessage.Contains("QUERY_BILLING_GET_CLIENT_ACTIVE_PERIODS"))
                    {
                        string req = "SELECT GROUP_CONCAT(`service` SEPARATOR '|') FROM `clients_periods` WHERE `company` = '" + ClientQuery + "'";

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();
                        if (MysqlData.TransferFromServerSingle != null)
                        {
                            byte[] msg = Encoding.UTF8.GetBytes(MysqlData.TransferFromServerSingle);
                            handler.Send(msg);
                        }
                        else
                        {
                            byte[] mess = Encoding.UTF8.GetBytes("null");
                            handler.Send(mess);
                        }
                    }
                    // QUERY TO GET CLIENT INFO 
                    if (ClientMessage.Contains("QUERY_BILLING_GET_CLIENT_DESCRIPTION"))
                    {
                        string req = "SELECT `fio`,`email`,`phone` FROM `clients` WHERE `company` = '" + ClientQuery + "'";

                        SqlSelectBilling.Start(req);
                        SqlSelectBilling.Join();
                        var SitesListToUser = string.Join("|", MysqlData.TransferFromServerBilling);

                        byte[] msg = Encoding.UTF8.GetBytes(SitesListToUser);
                        handler.Send(msg);
                    }
                    // QUERY TO GET DESC
                    if (ClientMessage.Contains("QUERY_BILLING_GET_SERVICE_DESCRIPTION"))
                    {
                        MysqlData.TransferFromServerBilling.Clear();

                        string[] SiteData = ClientQuery.Split('|');
                        string req = "SELECT `startDate`,`endDate`,`comment`,`manager`,`cost` FROM `clients_periods` WHERE `company` = '" + SiteData[0] + "' AND `service` = '" + SiteData[1] + "'";

                        SqlSelectDesc.Start(req);
                        SqlSelectDesc.Join();
                        var SitesListToUser = string.Join("|", MysqlData.TransferFromServerDesc);

                        byte[] msg = Encoding.UTF8.GetBytes(SitesListToUser);
                        handler.Send(msg);
                        SitesListToUser = null;
                    }
                    // SAVE DESC
                    if (ClientMessage.Contains("QUERY_BILLING_SAVE"))
                    {
                        List<string> TransferFromClientSiteData = new List<string>();
                        string[] SiteData = ClientQuery.Split('|');
                        foreach (string id in SiteData)
                        {
                            TransferFromClientSiteData.Add(id);
                        }

                        string req = "UPDATE `parolka`.`clients_periods` SET `startDate` = '" + TransferFromClientSiteData[2] + "' WHERE `clients_periods`.`service` ='" + TransferFromClientSiteData[1] + "' AND `company` = '" + TransferFromClientSiteData[0] + "'; UPDATE `parolka`.`clients_periods` SET `endDate` = '" + TransferFromClientSiteData[3] + "' WHERE `clients_periods`.`service` = '" + TransferFromClientSiteData[1] + "' AND `company` = '" + TransferFromClientSiteData[0] + "'; UPDATE `parolka`.`clients_periods` SET `manager` = '" + TransferFromClientSiteData[4] + "' WHERE `clients_periods`.`service` = '" + TransferFromClientSiteData[1] + "' AND `company` = '" + TransferFromClientSiteData[0] + "'; UPDATE `parolka`.`clients_periods` SET `cost` = '" + TransferFromClientSiteData[5] + "' WHERE `clients_periods`.`service` ='" + TransferFromClientSiteData[1] + "' AND `company` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`clients` SET `fio` = '" + TransferFromClientSiteData[6] + "' WHERE `clients`.`company` = '" + TransferFromClientSiteData[0] + "'; UPDATE `parolka`.`clients` SET `phone` = '" + TransferFromClientSiteData[8] + "' WHERE `clients`.`company` = '" + TransferFromClientSiteData[0] + "'; UPDATE `parolka`.`clients` SET `email` = '" + TransferFromClientSiteData[9] + "' WHERE `clients`.`company` = '" + TransferFromClientSiteData[0] + "'; UPDATE `parolka`.`clients` SET `company` = '" + TransferFromClientSiteData[7] + "' WHERE `clients`.`company` = '" + TransferFromClientSiteData[0] + "'; UPDATE `parolka`.`clients_periods` SET `company` = '" + TransferFromClientSiteData[7] + "' WHERE `clients_periods`.`company` = '" + TransferFromClientSiteData[0] + "'";
                        Console.WriteLine(MysqlData.TransferToServerUPDATE);

                        SqlUpdate.Start(req);
                        SqlUpdate.Join();

                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_BILLING_SAVE");
                        handler.Send(msg);
                    }
                    // add service
                    if (ClientMessage.Contains("QUERY_BILLING_ADD_NEW_SERVICE"))
                    {
                        List<string> TransferFromClientSiteData = new List<string>();
                        string[] sitedata = ClientQuery.Split('|');
                        foreach (string id in sitedata)
                        {
                            TransferFromClientSiteData.Add(id);
                        }

                        List<string> Query = new List<string>();
                        string[] servdata = TransferFromClientSiteData[2].Split(',');
                        foreach (string id in servdata)
                        {
                            Query.Add(id);
                        }

                        var SitesListToUser = String.Join("|", Query);

                        Console.WriteLine(SitesListToUser);
                        string CurDate = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + System.DateTime.Now.Day.ToString();
                        string req = "INSERT INTO clients_periods (`company`,`service`,`startDate`,`endDate`) VALUES ('" + TransferFromClientSiteData[0].ToString() + "','" + TransferFromClientSiteData[1].ToString() + "','" + CurDate + "','" + CurDate + "');";

                        SqlInsert.Start(req);
                        SqlInsert.Join();
                    }
                    // remove service
                    if (ClientMessage.Contains("QUERY_BILLING_REMOVE_SERVICE"))
                    {
                        string[] SiteData = ClientQuery.Split('|');

                        string req = "DELETE FROM `clients_periods` WHERE `company`='" + SiteData[0] + "' AND `service`='" + SiteData[1] + "'";

                        SqlDelete.Start(req);
                        SqlDelete.Join();

                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_BILLING_SERVICE_DELETED");
                        handler.Send(msg);
                    }
                    // new client
                    if (ClientMessage.Contains("QUERY_BILLING_CREATE_NEW_CLIENT"))
                    {
                        string req = "INSERT INTO `clients` (`company`) VALUES ('Новый шаблон клиента');";

                        SqlInsert.Start(req);
                        SqlInsert.Join();

                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_BILLING_TEMPLATE_CREATED");
                        handler.Send(msg);
                    }
                    // remove client
                    if (ClientMessage.Contains("QUERY_BILLING_REMOVE_CLIENT"))
                    {
                        List<string> TransferFromClientSiteData = new List<string>();

                        string req = "DELETE FROM `clients_periods` WHERE `company`='" + ClientQuery + "'; DELETE FROM `clients` WHERE `company`='" + ClientQuery + "';";

                        SqlDelete.Start(req);
                        SqlDelete.Join();

                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_BILLING_CLIENT_REMOVED");
                        handler.Send(msg);
                    }
                    // Download stats
                    if (ClientMessage.Contains("QUERY_BILLING_LOAD_COUNT_STATISTICS"))
                    {
                        try
                        {
                            string reqsel = "SELECT `id` FROM `clients_periods`";

                            SqlSelectMultiple.Start(reqsel);
                            SqlSelectMultiple.Join();

                            var SitesListToUser = string.Join("|", MysqlData.TransferFromServerMultiple);
                            Console.WriteLine(SitesListToUser);
                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_BILLING_LOAD_COUNT_STATISTICS:" + SitesListToUser);
                            handler.Send(msg);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    if (ClientMessage.Contains("QUERY_BILLING_LOAD_STATISTICsS"))
                    {
                        string reqselect = "SELECT CONCAT(`company`, ':', `service`, ':', DATE(`endDate`), ':', `cost`) from `clients_periods` where `id` =  '" + ClientQuery + "'; ";
                        
                        SqlSelectSingle.Start(reqselect);
                        SqlSelectSingle.Join();

                        byte[] msg = Encoding.UTF8.GetBytes(MysqlData.TransferFromServerSingle.ToString());
                        handler.Send(msg);

                        MysqlData.TransferFromServerSingle = null;
                    }
                    //
                    // SITES
                    //
                    // QUERY TO GET SITES, DETECT USER ROLE
                    if (ClientMessage.Contains("QUERY_SITES_CHECK_ACCESS"))
                    {
                        string ReceivedDataLoginGetSites = ClientQuery;

                        string req = "SELECT role FROM users WHERE login = '" + ReceivedDataLoginGetSites + "'";

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();

                        string ReceivedDataRoleGetSites = MysqlData.TransferFromServerSingle.ToString();
                        
                        // IF ADMIN, GET COUNT OF SITES
                        if (ReceivedDataRoleGetSites == "admin")
                        {   
                            string reqsel = "SELECT COUNT(*) FROM data";

                            SqlSelectSingleSecond.Start(reqsel);
                            SqlSelectSingleSecond.Join();

                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_SITES_ROOT_ACCESS:" + MysqlData.TransferFromServerSingle);
                            handler.Send(msg);
                        }
                        // IF USER, GET OWNED SITES
                        if (ReceivedDataRoleGetSites == "user")
                        {
                            string reqmul = "SELECT `site` FROM `own_data` WHERE `user` = '" + ReceivedDataLoginGetSites + "';";

                            SqlSelectMultiple.Start(reqmul);
                            SqlSelectMultiple.Join();

                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_SITES_USER_ACCESS:" + string.Join("|", MysqlData.TransferFromServerMultiple));
                            handler.Send(msg);
                        }
                    }
                    // SEND ALL SITES TO ADMIN
                    if (ClientMessage.Contains("QUERY_SITES_LOAD_ROOT"))
                    {
                        Console.WriteLine(ClientQuery);
                        string req = "SELECT `Site` FROM `data` LIMIT " + int.Parse(ClientQuery) + ",1";

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();

                        byte[] msg = Encoding.UTF8.GetBytes(MysqlData.TransferFromServerSingle);
                        handler.Send(msg);
                    }
                    // SEND OWNED SITES TO USER
                    if (ClientMessage.Contains("QUERY_SITES_LOAD_USER"))
                    {
                        string req = "SELECT `Site` FROM `data` where `id_rec` = '" + ClientQuery + "'";
                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();

                        byte[] msg = Encoding.UTF8.GetBytes(MysqlData.TransferFromServerSingle.ToString());
                        handler.Send(msg);
                    }
                    //GET SITE DATA
                    if (ClientMessage.Contains("QUERY_SITE_DESCRIPTION"))
                    {
                        try
                        {
                            string req = "SELECT `CMSHost`,`CMSUser`,`CMSPassword`,`CMSAdd`,`HostingHost`,`HostingUser`,`HostingPassword`,`HostingAdd`,`DBHost`,`DBUser`,`DBPassword`,`DBBase`,`FTPHost`,`FTPUser`,`FTPPassword`,`FtpPort`,`Comments` FROM `data` where `site` = '" + ClientQuery + "'";
                            SqlSelectRows.Start(req);
                            SqlSelectRows.Join();
                            var SitesListToUser = string.Join("|", MysqlData.TransferFromServerRows);
                            Console.WriteLine(SitesListToUser);
                            byte[] msg = Encoding.UTF8.GetBytes(SitesListToUser);
                            handler.Send(msg);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    // UPDATE SITE DATA
                    if (ClientMessage.Contains("QUERY_SITE_DESCRIPTION_UPDATE"))
                    {
                        List<string> TransferFromClientSiteData = new List<string>();
                        string[] SiteData = ClientQuery.Split(',');
                        foreach (string id in SiteData)
                        {
                            TransferFromClientSiteData.Add(id);
                        }

                        string req = "UPDATE `parolka`.`data` SET `CMSHost` = '" + TransferFromClientSiteData[1] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `CMSUser` = '" + TransferFromClientSiteData[2] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `CMSPassword` = '" + TransferFromClientSiteData[3] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `CMSAdd` = '" + TransferFromClientSiteData[4] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `HostingHost` = '" + TransferFromClientSiteData[5] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `HostingUser` = '" + TransferFromClientSiteData[6] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `HostingPassword` = '" + TransferFromClientSiteData[7] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `HostingAdd` = '" + TransferFromClientSiteData[8] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `DBHost` = '" + TransferFromClientSiteData[9] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `DBUser` = '" + TransferFromClientSiteData[10] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `DBPassword` = '" + TransferFromClientSiteData[11] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `DBBase` = '" + TransferFromClientSiteData[12] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `FTPHost` = '" + TransferFromClientSiteData[13] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `FTPUser` = '" + TransferFromClientSiteData[14] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `FTPPassword` = '" + TransferFromClientSiteData[15] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `FtpPort` = '" + TransferFromClientSiteData[16] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`data` SET `Comments` = '" + TransferFromClientSiteData[17] + "' WHERE `data`.`Site` = '" + TransferFromClientSiteData[0] + "';";
                        SqlUpdate.Start(req);
                        SqlUpdate.Join();
                    }
                    //FULL DELETE SITE, ADMIN
                    if (ClientMessage.Contains("QUERY_SITE_FULL_DELETE"))
                    {
                        string req = "SELECT `id_rec` FROM `data` WHERE `Site` = '" + ClientQuery + "';";

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();
                        string reqdel = "DELETE from data where site = '" + ClientQuery + "'; DELETE from own_data where site = '" + MysqlData.TransferFromServerSingle + "';";

                        SqlDelete.Start(reqdel);
                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_SITE_FULL_DELETED");
                        handler.Send(msg);
                    }
                    // REMOVE USER ACCESS TO SITE
                    if (ClientMessage.Contains("QUERY_SITE_USER_DELETE"))
                    {
                        List<string> TransferFromClientSiteData = new List<string>();
                        string[] sitedata = ClientQuery.Split(':');
                        foreach (string id in sitedata)
                        {
                            TransferFromClientSiteData.Add(id);
                        }
                        string req = "SELECT `id_rec` FROM `data` WHERE `Site` = '" + TransferFromClientSiteData[0].Trim().ToString() + "';";

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();
                        string reqdel = "DELETE FROM `own_data` WHERE `site` = '" + MysqlData.TransferFromServerSingle + "' AND `user` = '" + TransferFromClientSiteData[1].ToString() + "';";

                        SqlDelete.Start(reqdel);
                        SqlDelete.Join();
                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_SITE_USER_DELETED");
                        handler.Send(msg);
                    }
                    // ADD SITE, WRITE ACCESSES AND DATA
                    if (ClientMessage.Contains("QUERY_SITES_ADD_NEW"))
                    {
                        string[] sitedata = ClientQuery.Split(':');

                        string reqins = "INSERT INTO data (`site`) VALUES ('" + sitedata[0] + "');";

                        SqlInsert.Start(reqins);
                        SqlInsert.Join();
                        string reqsel = "SELECT `id_rec` FROM `data` WHERE `Site` = '" + sitedata[0] + "';";

                        SqlSelectSingle.Start(reqsel);
                        SqlSelectSingle.Join();
                        string req = "INSERT INTO own_data (`user`,`site`) VALUES ('" + sitedata[1] + "','" + MysqlData.TransferFromServerSingle.ToString() + "');";
 
                        SqlInsert.Start(req);
                        SqlInsert.Join();
                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_SITE_ADDED");
                        handler.Send(msg);
                    }
                    //
                    // SERVICES
                    //
                    // QUERY TO GET COUNT OF SERVICES
                    if (ClientMessage.Contains("QUERY_SERVICE_GET_COUNT"))
                    {
                        try
                        {
                            string req = "SELECT COUNT(*) FROM services";

                            SqlSelectSingle.Start(req);
                            SqlSelectSingle.Join();
                            Console.WriteLine(MysqlData.TransferFromServerSingle);
                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_SERVICE_GET_COUNT:" + MysqlData.TransferFromServerSingle);
                            handler.Send(msg);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    // QUERY TO DOWNLOAD SERVICES
                    if (ClientMessage.Contains("QUERY_SERVICE_LOAD"))
                    {
                        try
                        {
                            int i = int.Parse(ClientQuery);

                            string req = "SELECT `Service` FROM `services` LIMIT " + i + ",1";
                            SqlSelectSingle.Start(req);
                            SqlSelectSingle.Join();
                            byte[] msg = Encoding.UTF8.GetBytes(MysqlData.TransferFromServerSingle);
                            handler.Send(msg);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    // QUERY TO GET SERVICE INFO 
                    if (ClientMessage.Contains("QUERY_SERVICE_GET_DESC"))
                    {
                        
                        MysqlData.TransferFromServerServices.Clear();

                        string req = "SELECT `Host`,`Login`,`Password`,`Comment` FROM `services` WHERE `Service` = '" + ClientQuery + "'";

                        SqlSelectServices.Start(req);
                        SqlSelectServices.Join();
                        var SitesListToUser = String.Join("|", MysqlData.TransferFromServerServices);

                        byte[] msg = Encoding.UTF8.GetBytes(SitesListToUser);
                        handler.Send(msg);
                        SitesListToUser = null;
                    }
                    // ADD SERVICE
                    if (ClientMessage.Contains("QUERY_SERVICE_ADD"))
                    {
                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_SERVICE_ADDED");
                        handler.Send(msg);
                        string req = "INSERT INTO services (`Service`) VALUES ('" + ClientQuery + "');";

                        SqlInsert.Start(req);
                        SqlInsert.Join();
                    }
                    // QUERY TO UPDATE SERVICE INFO
                    if (ClientMessage.Contains("QUERY_SERVICE_UPDATE"))
                    {

                        List<string> TransferFromClientSiteData = new List<string>();
                        string[] SiteData = ClientQuery.Split(',');
                        foreach (string id in SiteData)
                        {
                            TransferFromClientSiteData.Add(id);
                        }

                        string req = "UPDATE `parolka`.`services` SET `Host` = '" + TransferFromClientSiteData[1] + "' WHERE `services`.`Service` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`services` SET `Login` = '" + TransferFromClientSiteData[2] + "' WHERE `services`.`Service` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`services` SET `Password` = '" + TransferFromClientSiteData[3] + "' WHERE `services`.`Service` = '" + TransferFromClientSiteData[0] + "';UPDATE `parolka`.`services` SET `Comment` = '" + TransferFromClientSiteData[4] + "' WHERE `services`.`Service` = '" + TransferFromClientSiteData[0] + "';";

                        SqlUpdate.Start(req);
                        SqlUpdate.Join();
                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_SERVICE_UPDATED");
                        handler.Send(msg);
                    }
                    // QUERY TO DELETE SERVICE
                    if (ClientMessage.Contains("QUERY_SERVICE_DELETE"))
                    {
                        string req = "DELETE FROM `services` WHERE `Service` = '" + ClientQuery + "';";

                        SqlDelete.Start(req);
                        SqlDelete.Join();
                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_SERVICE_DELETED");
                        handler.Send(msg);
                    }
                    //
                    // USER MANAGER
                    //
                    // USER MANAGER GET USERS
                    if (ClientMessage.Contains("QUERY_USERMANAGER_GET"))
                    {
                        string req = "SELECT `login` FROM `users`";
                        SqlSelectMultiple.Start(req);
                        SqlSelectMultiple.Join();
                        var SitesListToUser = String.Join("|", MysqlData.TransferFromServerMultiple);

                        byte[] msg = Encoding.UTF8.GetBytes(SitesListToUser);
                        handler.Send(msg);
                    }
                    // USER MANAGER GET USERS
                    if (ClientMessage.Contains("QUERY_USERMANAGER_CURRENT_SITE"))
                    {
                        MysqlData.TransferFromServerMultiple.Clear();

                        string req = "SELECT `id_rec` FROM `data` WHERE `Site` = '" + ClientQuery + "'";

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();
                        string reqsel = "SELECT `user` FROM `own_data` WHERE `site` = '" + MysqlData.TransferFromServerSingle + "'";

                        SqlSelectMultiple.Start(reqsel);
                        SqlSelectMultiple.Join();
                        var SitesListToUser = String.Join("|", MysqlData.TransferFromServerMultiple);

                        byte[] msg = Encoding.UTF8.GetBytes(SitesListToUser);
                        handler.Send(msg);
                    }
                    // GRANT ACCESS
                    if (ClientMessage.Contains("QUERY_USERMANAGER_GRANT"))
                    {
                        List<string> TransferFromClientSiteData = new List<string>();
                        string[] sitedata = ClientMessage.Split('|');
                        foreach (string id in sitedata)
                        {
                            TransferFromClientSiteData.Add(id);
                        }
                        string reqsel = "SELECT `id_rec` FROM `data` WHERE `Site` = '" + TransferFromClientSiteData[1] + "'";

                        SqlSelectSingle.Start(reqsel);
                        SqlSelectSingle.Join();
                        string reqins = "INSERT INTO own_data (`user`, `site`) VALUES ('" + TransferFromClientSiteData[2] + "','" + MysqlData.TransferFromServerSingle + "')";

                        SqlInsert.Start(reqins);
                        SqlInsert.Join();
                    }
                    // REMOVE ACCESS
                    if (ClientMessage.Contains("QUERY_USERMANAGER_REVOKE"))
                    {
                        List<string> TransferFromClientSiteData = new List<string>();
                        string[] sitedata = ClientMessage.Split('|');
                        foreach (string id in sitedata)
                        {
                            TransferFromClientSiteData.Add(id);
                        }
                        string reqsel = "SELECT `id_rec` FROM `data` WHERE `Site` = '" + TransferFromClientSiteData[1] + "'";

                        SqlSelectSingle.Start(reqsel);
                        SqlSelectSingle.Join();
                        string reqdel = "DELETE FROM `own_data` WHERE `user` = '" + TransferFromClientSiteData[2] + "' AND `site` = '" + MysqlData.TransferFromServerSingle + "'";

                        SqlInsert.Start(reqdel);
                        SqlInsert.Join();
                    }
                    // ADD USER
                    if (ClientMessage.Contains("QUERY_USERMANAGER_CREATE_USER"))
                    {
                        string reqins = "INSERT INTO `users` (`login`, `role`) VALUES ('" + ClientQuery + "', 'user')";

                        SqlInsert.Start(reqins);
                        SqlInsert.Join();
                    }
                    // REMOVE USER
                    if (ClientMessage.Contains("QUERY_USERMANAGER_REMOVE_USER"))
                    {
                        string userLogin = ClientQuery;
                        string reqdel = "DELETE FROM `own_data` WHERE `user` = '" + userLogin + "'";

                        SqlDelete.Start(reqdel);
                        SqlDelete.Join();
                        string req = "DELETE FROM `users` WHERE `login` = '" + userLogin + "'";

                        SqlDelete.Start(req);
                        SqlDelete.Join();
                    }
                    // CREATE PASS
                    if (ClientMessage.Contains("QUERY_USERMANAGER_UPDATE_PASSWORD"))
                    {
                        List<string> TransferFromClientSiteData = new List<string>();
                        string[] sitedata = ClientMessage.Split('|');
                        foreach (string id in sitedata)
                        {
                            TransferFromClientSiteData.Add(id);
                        }
                        string req = "UPDATE `parolka`.`users` SET `password` = '" + TransferFromClientSiteData[2] + "' WHERE `users`.`login` = '" + TransferFromClientSiteData[1] + "'";

                        SqlUpdate.Start(req);
                        SqlUpdate.Join();
                    }
                    ////INVENTARIZE
                    // GET QUERY
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_GET_COUNT"))
                    {
                        string req = "SELECT COUNT(*) FROM clients";
                        string InvRecords;

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();
                        InvRecords = MysqlData.TransferFromServerSingle;

                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_INVENTARIZE_GET_COUNT:" + InvRecords);

                        handler.Send(msg);
                    }
                    // QUERY TO DOWNLOAD BILLING SERVICES
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_LOAD_ITEM"))
                    {
                        try
                        {
                            int i = int.Parse(ClientQuery);

                            string client = "SELECT `company` from `clients` LIMIT " + i.ToString() + ",1";

                            SqlSelectSingle.Start(client);
                            SqlSelectSingle.Join();

                            string req = "SELECT `department` from `inventarize_db_clients` where `company` = '" + MysqlData.TransferFromServerSingle + "';";

                            SqlSelectMultiple.Start(req);
                            SqlSelectMultiple.Join();

                            List<string> data = new List<string>();

                            if (MysqlData.TransferFromServerMultiple.Count < 1)
                            {
                                data.Add(MysqlData.TransferFromServerSingle);
                            }

                            foreach (string dep in MysqlData.TransferFromServerMultiple)
                            {
                                data.Add(MysqlData.TransferFromServerSingle + ";" + dep);
                            }

                            string message = string.Join("|", data);

                            byte[] msg = Encoding.UTF8.GetBytes(message);

                            handler.Send(msg);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    //// GET QUERY TYPES
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_TYPES_COUNT"))
                    {
                        string req = "SELECT COUNT(*) FROM inventarize_db_types";

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();

                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_INVENTARIZE_TYPES_COUNT:" + MysqlData.TransferFromServerSingle);

                        handler.Send(msg);
                    }
                    // QUERY TO DOWNLOAD TYPES
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_TYPES_LOAD:"))
                    {
                        int i = int.Parse(ClientQuery);

                        string req = "SELECT `types` from `inventarize_db_types` LIMIT " + int.Parse(ClientQuery) + ",1;";

                        SqlSelectSingle.Start(req);
                        SqlSelectSingle.Join();
                        
                        byte[] msg = Encoding.UTF8.GetBytes(MysqlData.TransferFromServerSingle);
                        
                        handler.Send(msg);
                    }
                    // Get all items of company department
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_GET_ITEM"))
                    {
                        string[] lines = ClientQuery.Split(';');

                        string req = "SELECT `id` from `inventarize_db_items` where `company` =  '" + lines[0] + "' AND `department`  =  '" + lines[1] + "' AND `type`  =  '" + lines[2] + "';";
                        string InvRecords;

                        SqlSelectMultiple.Start(req);
                        SqlSelectMultiple.Join();

                        InvRecords = string.Join("|", MysqlData.TransferFromServerMultiple);

                        byte[] msg = Encoding.UTF8.GetBytes(InvRecords);

                        handler.Send(msg);
                    }
                    // send all items desc
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_GET_DEP_DATA"))
                    {
                        string lines = ClientQuery;

                        string req = "SELECT CONCAT(`element`, ';', `barcode`, ';', `description`) from `inventarize_db_items` where `id` =  '" + lines + "';";
                        string InvRecords;

                        SqlSelectMultiple.Start(req);
                        SqlSelectMultiple.Join();

                        InvRecords = string.Join("|", MysqlData.TransferFromServerMultiple);

                        Console.WriteLine(InvRecords);
                        byte[] msg = Encoding.UTF8.GetBytes(InvRecords);

                        handler.Send(msg);
                    }
                    // add company
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_COMPANY_ADD"))
                    {
                        string company = ClientQuery;

                        string ins = "INSERT INTO `parolka`.`inventarize_db_clients` (`id`, `company`, `department`) VALUES (NULL, '" + company + "', 'Без категории');";

                        SqlInsert.Start(ins);
                        SqlInsert.Join();

                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_INVENTARIZE_COMPANY_ADDED");
                        handler.Send(msg);
                    }
                    // add department
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_DEP_ADD"))
                    {
                        string[] message = ClientQuery.Split(':');
                        string ins = "INSERT INTO `parolka`.`inventarize_db_clients` (`id`, `company`, `department`) VALUES (NULL, '" + message[0] + "', '" + message[1] + "');";

                        SqlInsert.Start(ins);
                        SqlInsert.Join();

                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_INVENTARIZE_DEP_ADDED");
                        handler.Send(msg);
                    }
                    // add category
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_CAT_ADD"))
                    {
                        try
                        {
                            string ins = "INSERT INTO `parolka`.`inventarize_db_types` (`types`) VALUES ('" + ClientQuery + "');";

                            SqlInsert.Start(ins);
                            SqlInsert.Join();

                            byte[] msg = Encoding.UTF8.GetBytes("REPLY_INVENTARIZE_CAT_ADDED");
                            handler.Send(msg);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    // add item
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_ITEM_ADD"))
                    {
                        string[] message = ClientQuery.Split(';');

                        List<string> data = new List<string>();
                        foreach (string item in message)
                        {
                            data.Add(item);
                        }

                        string ins = "INSERT INTO `parolka`.`inventarize_db_items` (`company`, `department`, `type`, `element`, `hardware`, `barcode`) VALUES ('" + data[0] + "', '" + data[1] + "', '" + data[2] + "', '" + data[3] + "', '" + data[4] + "', '" + data[5] + "');";

                        SqlInsert.Start(ins);
                        SqlInsert.Join();

                        byte[] msg = Encoding.UTF8.GetBytes("REPLY_INVENTARIZE_ITEM_ADDED");
                        handler.Send(msg);
                    }
                    // get info
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_GET_DESC"))
                    {
                        try
                        {
                            string[] message = ClientQuery.Split(';');

                            List<string> data = new List<string>();
                            foreach (string item in message)
                            {
                                data.Add(item);
                            }

                            string req = "SELECT CONCAT(`hardware`, ';', `barcode`, ';', `description`) from `inventarize_db_items` where `company` =  '" + data[0] + "' AND `department` =  '" + data[1] + "' AND `element` =  '" + data[2] + "';";

                            SqlSelectSingle.Start(req);
                            SqlSelectSingle.Join();

                            string[] barcode = MysqlData.TransferFromServerSingle.Split(';');

                            string mod = "SELECT CONCAT(`modify`, '+', `date`) from `inventarize_db_modify` where `barcode` =  '" + barcode[1] + "';";

                            SqlSelectMultiple.Start(mod);
                            SqlSelectMultiple.Join();

                            byte[] msg = Encoding.UTF8.GetBytes(MysqlData.TransferFromServerSingle + ";" + string.Join("|", MysqlData.TransferFromServerMultiple));
                            handler.Send(msg);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    // update comment
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_COMMENT_UPDATE"))
                    {
                        string[] message = ClientQuery.Split(';');
                        
                        string req = "UPDATE `parolka`.`inventarize_db_items` SET `description` = '" + message[1] + "' WHERE `inventarize_db_items`.`barcode` ='" + message[0] + "';";

                        SqlUpdate.Start(req);
                        SqlUpdate.Join();
                    }
                    // add history
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_HISTORY_ADD"))
                    {
                        string[] message = ClientQuery.Split(';');

                        string ins = "INSERT INTO `parolka`.`inventarize_db_modify` (`barcode` ,`modify` ,`date` ,`comment`)VALUES('" + message[0] + "', '" + message[1] + "', '" + System.DateTime.Now.Year + System.DateTime.Now.Month + System.DateTime.Now.Day + System.DateTime.Now.TimeOfDay + "', '" + message[2] + "');";

                        SqlInsert.Start(ins);
                        SqlInsert.Join();
                    }
                    // QUERY TO DOWNLOAD TYPES
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_GET_MODIFY:"))
                    {
                        try
                        {
                            string[] message = ClientQuery.Split(';');

                            string[] modTime = message[1].Split('+');

                            string req = "SELECT `comment` from `inventarize_db_modify` where `barcode` = '" + message[0] + "' and `modify` = '" + modTime[0] + "' and `date` = '" + modTime[1] + "';";

                            SqlSelectSingle.Start(req);
                            SqlSelectSingle.Join();

                            byte[] msg = Encoding.UTF8.GetBytes(MysqlData.TransferFromServerSingle);

                            handler.Send(msg);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    // add client to invent table
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_AUTOUPDATE"))
                    {
                        try
                        {
                            string ins = "INSERT INTO `parolka`.`inventarize_db_clients` (`company`, `department`) VALUES ('" + ClientQuery + "', 'Без категории');";

                            SqlInsert.Start(ins);
                            SqlInsert.Join();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    //update hardware config
                    if (ClientMessage.Contains("QUERY_INVENTARIZE_HWINFO_UPDATE"))
                    {
                        try
                        {
                            string[] message = ClientQuery.Split(';');

                            string sel = "SELECT `hardware` from `inventarize_db_items` where `barcode` = '" + message[0] + "';";

                            SqlSelectSingle.Start(sel);
                            SqlSelectSingle.Join();

                            string ins = "INSERT INTO `parolka`.`inventarize_db_modify` (`barcode` ,`modify` ,`date` ,`comment`)VALUES('" + message[0] + "', 'Модификация', ' + '" + System.DateTime.Now.Year + System.DateTime.Now.Month + System.DateTime.Now.Day + System.DateTime.Now.TimeOfDay + "', 'Предыдущая конфигурация: " + MysqlData.TransferFromServerSingle + "');"; ;

                            SqlInsert.Start(ins);
                            SqlInsert.Join();

                            string req = "UPDATE `parolka`.`inventarize_db_items` SET `hardware` = '" + message[1] + "' WHERE `inventarize_db_items`.`barcode` ='" + message[0] + "';";
                            Console.WriteLine(req);
                            SqlUpdateSecond.Start(req);
                            SqlUpdateSecond.Join();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Client Disconnected" + "\n");
                }
            }
        }
    }
}
