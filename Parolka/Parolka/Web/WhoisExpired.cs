/*
 * Created by SharpDevelop.
 * User: user
 * Date: 06.10.2015
 * Time: 14:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Parolka
{
	/// <summary>
	/// Description of Form8.
	/// </summary>
	public partial class WhoisExpired : Form
	{
        public WhoisExpired()
		{
			InitializeComponent();
            //    InitializeComponent();
            //    TcpClient WhoisServ =
            //        new TcpClient("whois.ripn.net", 43);
            //    BufferedStream BufferedStreamWhoisServ =
            //        new BufferedStream(WhoisServ.GetStream());
            //    StreamWriter swSend =
            //        new StreamWriter(BufferedStreamWhoisServ);
            //    swSend.WriteLine(PasswordManager.FormEdit.selectedsite.Trim());
            //    swSend.Flush();

            //    StreamReader srReceive =
            //        new StreamReader(BufferedStreamWhoisServ);

            //    string DomainInfo = String.Empty;
            //    try
            //    {
            //        while (!srReceive.EndOfStream)
            //            DomainInfo += srReceive.ReadLine() +
            //                Environment.NewLine;
            //    }
            //    catch (IOException)
            //    {

            //    }
            //    finally
            //    {
            //        WhoisServ.Close();
            //    }

            //    txbx_domainName.Text = DomainInfo;
		}

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //public unPayed()
        //{
        //    InitializeComponent();
        //    StatusText.Text = null;
        //    GetSites();
        //}
        //void GetSites()
        //{
        //    string QueryTypeAdd = "SELECT `id_rec`,`site` FROM `data`";
        //    using (MySqlConnection conDataBase = new MySqlConnection(PasswordManager.MysqlConnectData.constring))
        //    using (MySqlCommand cmdDataBase = new MySqlCommand(QueryTypeAdd, conDataBase))
        //    {
        //        try
        //        {
        //            conDataBase.Open();
        //            using (MySqlDataReader reader = cmdDataBase.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    SitesBoxWhois.Items.Add(reader[1].ToString());
        //                }
        //            }
        //            conDataBase.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    SitesBoxWhois.Sorted = true;
        //    WhoisProgress.Maximum = SitesBoxWhois.Items.Count + 1;
        //}
        //private void unPayed_Load(object sender, EventArgs e)
        //{
        //    SitesBoxWhois.Enabled = false;
        //    searchButton.Enabled = false;
        //    FindStringBox.Enabled = false;
        //    GetWhois.RunWorkerAsync();
        //}
        //private void pinger_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        //{
        //    for (int i = 0; i <= SitesBoxWhois.Items.Count; i++)
        //    {
        //        Thread.Sleep(1000);
        //        GetWhois.ReportProgress(i);
        //        PasswordManager.Whois.currentSite = SitesBoxWhois.Items[i].ToString();
        //    }
        //}
        //private void pinger_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        //{
        //    ConnectGetWhois();
        //    WhoisProgress.Value += 1;
        //    result.Text = PasswordManager.Whois.whoisResult;
        //    GetExpire();
        //}
        //private void pinger_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        //{
        //    StatusText.Text = "Готово";
        //    SitesBoxWhois.Enabled = true;
        //    searchButton.Enabled = true;
        //    FindStringBox.Enabled = true;
        //}
        //private void SitesBoxWhois_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    PasswordManager.Whois.currentSite = SitesBoxWhois.SelectedItem.ToString();
        //    ConnectGetWhois();
        //    result.Text = PasswordManager.Whois.whoisResult;
        //}
        //void ConnectGetWhois()
        //{
        //    TcpClient WhoisServ =
        //       new TcpClient("whois.ripn.net", 43);

        //    StatusText.Text = "Получаю WHOIS об " + PasswordManager.Whois.currentSite;

        //    BufferedStream BufferedStreamWhoisServ =
        //       new BufferedStream(WhoisServ.GetStream());
        //    StreamWriter swSend =
        //       new StreamWriter(BufferedStreamWhoisServ);
        //    swSend.WriteLine(PasswordManager.Whois.currentSite);
        //    swSend.Flush();


        //    StreamReader srReceive =
        //       new StreamReader(BufferedStreamWhoisServ);

        //    string DomainInfo = String.Empty;
        //    try
        //    {
        //        while (!srReceive.EndOfStream)
        //            DomainInfo += srReceive.ReadLine() +
        //                Environment.NewLine;
        //    }
        //    catch (IOException)
        //    {

        //    }
        //    finally
        //    {
        //        WhoisServ.Close();
        //    }
        //    PasswordManager.Whois.whoisResult = DomainInfo;
            
        //}
        //void GetExpire()
        //{
        //    int indexToText = result.Find("paid-till", RichTextBoxFinds.MatchCase);
        //    int lineNum = result.GetLineFromCharIndex(indexToText);
        //    string ToDateString = result.Lines[lineNum].Substring(15);
        //    try
        //    {
        //        DateTime DateString = Convert.ToDateTime(ToDateString);
        //        int dateCur = DateTime.Today.Month + 1;
        //        if (DateString.Month.ToString() == dateCur.ToString() && DateString.Year.ToString() == DateTime.Today.Year.ToString() || DateString.Month.ToString() == DateTime.Today.Month.ToString() && DateString.Year.ToString() == DateTime.Today.Year.ToString())
        //        {
        //            toPay.Items.Add(PasswordManager.Whois.currentSite + " " + DateString.Day + "." + DateString.Month + "." + DateString.Year);
        //        }
        //    }
        //    catch
        //    {
        //        // toPay.Items.Add(PasswordManager.Whois.currentSite + " ERR");
        //    }
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    FindMyString();
        //}
        //void FindMyString()
        //{
        //    string searchString = FindStringBox.Text; 
        //    // Ensure we have a proper string to search for.
        //    if (searchString != string.Empty)
        //    {
        //        // Find the item in the list and store the index to the item.
        //        int index = SitesBoxWhois.FindString(searchString);
        //        // Determine if a valid index is returned. Select the item if it is valid.
        //        if (index != -1)
        //            SitesBoxWhois.SetSelected(index, true);
        //        else
        //            MessageBox.Show("Сайт не найден!");
        //    }
        //}
	}
}
