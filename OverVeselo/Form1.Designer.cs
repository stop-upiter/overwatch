namespace OverVeselo
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.heroesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damagePerSecondDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headshotDPSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.singleShotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lifeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reloadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Picture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.heroesDataGridViewTextBoxColumn,
            this.damagePerSecondDataGridViewTextBoxColumn,
            this.headshotDPSDataGridViewTextBoxColumn,
            this.singleShotDataGridViewTextBoxColumn,
            this.lifeDataGridViewTextBoxColumn,
            this.reloadDataGridViewTextBoxColumn,
            this.Picture,
            this.Id});
            this.dataGridView.DataSource = this.unitBindingSource;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView.Location = new System.Drawing.Point(23, 61);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(450, 316);
            this.dataGridView.TabIndex = 0;
            // 
            // heroesDataGridViewTextBoxColumn
            // 
            this.heroesDataGridViewTextBoxColumn.DataPropertyName = "Heroes";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.heroesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.heroesDataGridViewTextBoxColumn.HeaderText = "Heroes";
            this.heroesDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.heroesDataGridViewTextBoxColumn.Name = "heroesDataGridViewTextBoxColumn";
            this.heroesDataGridViewTextBoxColumn.Width = 66;
            // 
            // damagePerSecondDataGridViewTextBoxColumn
            // 
            this.damagePerSecondDataGridViewTextBoxColumn.DataPropertyName = "DamagePerSecond";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.damagePerSecondDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.damagePerSecondDataGridViewTextBoxColumn.HeaderText = "Damage per second";
            this.damagePerSecondDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.damagePerSecondDataGridViewTextBoxColumn.Name = "damagePerSecondDataGridViewTextBoxColumn";
            this.damagePerSecondDataGridViewTextBoxColumn.Width = 86;
            // 
            // headshotDPSDataGridViewTextBoxColumn
            // 
            this.headshotDPSDataGridViewTextBoxColumn.DataPropertyName = "HeadshotDPS";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.headshotDPSDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.headshotDPSDataGridViewTextBoxColumn.HeaderText = "Headshot DPS";
            this.headshotDPSDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.headshotDPSDataGridViewTextBoxColumn.Name = "headshotDPSDataGridViewTextBoxColumn";
            this.headshotDPSDataGridViewTextBoxColumn.Width = 95;
            // 
            // singleShotDataGridViewTextBoxColumn
            // 
            this.singleShotDataGridViewTextBoxColumn.DataPropertyName = "SingleShot";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.singleShotDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.singleShotDataGridViewTextBoxColumn.HeaderText = "Single shot";
            this.singleShotDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.singleShotDataGridViewTextBoxColumn.Name = "singleShotDataGridViewTextBoxColumn";
            this.singleShotDataGridViewTextBoxColumn.Width = 78;
            // 
            // lifeDataGridViewTextBoxColumn
            // 
            this.lifeDataGridViewTextBoxColumn.DataPropertyName = "Life";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.lifeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.lifeDataGridViewTextBoxColumn.HeaderText = "Life";
            this.lifeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.lifeDataGridViewTextBoxColumn.Name = "lifeDataGridViewTextBoxColumn";
            this.lifeDataGridViewTextBoxColumn.Width = 49;
            // 
            // reloadDataGridViewTextBoxColumn
            // 
            this.reloadDataGridViewTextBoxColumn.DataPropertyName = "Reload";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.reloadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.reloadDataGridViewTextBoxColumn.HeaderText = "Reload";
            this.reloadDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.reloadDataGridViewTextBoxColumn.Name = "reloadDataGridViewTextBoxColumn";
            this.reloadDataGridViewTextBoxColumn.Width = 66;
            // 
            // Picture
            // 
            this.Picture.DataPropertyName = "Picture";
            this.Picture.HeaderText = "Picture";
            this.Picture.MinimumWidth = 8;
            this.Picture.Name = "Picture";
            this.Picture.ReadOnly = true;
            this.Picture.Visible = false;
            this.Picture.Width = 65;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 41;
            // 
            // unitBindingSource
            // 
            this.unitBindingSource.DataSource = typeof(InsideLibrary.Unit);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(522, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_choose_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(244, 383);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(229, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "фильтровать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_show_filter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(34, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Выбери своего героя";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 383);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(215, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "выбрать файл";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_choose_file_Click);
            // 
            // panel
            // 
            this.panel.AllowDrop = true;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.textBox6);
            this.panel.Controls.Add(this.textBox5);
            this.panel.Controls.Add(this.textBox4);
            this.panel.Controls.Add(this.comboBox3);
            this.panel.Controls.Add(this.comboBox2);
            this.panel.Controls.Add(this.comboBox1);
            this.panel.Controls.Add(this.button9);
            this.panel.Controls.Add(this.button8);
            this.panel.Controls.Add(this.textBox3);
            this.panel.Controls.Add(this.textBox2);
            this.panel.Controls.Add(this.textBox1);
            this.panel.Location = new System.Drawing.Point(23, 100);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(450, 233);
            this.panel.TabIndex = 11;
            this.panel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Фильтруем";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(290, 134);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(144, 20);
            this.textBox6.TabIndex = 28;
            this.textBox6.Text = "0";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(290, 88);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(144, 20);
            this.textBox5.TabIndex = 27;
            this.textBox5.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(290, 39);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(144, 20);
            this.textBox4.TabIndex = 26;
            this.textBox4.Text = "0";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "",
            ">",
            "<",
            "=",
            ">=",
            "<="});
            this.comboBox3.Location = new System.Drawing.Point(209, 134);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(58, 21);
            this.comboBox3.TabIndex = 25;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "",
            ">",
            "<",
            "=",
            ">=",
            "<="});
            this.comboBox2.Location = new System.Drawing.Point(209, 87);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(58, 21);
            this.comboBox2.TabIndex = 24;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            ">",
            "<",
            "=",
            ">=",
            "<="});
            this.comboBox1.Location = new System.Drawing.Point(209, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(58, 21);
            this.comboBox1.TabIndex = 23;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(21, 203);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(413, 23);
            this.button9.TabIndex = 22;
            this.button9.Text = "скинуть фильтры";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_delete_filter_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(21, 174);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(413, 23);
            this.button8.TabIndex = 21;
            this.button8.Text = "применить фильтры";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_do_filter_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(21, 134);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(171, 20);
            this.textBox3.TabIndex = 10;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Headshot DPS";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 88);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(171, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Life";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(171, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Damage per second";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox7.Location = new System.Drawing.Point(522, 261);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(256, 116);
            this.textBox7.TabIndex = 13;
            this.textBox7.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(522, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 184);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "0.jpg");
            this.imageList1.Images.SetKeyName(1, "1.jpg");
            this.imageList1.Images.SetKeyName(2, "2.jpg");
            this.imageList1.Images.SetKeyName(3, "3.jpg");
            this.imageList1.Images.SetKeyName(4, "4.jpg");
            this.imageList1.Images.SetKeyName(5, "5.jpg");
            this.imageList1.Images.SetKeyName(6, "6.jpg");
            this.imageList1.Images.SetKeyName(7, "7.jpg");
            this.imageList1.Images.SetKeyName(8, "8.jpg");
            this.imageList1.Images.SetKeyName(9, "10.jpg");
            this.imageList1.Images.SetKeyName(10, "11.jpg");
            this.imageList1.Images.SetKeyName(11, "12.jpg");
            this.imageList1.Images.SetKeyName(12, "13.jpg");
            this.imageList1.Images.SetKeyName(13, "14.jpg");
            this.imageList1.Images.SetKeyName(14, "15.jpg");
            this.imageList1.Images.SetKeyName(15, "16.jpg");
            this.imageList1.Images.SetKeyName(16, "19.jpg");
            this.imageList1.Images.SetKeyName(17, "Без названия (2).jpg");
            this.imageList1.Images.SetKeyName(18, "funny-cow-stick-out-tongue-matthias-hauser.jpg");
            this.imageList1.Images.SetKeyName(19, "1424728_five.jpeg");
            this.imageList1.Images.SetKeyName(20, "1553981774155368975.jpg");
            this.imageList1.Images.SetKeyName(21, "a0742c255296764edeb155e40fd0616600005cb8_720_480_c.jpg");
            this.imageList1.Images.SetKeyName(22, "catvshedgehog31.jpg");
            this.imageList1.Images.SetKeyName(23, "mid_275119_6461.jpg");
            this.imageList1.Images.SetKeyName(24, "1356.jpg");
            this.imageList1.Images.SetKeyName(25, "12426.jpg");
            this.imageList1.Images.SetKeyName(26, "shutterstock_796027882.jpg");
            this.imageList1.Images.SetKeyName(27, "unnamed (1).jpg");
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(656, 383);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "сохраненная игра";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_saved_game_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(522, 32);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(122, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "мой игрок";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(656, 32);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(122, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "противник";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "opopo.jpg");
            this.imageList2.Images.SetKeyName(1, "uabrxs1ax28-1.jpg");
            this.imageList2.Images.SetKeyName(2, "78289_original.jpg");
            this.imageList2.Images.SetKeyName(3, "c9deb3465ad279a3d120713a7af86308.jpg");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OverVeselo.Properties.Resources._123;
            this.ClientSize = new System.Drawing.Size(820, 438);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "я разрешаю тебе менять размер формы, чтобы сказать что ты клевый)))";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource unitBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn heroesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn damagePerSecondDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn headshotDPSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn singleShotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lifeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reloadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.ImageList imageList2;
    }
}

