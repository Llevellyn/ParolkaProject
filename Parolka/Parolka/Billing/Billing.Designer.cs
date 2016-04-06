using System.Drawing;

namespace Parolka
{
    partial class Billing
	{
		private System.ComponentModel.IContainer components = null;
		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
            this.ServicesList = new System.Windows.Forms.ComboBox();
            this.ServicesBox = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CostBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ServiceEndBox = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.ServiceStartBox = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.ServiceBox = new System.Windows.Forms.TextBox();
            this.ClientBox = new System.Windows.Forms.ListBox();
            this.ServicesExpireBox = new System.Windows.Forms.ListBox();
            this.MoneyExpired = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ExpiredBox = new System.Windows.Forms.ListBox();
            this.CompanyBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PhoneBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InitialsBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MailBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.CloseImg = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.ExpiredMoney = new System.Windows.Forms.Label();
            this.ExpireMoney = new System.Windows.Forms.Label();
            this.ServicesSort = new System.Windows.Forms.ComboBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ManagerBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // ServicesList
            // 
            this.ServicesList.BackColor = Color.WhiteSmoke;
            this.ServicesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServicesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServicesList.Font = new Font("Segoe UI", 11F);
            this.ServicesList.FormattingEnabled = true;
            this.ServicesList.Location = new Point(229, 251);
            this.ServicesList.Name = "ServicesList";
            this.ServicesList.Size = new Size(148, 28);
            this.ServicesList.TabIndex = 4;
            // 
            // ServicesBox
            // 
            this.ServicesBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServicesBox.Font = new Font("Segoe UI", 10F);
            this.ServicesBox.FormattingEnabled = true;
            this.ServicesBox.ItemHeight = 17;
            this.ServicesBox.Location = new Point(229, 38);
            this.ServicesBox.Name = "ServicesBox";
            this.ServicesBox.Size = new Size(216, 204);
            this.ServicesBox.TabIndex = 0;
            this.ServicesBox.SelectedIndexChanged += new System.EventHandler(this.ServicesBox_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = Color.Transparent;
            this.label11.Font = new Font("Segoe UI", 12F);
            this.label11.ForeColor = Color.White;
            this.label11.Location = new Point(447, 121);
            this.label11.Name = "label11";
            this.label11.Size = new Size(87, 21);
            this.label11.TabIndex = 12;
            this.label11.Text = "Стоимость";
            // 
            // CostBox
            // 
            this.CostBox.BackColor = Color.WhiteSmoke;
            this.CostBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CostBox.Font = new Font("Segoe UI", 13F);
            this.CostBox.Location = new Point(450, 145);
            this.CostBox.Name = "CostBox";
            this.CostBox.Size = new Size(225, 24);
            this.CostBox.TabIndex = 11;
            this.CostBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CostCheck_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = Color.Transparent;
            this.label10.Font = new Font("Segoe UI", 12F);
            this.label10.ForeColor = Color.White;
            this.label10.Location = new Point(447, 69);
            this.label10.Name = "label10";
            this.label10.Size = new Size(87, 21);
            this.label10.TabIndex = 10;
            this.label10.Text = "Менеджер";
            // 
            // ServiceEndBox
            // 
            this.ServiceEndBox.CustomFormat = "yyyy-MM-dd";
            this.ServiceEndBox.Font = new Font("Segoe UI", 11F);
            this.ServiceEndBox.Location = new Point(450, 249);
            this.ServiceEndBox.Name = "ServiceEndBox";
            this.ServiceEndBox.Size = new Size(225, 27);
            this.ServiceEndBox.TabIndex = 7;
            this.ServiceEndBox.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = Color.Transparent;
            this.label8.Font = new Font("Segoe UI", 12F);
            this.label8.ForeColor = Color.White;
            this.label8.Location = new Point(447, 225);
            this.label8.Name = "label8";
            this.label8.Size = new Size(126, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Дата окончания";
            // 
            // ServiceStartBox
            // 
            this.ServiceStartBox.CalendarFont = new Font("Segoe UI", 11F);
            this.ServiceStartBox.CustomFormat = "yyyy-MM-dd";
            this.ServiceStartBox.Font = new Font("Segoe UI", 11F);
            this.ServiceStartBox.Location = new Point(450, 196);
            this.ServiceStartBox.Name = "ServiceStartBox";
            this.ServiceStartBox.Size = new Size(225, 27);
            this.ServiceStartBox.TabIndex = 4;
            this.ServiceStartBox.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = Color.Transparent;
            this.label7.Font = new Font("Segoe UI", 12F);
            this.label7.ForeColor = Color.White;
            this.label7.Location = new Point(447, 172);
            this.label7.Name = "label7";
            this.label7.Size = new Size(98, 21);
            this.label7.TabIndex = 3;
            this.label7.Text = "Дата начала";
            // 
            // ServiceBox
            // 
            this.ServiceBox.BackColor = Color.WhiteSmoke;
            this.ServiceBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServiceBox.Font = new Font("Segoe UI", 16F);
            this.ServiceBox.Location = new Point(450, 38);
            this.ServiceBox.Name = "ServiceBox";
            this.ServiceBox.ReadOnly = true;
            this.ServiceBox.Size = new Size(225, 29);
            this.ServiceBox.TabIndex = 0;
            this.ServiceBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Check_KeyPress);
            // 
            // ClientBox
            // 
            this.ClientBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClientBox.Font = new Font("Segoe UI", 9F);
            this.ClientBox.FormattingEnabled = true;
            this.ClientBox.ItemHeight = 15;
            this.ClientBox.Location = new Point(5, 38);
            this.ClientBox.Name = "ClientBox";
            this.ClientBox.Size = new Size(218, 420);
            this.ClientBox.TabIndex = 1;
            this.ClientBox.SelectedIndexChanged += new System.EventHandler(this.ClientBox_SelectedIndexChanged);
            // 
            // ServicesExpireBox
            // 
            this.ServicesExpireBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServicesExpireBox.Font = new Font("Segoe UI", 10F);
            this.ServicesExpireBox.FormattingEnabled = true;
            this.ServicesExpireBox.ItemHeight = 17;
            this.ServicesExpireBox.Location = new Point(681, 38);
            this.ServicesExpireBox.Name = "ServicesExpireBox";
            this.ServicesExpireBox.Size = new Size(368, 459);
            this.ServicesExpireBox.TabIndex = 0;
            this.ServicesExpireBox.Visible = false;
            this.ServicesExpireBox.SelectedIndexChanged += new System.EventHandler(this.ServicesExpireBox_SelectedIndexChanged);
            // 
            // MoneyExpired
            // 
            this.MoneyExpired.AutoSize = true;
            this.MoneyExpired.BackColor = Color.WhiteSmoke;
            this.MoneyExpired.Font = new Font("Segoe UI", 12F);
            this.MoneyExpired.ForeColor = Color.Black;
            this.MoneyExpired.Location = new Point(297, 3);
            this.MoneyExpired.Name = "MoneyExpired";
            this.MoneyExpired.Size = new Size(36, 21);
            this.MoneyExpired.TabIndex = 3;
            this.MoneyExpired.Text = "null";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = Color.WhiteSmoke;
            this.label14.Font = new Font("Segoe UI", 12F);
            this.label14.ForeColor = Color.Black;
            this.label14.Location = new Point(114, 3);
            this.label14.Name = "label14";
            this.label14.Size = new Size(177, 21);
            this.label14.TabIndex = 2;
            this.label14.Text = "Общая задолженность:";
            // 
            // ExpiredBox
            // 
            this.ExpiredBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExpiredBox.Font = new Font("Segoe UI", 10F);
            this.ExpiredBox.FormattingEnabled = true;
            this.ExpiredBox.ItemHeight = 17;
            this.ExpiredBox.Location = new Point(681, 38);
            this.ExpiredBox.Name = "ExpiredBox";
            this.ExpiredBox.Size = new Size(368, 459);
            this.ExpiredBox.TabIndex = 1;
            this.ExpiredBox.SelectedIndexChanged += new System.EventHandler(this.ExpiredBox_SelectedIndexChanged);
            // 
            // CompanyBox
            // 
            this.CompanyBox.BackColor = Color.WhiteSmoke;
            this.CompanyBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CompanyBox.Font = new Font("Segoe UI", 15F);
            this.CompanyBox.Location = new Point(229, 364);
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new Size(216, 27);
            this.CompanyBox.TabIndex = 3;
            this.CompanyBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Check_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = Color.Transparent;
            this.label3.Font = new Font("Segoe UI", 11F);
            this.label3.ForeColor = Color.White;
            this.label3.Location = new Point(229, 394);
            this.label3.Name = "label3";
            this.label3.Size = new Size(69, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Телефон";
            // 
            // PhoneBox
            // 
            this.PhoneBox.BackColor = Color.WhiteSmoke;
            this.PhoneBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PhoneBox.Font = new Font("Segoe UI", 15F);
            this.PhoneBox.Location = new Point(229, 417);
            this.PhoneBox.Name = "PhoneBox";
            this.PhoneBox.Size = new Size(216, 27);
            this.PhoneBox.TabIndex = 5;
            this.PhoneBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Check_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.Font = new Font("Segoe UI", 11F);
            this.label2.ForeColor = Color.White;
            this.label2.Location = new Point(229, 341);
            this.label2.Name = "label2";
            this.label2.Size = new Size(81, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Компания";
            // 
            // InitialsBox
            // 
            this.InitialsBox.BackColor = Color.WhiteSmoke;
            this.InitialsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InitialsBox.Font = new Font("Segoe UI", 15F);
            this.InitialsBox.Location = new Point(229, 311);
            this.InitialsBox.Name = "InitialsBox";
            this.InitialsBox.Size = new Size(216, 27);
            this.InitialsBox.TabIndex = 1;
            this.InitialsBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Check_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = Color.Transparent;
            this.label4.Font = new Font("Segoe UI", 11F);
            this.label4.ForeColor = Color.White;
            this.label4.Location = new Point(229, 447);
            this.label4.Name = "label4";
            this.label4.Size = new Size(52, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "E-mail";
            // 
            // MailBox
            // 
            this.MailBox.BackColor = Color.WhiteSmoke;
            this.MailBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MailBox.Font = new Font("Segoe UI", 15F);
            this.MailBox.Location = new Point(229, 470);
            this.MailBox.Name = "MailBox";
            this.MailBox.Size = new Size(216, 27);
            this.MailBox.TabIndex = 7;
            this.MailBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Check_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.Font = new Font("Segoe UI", 11F);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(226, 288);
            this.label1.Name = "label1";
            this.label1.Size = new Size(151, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ответственное лицо";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = SystemColors.HotTrack;
            this.pictureBox1.Image = global::Parolka.Properties.Resources.appbar_page_add;
            this.pictureBox1.Location = new Point(383, 251);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.ServiceApplyButton_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = SystemColors.HotTrack;
            this.pictureBox2.Image = global::Parolka.Properties.Resources.appbar_page_delete;
            this.pictureBox2.Location = new Point(417, 251);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(28, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.ServiceRemoveButton_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = SystemColors.HotTrack;
            this.pictureBox4.Image = global::Parolka.Properties.Resources.appbar_user_add;
            this.pictureBox4.Location = new Point(12, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new Size(28, 28);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.NewClientButton_Click);
            this.pictureBox4.MouseEnter += new System.EventHandler(this.pictureBox4_MouseEnter);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = SystemColors.HotTrack;
            this.pictureBox5.Image = global::Parolka.Properties.Resources.appbar_user_delete;
            this.pictureBox5.Location = new Point(80, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new Size(28, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 21;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.ReoveClientButton_Click);
            this.pictureBox5.MouseEnter += new System.EventHandler(this.pictureBox5_MouseEnter);
            this.pictureBox5.MouseLeave += new System.EventHandler(this.pictureBox5_MouseLeave);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = SystemColors.HotTrack;
            this.pictureBox7.Image = global::Parolka.Properties.Resources.appbar_save;
            this.pictureBox7.Location = new Point(46, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new Size(28, 28);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 23;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.SaveButton_Click);
            this.pictureBox7.MouseEnter += new System.EventHandler(this.pictureBox7_MouseEnter);
            this.pictureBox7.MouseLeave += new System.EventHandler(this.pictureBox7_MouseLeave);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new Font("Segoe UI", 11F);
            this.textBox2.Location = new Point(450, 282);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(225, 215);
            this.textBox2.TabIndex = 26;
            this.textBox2.Text = "Комментарий";
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Check_KeyPress);
            // 
            // CloseImg
            // 
            this.CloseImg.BackColor = SystemColors.HotTrack;
            this.CloseImg.Image = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.CloseImg.Location = new Point(1013, 0);
            this.CloseImg.Margin = new System.Windows.Forms.Padding(0);
            this.CloseImg.Name = "CloseImg";
            this.CloseImg.Size = new Size(27, 27);
            this.CloseImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseImg.TabIndex = 28;
            this.CloseImg.TabStop = false;
            this.CloseImg.Click += new System.EventHandler(this.CloseImg_Click);
            this.CloseImg.MouseEnter += new System.EventHandler(this.CloseImg_MouseEnter);
            this.CloseImg.MouseLeave += new System.EventHandler(this.CloseImg_MouseLeave);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = SystemColors.HotTrack;
            this.pictureBox9.Image = global::Parolka.Properties.Resources.appbar_window_minimize;
            this.pictureBox9.InitialImage = global::Parolka.Properties.Resources.appbar_close;
            this.pictureBox9.Location = new Point(986, 0);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new Size(27, 27);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 29;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            this.pictureBox9.MouseEnter += new System.EventHandler(this.pictureBox9_MouseEnter);
            this.pictureBox9.MouseLeave += new System.EventHandler(this.pictureBox9_MouseLeave);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = Color.WhiteSmoke;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new Font("Segoe UI", 18F);
            this.textBox3.Location = new Point(0, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(1049, 32);
            this.textBox3.TabIndex = 30;
            this.textBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox3_MouseDown);
            // 
            // pictureBox16
            // 
            this.pictureBox16.BackColor = SystemColors.HotTrack;
            this.pictureBox16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox16.Image = global::Parolka.Properties.Resources.appbar_arrow_left;
            this.pictureBox16.Location = new Point(922, 0);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new Size(27, 27);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox16.TabIndex = 69;
            this.pictureBox16.TabStop = false;
            this.pictureBox16.Click += new System.EventHandler(this.pictureBox16_Click);
            this.pictureBox16.MouseEnter += new System.EventHandler(this.pictureBox16_MouseEnter);
            this.pictureBox16.MouseLeave += new System.EventHandler(this.pictureBox16_MouseLeave);
            // 
            // ExpiredMoney
            // 
            this.ExpiredMoney.AutoSize = true;
            this.ExpiredMoney.BackColor = Color.WhiteSmoke;
            this.ExpiredMoney.Font = new Font("Segoe UI", 12F);
            this.ExpiredMoney.ForeColor = Color.Black;
            this.ExpiredMoney.Location = new Point(685, 3);
            this.ExpiredMoney.Name = "ExpiredMoney";
            this.ExpiredMoney.Size = new Size(36, 21);
            this.ExpiredMoney.TabIndex = 70;
            this.ExpiredMoney.Text = "null";
            // 
            // ExpireMoney
            // 
            this.ExpireMoney.AutoSize = true;
            this.ExpireMoney.BackColor = Color.WhiteSmoke;
            this.ExpireMoney.Font = new Font("Segoe UI", 12F);
            this.ExpireMoney.ForeColor = Color.Black;
            this.ExpireMoney.Location = new Point(486, 3);
            this.ExpireMoney.Name = "ExpireMoney";
            this.ExpireMoney.Size = new Size(36, 21);
            this.ExpireMoney.TabIndex = 72;
            this.ExpireMoney.Text = "null";
            // 
            // ServicesSort
            // 
            this.ServicesSort.BackColor = Color.White;
            this.ServicesSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServicesSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServicesSort.Font = new Font("Segoe UI", 12F);
            this.ServicesSort.ForeColor = Color.Black;
            this.ServicesSort.FormattingEnabled = true;
            this.ServicesSort.Location = new Point(5, 468);
            this.ServicesSort.Name = "ServicesSort";
            this.ServicesSort.Size = new Size(218, 29);
            this.ServicesSort.TabIndex = 74;
            this.ServicesSort.SelectedIndexChanged += new System.EventHandler(this.ServicesSort_SelectedIndexChanged);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = SystemColors.HotTrack;
            this.pictureBox8.Image = global::Parolka.Properties.Resources.appbar_refresh;
            this.pictureBox8.Location = new Point(955, 0);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new Size(27, 27);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 75;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            this.pictureBox8.MouseEnter += new System.EventHandler(this.pictureBox8_MouseEnter);
            this.pictureBox8.MouseLeave += new System.EventHandler(this.pictureBox8_MouseLeave);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new Font("Segoe UI", 10F);
            this.button1.ForeColor = Color.White;
            this.button1.Location = new Point(1012, 38);
            this.button1.Name = "button1";
            this.button1.Size = new Size(39, 233);
            this.button1.TabIndex = 76;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new Font("Segoe UI", 10F);
            this.button2.ForeColor = Color.White;
            this.button2.Location = new Point(1012, 271);
            this.button2.Name = "button2";
            this.button2.Size = new Size(39, 226);
            this.button2.TabIndex = 77;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ManagerBox
            // 
            this.ManagerBox.BackColor = Color.WhiteSmoke;
            this.ManagerBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManagerBox.Font = new Font("Segoe UI", 10F);
            this.ManagerBox.FormattingEnabled = true;
            this.ManagerBox.Items.AddRange(new object[] {
            "Илья Ларцев",
            "Андрей Семенычев"});
            this.ManagerBox.Location = new Point(450, 93);
            this.ManagerBox.Name = "ManagerBox";
            this.ManagerBox.Size = new Size(225, 25);
            this.ManagerBox.TabIndex = 78;
            this.ManagerBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Check_KeyPress);
            // 
            // button3
            // 
            this.button3.BackColor = SystemColors.HotTrack;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = Color.White;
            this.button3.Location = new Point(801, -1);
            this.button3.Name = "button3";
            this.button3.Size = new Size(115, 28);
            this.button3.TabIndex = 79;
            this.button3.Text = "Экспорт в CSV";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = Color.WhiteSmoke;
            this.label5.Font = new Font("Segoe UI", 12F);
            this.label5.ForeColor = Color.Black;
            this.label5.Location = new Point(371, 3);
            this.label5.Name = "label5";
            this.label5.Size = new Size(109, 21);
            this.label5.TabIndex = 80;
            this.label5.Text = "К продлению:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = Color.WhiteSmoke;
            this.label6.Font = new Font("Segoe UI", 12F);
            this.label6.ForeColor = Color.Black;
            this.label6.Location = new Point(558, 3);
            this.label6.Name = "label6";
            this.label6.Size = new Size(121, 21);
            this.label6.TabIndex = 81;
            this.label6.Text = "Непродленные:";
            // 
            // Billing
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.ForestGreen;
            this.ClientSize = new Size(1049, 504);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ExpireMoney);
            this.Controls.Add(this.ExpiredMoney);
            this.Controls.Add(this.MoneyExpired);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ManagerBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.ServicesSort);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.CloseImg);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ClientBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ServicesList);
            this.Controls.Add(this.MailBox);
            this.Controls.Add(this.CostBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ServicesExpireBox);
            this.Controls.Add(this.ServiceEndBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ServicesBox);
            this.Controls.Add(this.ServiceStartBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.InitialsBox);
            this.Controls.Add(this.ServiceBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PhoneBox);
            this.Controls.Add(this.ExpiredBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CompanyBox);
            this.Controls.Add(this.textBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Billing";
            this.Text = "Parolka Billing";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ListBox ClientBox;
        private System.Windows.Forms.ComboBox ServicesList;
        private System.Windows.Forms.ListBox ServicesBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker ServiceEndBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker ServiceStartBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ServiceBox;
        private System.Windows.Forms.ListBox ServicesExpireBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox CostBox;
        private System.Windows.Forms.Label MoneyExpired;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox ExpiredBox;
        private System.Windows.Forms.TextBox CompanyBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PhoneBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InitialsBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MailBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox CloseImg;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.Label ExpiredMoney;
        private System.Windows.Forms.Label ExpireMoney;
        private System.Windows.Forms.ComboBox ServicesSort;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox ManagerBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
