using Parolka;
using Parolka.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PrintBarCode
{
    public partial class Print : Form
    {
        List<string> DataArray = new List<string>();
        List<string> TypesArray = new List<string>();
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();
        Image BarcodeImage;
        string companyData;
        int ListState;
        string companyCurrent;
        string departmentCurrent;
        string typeCurrent;

        public Print()
        {
            InitializeComponent();
            loadAll();
        }
        void loadAll()
        {
            ServerData.DataMessage = "QUERY_INVENTARIZE_GET_COUNT";
            Server.ParolkaClient();

            if (ServerData.ServMessage.Contains("REPLY_INVENTARIZE_GET_COUNT"))
            {
                ServerData.SitesCount = ServerData.ServMessageData;

                int i = int.Parse(ServerData.SitesCount);
                int h = 0;
                while (h <= i)
                {
                    ServerData.DataMessage = "QUERY_INVENTARIZE_LOAD_ITEM:" + h.ToString();
                    Server.ParolkaClient();

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
            Server.ParolkaClient();

            if (ServerData.ServMessage.Contains("REPLY_INVENTARIZE_TYPES_COUNT:"))
            {
                int i = int.Parse(ServerData.ServMessage.Substring(ServerData.ServMessage.IndexOf(":") + 1));
                int h = 0;
                while (h <= i - 1)
                {
                    ServerData.DataMessage = "QUERY_INVENTARIZE_TYPES_LOAD:" + h.ToString();
                    Server.ParolkaClient();

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
                    Server.ParolkaClient();

                    if (ListItems.Items.Contains(company)) continue;
                    ListItems.Items.Add(company);
                }
            }
        }
        private void LoadTableIntoList(ListView lv, DataTable table)
        {
            lv.BeginUpdate();

            lv.Items.Clear();
            foreach (DataRow row in table.Rows) {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = row[0].ToString();
                lvi.ImageIndex = Int32.Parse(row[1].ToString());

                for (int i = 2; i < table.Columns.Count; i++) {
                    lvi.SubItems.Add(row[i].ToString());
                }
                lv.Items.Add(lvi);
            }
            lv.EndUpdate();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int pages = (int)this.numericUpDown1.Value;

            switch (pages) {
                case 1:
                case 2:
                case 3:
                    this.printPreviewControl1.Rows = 1;
                    this.printPreviewControl1.Columns = pages;
                    break;
                default:
                    this.printPreviewControl1.Rows = 2;
                    this.printPreviewControl1.Columns = ((pages-1) / 2) + 1;
                    break;
            }
        }

        private void UpdatePrintPreview(object sender, EventArgs e)
        {
            this.printPreviewControl1.InvalidatePreview();
        }
        
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == this.lastSortColumn) {
                if (this.lastSortOrder == SortOrder.Ascending)
                    this.lastSortOrder = SortOrder.Descending;
                else
                    this.lastSortOrder = SortOrder.Ascending;
            }  else {
                this.lastSortOrder = SortOrder.Ascending;
                this.lastSortColumn = e.Column;
            }

            this.Rebuild();
        }
        private int lastSortColumn = 0;
        private SortOrder lastSortOrder = SortOrder.Ascending;

        private void Rebuild() 
        {
            if (this.listView1.ShowGroups)
                this.BuildGroups(this.lastSortColumn);
            else
                this.listView1.ListViewItemSorter = new ColumnComparer(this.lastSortColumn, this.lastSortOrder);
        }

        private void BuildGroups(int column)
        {
            this.listView1.Groups.Clear();
            
            int dummy = this.listView1.Items.Count;
            
            Dictionary<String, List<ListViewItem>> map = new Dictionary<String, List<ListViewItem>>();
            foreach (ListViewItem lvi in this.listView1.Items) {
                String key = lvi.SubItems[column].Text;
                if (column == 0 && key.Length > 0)
                    key = key.Substring(0, 1);
                if (!map.ContainsKey(key))
                    map[key] = new List<ListViewItem>();
                map[key].Add(lvi);
            }
            List<ListViewGroup> groups = new List<ListViewGroup>();
            foreach (String key in map.Keys) {
                groups.Add(new ListViewGroup(key));
            }

            groups.Sort(new ListViewGroupComparer(this.lastSortOrder));

            ColumnComparer itemSorter = new ColumnComparer(column,  this.lastSortOrder);
            foreach (ListViewGroup group in groups) {
                this.listView1.Groups.Add(group);
                map[group.Header].Sort(itemSorter);
                group.Items.AddRange(map[group.Header].ToArray());
            }
        }

        internal class ListViewGroupComparer : IComparer<ListViewGroup>
        {
            public ListViewGroupComparer(SortOrder order)
            {
                this.sortOrder = order;
            }

            public int Compare(ListViewGroup x, ListViewGroup y)
            {
                int result = String.Compare(x.Header, y.Header, true);

                if (this.sortOrder == SortOrder.Descending)
                    result = 0 - result;

                return result;
            }

            private SortOrder sortOrder;
        }

        internal class ColumnComparer : IComparer, IComparer<ListViewItem>
        {
            public ColumnComparer(int col, SortOrder order)
            {
                this.column = col;
                this.sortOrder = order;
            }

            public int Compare(object x, object y)
            {
                return this.Compare((ListViewItem)x, (ListViewItem)y);
            }

            public int Compare(ListViewItem x, ListViewItem y)
            {
                int result = String.Compare(x.SubItems[this.column].Text, y.SubItems[this.column].Text, true);

                if (this.sortOrder == SortOrder.Descending)
                    result = 0 - result;

                return result;

            }

            private int column;
            private SortOrder sortOrder;
        }
        
        void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
        	this.listView1.ShowGroups = ((CheckBox)sender).Checked;
        	this.Rebuild();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.listViewPrinter1.PrintWithDialog();
        }
        void RenderIt()
        {
            listView1.Scrollable = true;
            listView1.Columns.Clear();
            listView1.Items.Clear();

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(256, 64);

            listView1.Columns.Add("BarCode").Width = 256;
            listView1.Columns.Add("Компания").Width = 64;
            listView1.Columns.Add("Отдел").Width = 64;
            listView1.Columns.Add("Элемент").Width = 64;

            for (int i = 0; i <= ItemsSelecter.CheckedItems.Count - 1; i++)
            {
                string[] data = ItemsSelecter.Items[ItemsSelecter.CheckedIndices[i]].ToString().Split('+');

                GenerateBarCode(data[3], "Code 39", "TOPCENTER", "left", false);
                imgList.Images.Add(BarcodeImage);
                ListViewItem item = new ListViewItem("");
                
                item.SubItems.Add(data[0]);
                item.SubItems.Add(data[1]);
                item.SubItems.Add(data[2]);
                item.ImageIndex = i;
                listView1.Items.Add(item);
                
            }
            listView1.SmallImageList = imgList;
            imgList = null;
        }
        void GenerateBarCode(string barcode, string bctype, string bclocation, string bcalign, bool labelAdd)
        {
            int W = Convert.ToInt32("256");
            int H = Convert.ToInt32("64");
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;

            switch (bcalign)
            {
                case "left": b.Alignment = BarcodeLib.AlignmentPositions.LEFT; break;
                case "right": b.Alignment = BarcodeLib.AlignmentPositions.RIGHT; break;
                default: b.Alignment = BarcodeLib.AlignmentPositions.CENTER; break;
            }

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            switch (bctype)
            {
                case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
                case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
                case "UPC 2 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
                case "UPC 5 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
                case "EAN-13": type = BarcodeLib.TYPE.EAN13; break;
                case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
                case "EAN-8": type = BarcodeLib.TYPE.EAN8; break;
                case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
                case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
                case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
                case "Bookland/ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
                case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
                case "Code 39": type = BarcodeLib.TYPE.CODE39; break;
                case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
                case "Code 39 Mod 43": type = BarcodeLib.TYPE.CODE39_Mod43; break;
                case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
                case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
                case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
                case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
                case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
                case "Code 128": type = BarcodeLib.TYPE.CODE128; break;
                case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
                case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
                case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
                case "Telepen": type = BarcodeLib.TYPE.TELEPEN; break;
                case "FIM": type = BarcodeLib.TYPE.FIM; break;
                case "Pharmacode": type = BarcodeLib.TYPE.PHARMACODE; break;
                default: MessageBox.Show("Please specify the encoding type."); break;
            }
            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {
                    b.IncludeLabel = labelAdd;

                    b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone", true);

                    switch (bclocation)
                    {
                        case "BOTTOMLEFT": b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMLEFT; break;
                        case "BOTTOMRIGHT": b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMRIGHT; break;
                        case "TOPCENTER": b.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER; break;
                        case "TOPLEFT": b.LabelPosition = BarcodeLib.LabelPositions.TOPLEFT; break;
                        case "TOPRIGHT": b.LabelPosition = BarcodeLib.LabelPositions.TOPRIGHT; break;
                        default: b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER; break;
                    }

                    BarcodeImage = b.Encode(type, barcode, Color.Black, Color.White, W, H);

                    string encTime = "(" + Math.Round(b.EncodingTime, 0, MidpointRounding.AwayFromZero).ToString() + "ms)";

                    string EncValue = b.EncodedValue;

                    string encType = "Encoding Type: " + b.EncodedType.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.listViewPrinter1.PageSetup();
            this.UpdatePrintPreview(null, null);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            RenderIt();
            this.UpdatePrintPreview(null, null);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.listViewPrinter1.PrintPreview();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString() == "Auto")
            {
                this.printPreviewControl1.Zoom = 1.0;
                this.printPreviewControl1.AutoZoom = true;
            }
            if (comboBox4.SelectedItem.ToString() == "50")
            {
                this.printPreviewControl1.Zoom = 0.5;
            }
            if (comboBox4.SelectedItem.ToString() == "100")
            {
                this.printPreviewControl1.Zoom = 1.0;
            }
            if (comboBox4.SelectedItem.ToString() == "200")
            {
                this.printPreviewControl1.Zoom = 2.0;
            }
        }

        private void Print_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Message n = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref n);
        }

        private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string changedItem = ListItems.SelectedItem.ToString();
                if (changedItem == "/.." && (ListState == 1 || ListState == 2 || ListState == 3))
                {
                    ListState = 0;
                    StructurizeCompany();
                    return;
                }

                if (ListState == 0)
                {
                    ListItems.Items.Clear();
                    ListItems.Items.Add("/..");
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
                    ListItems.Items.Add("/..");
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
                    ListItems.Items.Add("/..");
                    try
                    {
                        typeCurrent = changedItem;
                        ServerData.DataMessage = "QUERY_INVENTARIZE_GET_ITEM:" + companyCurrent + ";" + departmentCurrent + ";" + changedItem + ";";
                        Server.ParolkaClient();
                        string[] lines = ServerData.ServMessage.Split('|');

                        foreach (string item in lines)
                        {
                            ServerData.DataMessage = "QUERY_INVENTARIZE_GET_DEP_DATA:" + item;
                            Server.ParolkaClient();

                            ServerData.ServMessage = ServerData.ServMessage.Substring(0, ServerData.ServMessage.IndexOf(';'));

                            ListItems.Items.Add(ServerData.ServMessage);
                        }
                    }
                    catch
                    {
                        ListItems.Items.Add("/..");
                        ListItems.Items.Add("Нет техники");
                    }
                }
                if (ListState == 3)
                {
                    ServerData.DataMessage = "QUERY_INVENTARIZE_GET_DESC:" + companyCurrent + ";" + departmentCurrent + ";" + changedItem + ";";
                    Server.ParolkaClient();

                    string[] lines = ServerData.ServMessage.Split(';');

                    ItemsSelecter.Items.Add(companyCurrent + "+" + departmentCurrent + "+" + changedItem + "+" + lines[1]);
                }

                if (ListState == 2)
                {
                    ListState = 3;
                }
                if (ListState == 1)
                {
                    ListState = 2;

                    companyData = companyData + "," + changedItem;
                    label15.Text = label15.Text + " => " + changedItem;
                }
                if (ListState == 0)
                {
                    ListState = 1;
                    companyData = changedItem;
                    label15.Text = companyData;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void ItemsSelecter_DoubleClick(object sender, KeyPressEventArgs e)
        {
            if (IsInputKey(Keys.Delete))
            {
                ItemsSelecter.Items.Remove(ItemsSelecter.SelectedItem);
            }
        }
    }
}
