using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ParolkaServer
{
    static class MysqlData
    {
        public static string TransferError;

        public static string TransferFromServerSingle;
        public static List<string> TransferFromServerMultiple = new List<string>();
        public static List<string> TransferFromServerRows = new List<string>();
        public static List<string> TransferFromServerServices = new List<string>();
        public static List<string> TransferFromServerBilling = new List<string>();
        public static List<string> TransferFromServerDesc = new List<string>();
        public static List<string> TransferFromServerInventarize = new List<string>();

        public static string TransferToServerSELECT;
        public static string TransferToServerINSERT;
        public static string TransferToServerUPDATE;
        public static string TransferToServerDELETE;
    }
    class SQL
    {
        public static void SqlSelectSingle(object data)
        {
            MysqlData.TransferFromServerSingle = null;
            
            using (MySqlConnection conDataBase = new MySqlConnection(MysqlConnectData.Constring))
            using (MySqlCommand cmdDataBase = new MySqlCommand(data.ToString(), conDataBase))
            {
                try
                {
                    conDataBase.Open();
                    using (MySqlDataReader reader = cmdDataBase.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MysqlData.TransferFromServerSingle = reader[0].ToString();
                        }
                    }
                    conDataBase.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void SqlSelectMultiple(object data)
        {
            MysqlData.TransferFromServerMultiple.Clear();

            using (MySqlConnection conDataBase = new MySqlConnection(MysqlConnectData.Constring))
            using (MySqlCommand cmdDataBase = new MySqlCommand(data.ToString(), conDataBase))
            {
                try
                {
                    conDataBase.Open();
                    using (MySqlDataReader reader = cmdDataBase.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MysqlData.TransferFromServerMultiple.Add(reader.GetString(0));
                        }
                    }
                    conDataBase.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            MysqlData.TransferToServerSELECT = null;
        }
        public static void SqlSelectRows(object data)
        {
            MysqlData.TransferFromServerRows.Clear();
            using (MySqlConnection conDataBase = new MySqlConnection(ParolkaServer.MysqlConnectData.Constring))
            using (MySqlCommand cmdDataBase = new MySqlCommand(data.ToString(), conDataBase))
            {
                try
                {
                    conDataBase.Open();
                    using (MySqlDataReader reader = cmdDataBase.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            while (i <= 16)
                            {
                                MysqlData.TransferFromServerRows.Add(reader.GetString(i));
                                i++;
                            }
                        }
                    }
                    conDataBase.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            MysqlData.TransferToServerSELECT = null;
        }
        public static void SqlSelectBilling(object data)
        {
            MysqlData.TransferFromServerBilling.Clear();
            using (MySqlConnection conDataBase = new MySqlConnection(ParolkaServer.MysqlConnectData.Constring))
            using (MySqlCommand cmdDataBase = new MySqlCommand(data.ToString(), conDataBase))
            {
                try
                {
                    conDataBase.Open();
                    using (MySqlDataReader reader = cmdDataBase.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            while (i <= 2)
                            {
                                MysqlData.TransferFromServerBilling.Add(reader.GetString(i));
                                i++;
                            }
                        }
                    }
                    conDataBase.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            MysqlData.TransferToServerSELECT = null;
        }
        public static void SqlSelectDesc(object data)
        {
            MysqlData.TransferFromServerDesc.Clear();
            using (MySqlConnection conDataBase = new MySqlConnection(ParolkaServer.MysqlConnectData.Constring))
            using (MySqlCommand cmdDataBase = new MySqlCommand(data.ToString(), conDataBase))
            {
                try
                {
                    conDataBase.Open();
                    using (MySqlDataReader reader = cmdDataBase.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            while (i <= 4)
                            {
                                MysqlData.TransferFromServerDesc.Add(reader.GetString(i));
                                i++;
                            }
                        }
                    }
                    conDataBase.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            MysqlData.TransferToServerSELECT = null;
        }
        public static void SqlSelectServices(object data)
        {
            MysqlData.TransferFromServerServices.Clear();
            using (MySqlConnection conDataBase = new MySqlConnection(ParolkaServer.MysqlConnectData.Constring))
            using (MySqlCommand cmdDataBase = new MySqlCommand(data.ToString(), conDataBase))
            {
                try
                {
                    conDataBase.Open();
                    using (MySqlDataReader reader = cmdDataBase.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            while (i <= 2)
                            {
                                MysqlData.TransferFromServerServices.Add(reader.GetString(i));
                                i++;
                            }
                        }
                    }
                    conDataBase.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            MysqlData.TransferToServerSELECT = null;
        }
        public static void SqlSelectInventarize(object data)
        {
            MysqlData.TransferFromServerBilling.Clear();
            using (MySqlConnection conDataBase = new MySqlConnection(MysqlConnectData.Constring))
            using (MySqlCommand cmdDataBase = new MySqlCommand(data.ToString(), conDataBase))
            {
                try
                {
                    conDataBase.Open();
                    using (MySqlDataReader reader = cmdDataBase.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            while (i <= 8)
                            {
                                MysqlData.TransferFromServerInventarize.Add(reader.GetString(i));
                                i++;
                            }
                        }
                    }
                    conDataBase.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            MysqlData.TransferToServerSELECT = null;
        }
        public static void SqlInsert(object data)
        {
            using (MySqlConnection conDataBase = new MySqlConnection(MysqlConnectData.Constring))
            using (MySqlCommand cmdDataBase = new MySqlCommand(data.ToString(), conDataBase))
            {
                try
                {
                    conDataBase.Open();
                    cmdDataBase.ExecuteNonQuery();
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            MysqlData.TransferToServerINSERT = null;
        }
        public static void SqlDelete(object data)
        {
            using (MySqlConnection conDataBase = new MySqlConnection(ParolkaServer.MysqlConnectData.Constring))
            using (MySqlCommand cmdDataBase = new MySqlCommand(data.ToString(), conDataBase))
            {
                try
                {
                    conDataBase.Open();
                    cmdDataBase.ExecuteNonQuery();
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            MysqlData.TransferToServerDELETE = null;
        }
        public static void SqlUpdate(object data)
        {
            using (MySqlConnection conDataBase = new MySqlConnection(ParolkaServer.MysqlConnectData.Constring))
            using (MySqlCommand cmdDataBase = new MySqlCommand(data.ToString(), conDataBase))
            {
                try
                {
                    conDataBase.Open();
                    cmdDataBase.ExecuteNonQuery();
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            MysqlData.TransferToServerUPDATE = null;
        }
    }
    static class MysqlConnectData
    {
        public static string Datasource;
        public static string Database;
        public static string Port = "3306";
        public static string Username;
        public static string Password;
        public static string Charset = "utf8";

        public static string Constring = "datasource=" + Datasource + ";" + "Database=" + Database + ";" + "port=" + Port + ";" + "username=" + Username + ";" + "password=" + Password + ";" + "charset=" + Charset;
    }
}