namespace Parolka.Inventarize
{
    partial class AddItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListItems = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.CloseImg = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.CompanyBox = new System.Windows.Forms.TextBox();
            this.Barcode = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DepName = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.TypeName = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.InvEl = new System.Windows.Forms.TextBox();
            this.ConfList = new System.Windows.Forms.ListBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.ConfAdd = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // ListItems
            // 
            this.ListItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListItems.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ListItems.FormattingEnabled = true;
            this.ListItems.ItemHeight = 21;
            this.ListItems.Location = new System.Drawing.Point(12, 44);
            this.ListItems.Name = "ListItems";
            this.ListItems.Size = new System.Drawing.Size(249, 294);
            this.ListItems.TabIndex = 21;
            this.ListItems.SelectedIndexChanged += new System.EventHandler(this.ListItems_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label15.Location = new System.Drawing.Point(12, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 21);
            this.label15.TabIndex = 40;
            this.label15.Text = "Parolka 2.0";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(600, 32);
            this.textBox3.TabIndex = 39;
            // 
            // CloseImg
            // 
            this.CloseImg.BackColor = System.Drawing.Color.Red;
            this.CloseImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseImg.Image = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.Location = new System.Drawing.Point(566, 0);
            this.CloseImg.Margin = new System.Windows.Forms.Padding(0);
            this.CloseImg.Name = "CloseImg";
            this.CloseImg.Size = new System.Drawing.Size(25, 25);
            this.CloseImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseImg.TabIndex = 38;
            this.CloseImg.TabStop = false;
            this.CloseImg.Click += new System.EventHandler(this.CloseImg_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox3.Image = global::Parolka.Properties.Resources.appbar_home;
            this.pictureBox3.Location = new System.Drawing.Point(538, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 96;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // CompanyBox
            // 
            this.CompanyBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CompanyBox.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.CompanyBox.Location = new System.Drawing.Point(267, 44);
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(293, 24);
            this.CompanyBox.TabIndex = 98;
            this.CompanyBox.Text = "Новая компания";
            this.CompanyBox.Click += new System.EventHandler(this.CompanyBox_Click);
            // 
            // Barcode
            // 
            this.Barcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Barcode.Enabled = false;
            this.Barcode.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Barcode.Location = new System.Drawing.Point(267, 303);
            this.Barcode.Name = "Barcode";
            this.Barcode.Size = new System.Drawing.Size(293, 24);
            this.Barcode.TabIndex = 100;
            this.Barcode.Text = "Новый штрих-код";
            this.Barcode.Click += new System.EventHandler(this.Barcode_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Indigo;
            this.pictureBox2.Image = global::Parolka.Properties.Resources.appbar_add;
            this.pictureBox2.Location = new System.Drawing.Point(566, 44);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 104;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Indigo;
            this.pictureBox1.Image = global::Parolka.Properties.Resources.appbar_add;
            this.pictureBox1.Location = new System.Drawing.Point(566, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 106;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // DepName
            // 
            this.DepName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DepName.Enabled = false;
            this.DepName.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.DepName.Location = new System.Drawing.Point(267, 74);
            this.DepName.Name = "DepName";
            this.DepName.Size = new System.Drawing.Size(293, 24);
            this.DepName.TabIndex = 105;
            this.DepName.Text = "Новый отдел";
            this.DepName.Click += new System.EventHandler(this.DepName_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Indigo;
            this.pictureBox4.Image = global::Parolka.Properties.Resources.appbar_add;
            this.pictureBox4.Location = new System.Drawing.Point(566, 104);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 108;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // TypeName
            // 
            this.TypeName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TypeName.Enabled = false;
            this.TypeName.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.TypeName.Location = new System.Drawing.Point(267, 104);
            this.TypeName.Name = "TypeName";
            this.TypeName.Size = new System.Drawing.Size(293, 24);
            this.TypeName.TabIndex = 107;
            this.TypeName.Text = "Новая категория";
            this.TypeName.Click += new System.EventHandler(this.TypeName_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Indigo;
            this.pictureBox5.Image = global::Parolka.Properties.Resources.appbar_arrow_down;
            this.pictureBox5.Location = new System.Drawing.Point(566, 134);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 24);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 110;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // InvEl
            // 
            this.InvEl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InvEl.Enabled = false;
            this.InvEl.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.InvEl.Location = new System.Drawing.Point(267, 134);
            this.InvEl.Name = "InvEl";
            this.InvEl.Size = new System.Drawing.Size(293, 24);
            this.InvEl.TabIndex = 109;
            this.InvEl.Text = "Новый элемент инвентаризации";
            this.InvEl.Click += new System.EventHandler(this.InvEl_Click);
            // 
            // ConfList
            // 
            this.ConfList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfList.Cursor = System.Windows.Forms.Cursors.Default;
            this.ConfList.Enabled = false;
            this.ConfList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ConfList.FormattingEnabled = true;
            this.ConfList.ItemHeight = 17;
            this.ConfList.Location = new System.Drawing.Point(268, 165);
            this.ConfList.Name = "ConfList";
            this.ConfList.Size = new System.Drawing.Size(322, 102);
            this.ConfList.TabIndex = 111;
            this.ConfList.SelectedIndexChanged += new System.EventHandler(this.ConfList_SelectedIndexChanged);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Indigo;
            this.pictureBox6.Image = global::Parolka.Properties.Resources.appbar_list_create;
            this.pictureBox6.Location = new System.Drawing.Point(536, 273);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(24, 24);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 113;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // ConfAdd
            // 
            this.ConfAdd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfAdd.Enabled = false;
            this.ConfAdd.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.ConfAdd.Location = new System.Drawing.Point(267, 273);
            this.ConfAdd.Name = "ConfAdd";
            this.ConfAdd.Size = new System.Drawing.Size(263, 24);
            this.ConfAdd.TabIndex = 112;
            this.ConfAdd.Text = "Новый элемент конфигурации";
            this.ConfAdd.Click += new System.EventHandler(this.ConfAdd_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Indigo;
            this.pictureBox7.Image = global::Parolka.Properties.Resources.appbar_add;
            this.pictureBox7.Location = new System.Drawing.Point(566, 303);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(24, 24);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 114;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Indigo;
            this.pictureBox8.Image = global::Parolka.Properties.Resources.appbar_arrow_down;
            this.pictureBox8.Location = new System.Drawing.Point(566, 273);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(24, 24);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 115;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.ConfAdd);
            this.Controls.Add(this.ConfList);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.InvEl);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.TypeName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DepName);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Barcode);
            this.Controls.Add(this.CompanyBox);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.CloseImg);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.ListItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddItem";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddItem_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListItems;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox CloseImg;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox CompanyBox;
        private System.Windows.Forms.TextBox Barcode;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox DepName;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox TypeName;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox InvEl;
        private System.Windows.Forms.ListBox ConfList;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox ConfAdd;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
    }
}