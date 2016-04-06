using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Parolka.Inventarize
{
    public partial class Inventarize : Form
	{
        List<string> DataArray = new List<string>();
        List<string> TypesArray = new List<string>();
        int ListState = 0;
        string companyCurrent;
        string departmentCurrent;
        string typeCurrent;
        string elementCurrent;

        public Inventarize()
		{
			InitializeComponent();
            label15.Text = Config.ver;

            loadAll();
        }
        void loadAll()
        {
            ServerData.DataMessage = "QUERY_INVENTARIZE_GET_COUNT";
            Server.Server.ParolkaClient();

            if (ServerData.ServMessage.Contains("REPLY_INVENTARIZE_GET_COUNT"))
            {
                ServerData.SitesCount = ServerData.ServMessageData;

                int i = int.Parse(ServerData.SitesCount);
                int h = 0;
                while (h <= i)
                {
                    ServerData.DataMessage = "QUERY_INVENTARIZE_LOAD_ITEM:" + h.ToString();
                    Server.Server.ParolkaClient();
                    if (ServerData.ServMessage.Contains("|"))
                    {
                        string[] msg = ServerData.ServMessage.Split('|');

                        foreach (string item in msg)
                        {
                            DataArray.Add(item);
                        }
                    }
                    else
                    {
                        DataArray.Add(ServerData.ServMessage);
                    }
                    h++;
                }
            }
            ServerData.DataMessage = "QUERY_INVENTARIZE_TYPES_COUNT";
            Server.Server.ParolkaClient();

            if (ServerData.ServMessage.Contains("REPLY_INVENTARIZE_TYPES_COUNT:"))
            {
                int i = int.Parse(ServerData.ServMessage.Substring(ServerData.ServMessage.IndexOf(":") + 1));
                int h = 0;
                while (h <= i - 1)
                {
                    ServerData.DataMessage = "QUERY_INVENTARIZE_TYPES_LOAD:" + h.ToString();
                    Server.Server.ParolkaClient();

                    TypesArray.Add(ServerData.ServMessage);

                    h++;
                }
            }
            StructurizeCompany();
        }
        private void StructurizeCompany()
        {
            ListItems.Items.Clear();

            foreach (string company in DataArray)
            {
                try
                {
                    string toAdd = company.Substring(0, company.IndexOf(';'));

                    if (ListItems.Items.Contains(toAdd)) continue;
                    ListItems.Items.Add(toAdd);
                }
                catch
                {
                    ServerData.DataMessage = "QUERY_INVENTARIZE_AUTOUPDATE:" + company;
                    Server.Server.ParolkaClient();

                    if (ListItems.Items.Contains(company)) continue;
                    ListItems.Items.Add(company);
                }


            }
        }
        private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string changedItem = ListItems.SelectedItem.ToString();

                if (ListState == 0)
                {
                    ListItems.Items.Clear();
                    companyCurrent = changedItem;
                    foreach (string item in DataArray)
                    {
                        if (item.Contains(changedItem))
                        {
                            string data = item.Substring(item.IndexOf(';') + 1);

                            if (ListItems.Items.Contains(data)) continue;
                            {
                                ListItems.Items.Add(data);
                            }
                        }
                    }
                }
                if (ListState == 1)
                {
                    departmentCurrent = changedItem;
                    ListItems.Items.Clear();
                    foreach (string item in TypesArray)
                    {
                        if (ListItems.Items.Contains(item)) continue;
                        {
                            ListItems.Items.Add(item);
                        }
                    }
                }
                if (ListState == 2)
                {
                    ListItems.Items.Clear();
                    try
                    {
                        typeCurrent = changedItem;
                        ServerData.DataMessage = "QUERY_INVENTARIZE_GET_ITEM:" + companyCurrent + ";" + departmentCurrent + ";" + changedItem + ";";
                        Server.Server.ParolkaClient();
                        string[] lines = ServerData.ServMessage.Split('|');

                        foreach (string item in lines)
                        {
                            ServerData.DataMessage = "QUERY_INVENTARIZE_GET_DEP_DATA:" + item;
                            Server.Server.ParolkaClient();

                            ServerData.ServMessage = ServerData.ServMessage.Substring(0, ServerData.ServMessage.IndexOf(';'));

                            ListItems.Items.Add(ServerData.ServMessage);
                        }
                    }
                    catch
                    {
                        ListItems.Items.Add("Нет техники");
                    }
                }
                if (ListState == 3)
                {
                    Hardware.Items.Clear();
                    listBox1.Items.Clear();

                    ServerData.DataMessage = "QUERY_INVENTARIZE_GET_DESC:" + companyCurrent + ";" + departmentCurrent + ";" + changedItem + ";";
                    Server.Server.ParolkaClient();

                    string[] lines = ServerData.ServMessage.Split(';');

                    string[] hw = lines[0].Split('|');

                    foreach (string item in hw)
                    {
                        Hardware.Items.Add(item);
                    }
                    BarCode.Text = lines[1];
                    Description.Text = lines[2];

                    string[] modify = lines[3].Split('|');
                    foreach (string item in modify)
                    {
                        listBox1.Items.Add(item);
                    }
                }

                if (ListState == 2)
                {
                    ListState = 3;

                }
                if (ListState == 1)
                {
                    ListState = 2;
                    label15.Text = label15.Text + " => " + changedItem;
                }
                if (ListState == 0)
                {
                    ListState = 1;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Form printBarcodes = new PrintBarCode.Print();
            printBarcodes.Show();
        }
        private void CloseImg_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Form Client = new Parolka.Client();
            Client.Show();

            this.Hide();
        }
        private void CloseImg_MouseEnter(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.FromArgb(192, 0, 0);
        }
        private void CloseImg_MouseLeave(object sender, EventArgs e)
        {
            CloseImg.BackColor = Color.Red;
        }
        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            pictureBox16.BackColor = Color.FromName("Highlight");
        }
        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            pictureBox16.BackColor = Color.FromName("HotTrack");
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            Capture = false;
            Message n = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref n);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            StructurizeCompany();
            ListState = 0;
        }
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromName("Highlight");
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromName("HotTrack");
        }
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromName("Highlight");
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromName("HotTrack");
        }
        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.FromName("Highlight");
        }
        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.FromName("HotTrack");
        }
        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            pictureBox14.BackColor = Color.FromName("Highlight");
        }
        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            pictureBox14.BackColor = Color.FromName("HotTrack");
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form AddItems = new AddItem();
            AddItems.Show();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ServerData.DataMessage = "QUERY_INVENTARIZE_COMMENT_UPDATE:" + BarCode.Text + ";" + Description.Text;
            Server.Server.ParolkaClient();
        }
        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox2.Clear();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ServerData.DataMessage = "QUERY_INVENTARIZE_HISTORY_ADD:" + BarCode.Text + ";" + textBox5.Text + ";" + textBox2.Text;
            Server.Server.ParolkaClient();

            listBox1.Items.Add(textBox5.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerData.DataMessage = "QUERY_INVENTARIZE_GET_MODIFY:" + BarCode.Text + ";" + listBox1.SelectedItem.ToString();
            Server.Server.ParolkaClient();

            textBox2.Text = ServerData.ServMessage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hardware.Items.Add(textBox4.Text);
            textBox4.Clear();
            List<string> HWList = new List<string>();
            foreach (string item in Hardware.Items)
            {
                HWList.Add(item);
            }
            ServerData.DataMessage = "QUERY_INVENTARIZE_HWINFO_UPDATE:" + BarCode.Text + ";" + string.Join("|", HWList);

            Server.Server.ParolkaClient();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Hardware.Items.Remove(Hardware.SelectedItem);
            textBox4.Clear();
            List<string> HWList = new List<string>();
            foreach (string item in Hardware.Items)
            {
                HWList.Add(item);
            }
            ServerData.DataMessage = "QUERY_INVENTARIZE_HWINFO_UPDATE:" + BarCode.Text + ";" + string.Join("|", HWList);
            Server.Server.ParolkaClient();
        }
    }
}