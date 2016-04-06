using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Parolka.Inventarize
{
    public partial class AddItem : Form
    {
        List<string> DataArray = new List<string>();
        List<string> TypesArray = new List<string>();

        int ListState = 0;
        string companyData;
        string InvItemData;
        string companyCurrent;
        string departmentCurrent;
        string typeCurrent;
        bool loadIfChanged;

        public AddItem()
        {
            InitializeComponent();
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

                if (ListState == 2)
                {
                    ListState = 3;

                    TypeName.Enabled = false;
                    TypeName.Text = "Новая категория";

                    InvEl.Enabled = true;
                }
                if (ListState == 1)
                {
                    ListState = 2;

                    companyData = companyData + "," + changedItem;
                    label15.Text = label15.Text + " => " + changedItem;

                    DepName.Enabled = false;
                    DepName.Text = "Новый отдел";

                    TypeName.Enabled = true;
                }
                if (ListState == 0)
                {
                    ListState = 1;

                    companyData = changedItem;
                    label15.Text = companyData;

                    CompanyBox.Enabled = false;
                    CompanyBox.Text = "Новая компания";

                    DepName.Enabled = true;
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (loadIfChanged == true)
            {
                loadAll();
                loadIfChanged = false;
            }
            else
            {
                StructurizeCompany();
            }

            ListState = 0;
            CompanyBox.Enabled = true;
            companyData = null;
            InvEl.Enabled = false;
            DepName.Enabled = false;
            TypeName.Enabled = false;
            ConfAdd.Enabled = false;
            Barcode.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListItems.Items.Add(CompanyBox.Text);
        }

        private void CompanyBox_Click(object sender, EventArgs e)
        {
            CompanyBox.Clear();
        }

        private void DepName_Click(object sender, EventArgs e)
        {
            DepName.Clear();
        }

        private void TypeName_Click(object sender, EventArgs e)
        {
            TypeName.Clear();
        }

        private void InvEl_Click(object sender, EventArgs e)
        {
            InvEl.Clear();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            InvItemData = InvEl.Text;
            InvEl.Enabled = false;
            ConfAdd.Enabled = true;
            ConfList.Enabled = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ConfList.Items.Add(ConfAdd.Text);
            ConfAdd.Clear();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ConfList.Enabled = false;
            ConfAdd.Enabled = false;

            Barcode.Enabled = true;

            List<string> ConfArray = new List<string>();

            foreach(string item in ConfList.Items)
            {
                ConfArray.Add(item);
            }
            InvItemData = InvItemData + ";" + string.Join("|", ConfArray);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            InvItemData = companyCurrent + ";" + departmentCurrent + ";" + typeCurrent + ";" + InvItemData + ";" + Barcode.Text;

            ServerData.DataMessage = "QUERY_INVENTARIZE_ITEM_ADD:" + InvItemData;

            Server.Server.ParolkaClient();
            if (ServerData.ServMessage == "REPLY_INVENTARIZE_ITEM_ADDED")
            {
                CompanyBox.Clear();
                ListItems.Items.Add(InvEl.Text.Trim());

                Barcode.Enabled = false;
                InvEl.Enabled = true;
                ConfAdd.Clear();
                Barcode.Clear();
                ConfList.Items.Clear();
            }
        }

        private void ConfAdd_Click(object sender, EventArgs e)
        {
            ConfAdd.Clear();
        }

        private void ConfList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfAdd.Text = ConfList.SelectedItem.ToString();
        }

        private void Barcode_Click(object sender, EventArgs e)
        {
            Barcode.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ServerData.DataMessage = "QUERY_INVENTARIZE_COMPANY_ADD:" + CompanyBox.Text.Trim();

            Server.Server.ParolkaClient();
            if (ServerData.ServMessage == "REPLY_INVENTARIZE_COMPANY_ADDED")
            {
                CompanyBox.Clear();
                ListItems.Items.Add(CompanyBox.Text.Trim());
            }
            loadAll();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ServerData.DataMessage = "QUERY_INVENTARIZE_DEP_ADD:" + companyCurrent + ":" + DepName.Text.Trim();

            Server.Server.ParolkaClient();
            if (ServerData.ServMessage == "REPLY_INVENTARIZE_DEP_ADDED")
            {
                ListItems.Items.Add(DepName.Text.Trim());
                loadIfChanged = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ServerData.DataMessage = "QUERY_INVENTARIZE_CAT_ADD:" + TypeName.Text.Trim();

            Server.Server.ParolkaClient();
            if (ServerData.ServMessage == "REPLY_INVENTARIZE_CAT_ADDED")
            {
                ListItems.Items.Add(TypeName.Text.Trim());
                loadIfChanged = true;
            }
        }

        private void AddItem_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Message n = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref n);
        }

        private void CloseImg_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
