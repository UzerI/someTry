namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.hlbFIO = new System.Windows.Forms.Label();
            this.hlbDate = new System.Windows.Forms.Label();
            this.hlbDprtmnt = new System.Windows.Forms.Label();
            this.hlbMtd = new System.Windows.Forms.Label();
            this.hlbIstchnk = new System.Windows.Forms.Label();
            this.hlbFrml = new System.Windows.Forms.Label();
            this.hlbApCmp = new System.Windows.Forms.Label();
            this.hlbBigMnm = new System.Windows.Forms.Label();
            this.hlbFTPDP = new System.Windows.Forms.Label();
            this.hlbChckRE = new System.Windows.Forms.Label();
            this.hlbChckPP = new System.Windows.Forms.Label();
            this.hlbFullName = new System.Windows.Forms.Label();
            this.hlbChckSchm = new System.Windows.Forms.Label();
            this.vcbFullName = new System.Windows.Forms.ComboBox();
            this.vlbMtd = new System.Windows.Forms.Label();
            this.vlbFrml = new System.Windows.Forms.Label();
            this.vtbIstchnk = new System.Windows.Forms.TextBox();
            this.vcbApCmp = new System.Windows.Forms.ComboBox();
            this.vtbBigMnm = new System.Windows.Forms.TextBox();
            this.vlbFTPDP = new System.Windows.Forms.Label();
            this.vcbDprtmnt = new System.Windows.Forms.ComboBox();
            this.vcbFIO = new System.Windows.Forms.ComboBox();
            this.vdtpDate = new System.Windows.Forms.DateTimePicker();
            this.vcbMnm = new System.Windows.Forms.ComboBox();
            this.lbMnmNmbr = new System.Windows.Forms.Label();
            this.vtbNmbr = new System.Windows.Forms.TextBox();
            this.btDownLoad = new System.Windows.Forms.Button();
            this.btSpravPath = new System.Windows.Forms.Button();
            this.hlbSpravPath = new System.Windows.Forms.Label();
            this.vtbSpravPath = new System.Windows.Forms.TextBox();
            this.fbdSpravPath = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.vcbChckPP = new System.Windows.Forms.ComboBox();
            this.vcbChckRE = new System.Windows.Forms.ComboBox();
            this.vcbChckSchm = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(376, 350);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // hlbFIO
            // 
            this.hlbFIO.AutoSize = true;
            this.hlbFIO.Location = new System.Drawing.Point(11, 304);
            this.hlbFIO.Name = "hlbFIO";
            this.hlbFIO.Size = new System.Drawing.Size(88, 13);
            this.hlbFIO.TabIndex = 5;
            this.hlbFIO.Text = "Добавил (ФИО)";
            // 
            // hlbDate
            // 
            this.hlbDate.AutoSize = true;
            this.hlbDate.Location = new System.Drawing.Point(11, 324);
            this.hlbDate.Name = "hlbDate";
            this.hlbDate.Size = new System.Drawing.Size(96, 13);
            this.hlbDate.TabIndex = 6;
            this.hlbDate.Text = "Дата добавления";
            // 
            // hlbDprtmnt
            // 
            this.hlbDprtmnt.AutoSize = true;
            this.hlbDprtmnt.Location = new System.Drawing.Point(11, 284);
            this.hlbDprtmnt.Name = "hlbDprtmnt";
            this.hlbDprtmnt.Size = new System.Drawing.Size(87, 13);
            this.hlbDprtmnt.TabIndex = 7;
            this.hlbDprtmnt.Text = "Подразделение";
            // 
            // hlbMtd
            // 
            this.hlbMtd.AutoSize = true;
            this.hlbMtd.Location = new System.Drawing.Point(11, 106);
            this.hlbMtd.Name = "hlbMtd";
            this.hlbMtd.Size = new System.Drawing.Size(47, 13);
            this.hlbMtd.TabIndex = 8;
            this.hlbMtd.Text = "Методы";
            // 
            // hlbIstchnk
            // 
            this.hlbIstchnk.AutoSize = true;
            this.hlbIstchnk.Location = new System.Drawing.Point(11, 144);
            this.hlbIstchnk.Name = "hlbIstchnk";
            this.hlbIstchnk.Size = new System.Drawing.Size(124, 13);
            this.hlbIstchnk.TabIndex = 9;
            this.hlbIstchnk.Text = "Источник (рад.методы)";
            // 
            // hlbFrml
            // 
            this.hlbFrml.AutoSize = true;
            this.hlbFrml.Location = new System.Drawing.Point(11, 124);
            this.hlbFrml.Name = "hlbFrml";
            this.hlbFrml.Size = new System.Drawing.Size(102, 13);
            this.hlbFrml.TabIndex = 10;
            this.hlbFrml.Text = "Формула (ВАК;РК)";
            // 
            // hlbApCmp
            // 
            this.hlbApCmp.AutoSize = true;
            this.hlbApCmp.Location = new System.Drawing.Point(11, 164);
            this.hlbApCmp.Name = "hlbApCmp";
            this.hlbApCmp.Size = new System.Drawing.Size(133, 13);
            this.hlbApCmp.TabIndex = 11;
            this.hlbApCmp.Text = "Аппаратурный комплекс";
            // 
            // hlbBigMnm
            // 
            this.hlbBigMnm.AutoSize = true;
            this.hlbBigMnm.Location = new System.Drawing.Point(11, 184);
            this.hlbBigMnm.Name = "hlbBigMnm";
            this.hlbBigMnm.Size = new System.Drawing.Size(103, 13);
            this.hlbBigMnm.TabIndex = 12;
            this.hlbBigMnm.Text = "Большое название";
            // 
            // hlbFTPDP
            // 
            this.hlbFTPDP.AutoSize = true;
            this.hlbFTPDP.Location = new System.Drawing.Point(11, 204);
            this.hlbFTPDP.Name = "hlbFTPDP";
            this.hlbFTPDP.Size = new System.Drawing.Size(27, 13);
            this.hlbFTPDP.TabIndex = 13;
            this.hlbFTPDP.Text = "FTP";
            // 
            // hlbChckRE
            // 
            this.hlbChckRE.AutoSize = true;
            this.hlbChckRE.Location = new System.Drawing.Point(11, 244);
            this.hlbChckRE.Name = "hlbChckRE";
            this.hlbChckRE.Size = new System.Drawing.Size(21, 13);
            this.hlbChckRE.TabIndex = 16;
            this.hlbChckRE.Text = "РЭ";
            // 
            // hlbChckPP
            // 
            this.hlbChckPP.AutoSize = true;
            this.hlbChckPP.Location = new System.Drawing.Point(11, 224);
            this.hlbChckPP.Name = "hlbChckPP";
            this.hlbChckPP.Size = new System.Drawing.Size(50, 13);
            this.hlbChckPP.TabIndex = 17;
            this.hlbChckPP.Text = "Паспорт";
            // 
            // hlbFullName
            // 
            this.hlbFullName.AutoSize = true;
            this.hlbFullName.Location = new System.Drawing.Point(11, 87);
            this.hlbFullName.Name = "hlbFullName";
            this.hlbFullName.Size = new System.Drawing.Size(74, 13);
            this.hlbFullName.TabIndex = 18;
            this.hlbFullName.Text = "Имя прибора";
            // 
            // hlbChckSchm
            // 
            this.hlbChckSchm.AutoSize = true;
            this.hlbChckSchm.Location = new System.Drawing.Point(11, 264);
            this.hlbChckSchm.Name = "hlbChckSchm";
            this.hlbChckSchm.Size = new System.Drawing.Size(39, 13);
            this.hlbChckSchm.TabIndex = 38;
            this.hlbChckSchm.Text = "Схема";
            // 
            // vcbFullName
            // 
            this.vcbFullName.FormattingEnabled = true;
            this.vcbFullName.Items.AddRange(new object[] {
            "Иванова Ася",
            "Сидорова Аня",
            "Васина Катя",
            "Колина Оля",
            "Смирнова Катя"});
            this.vcbFullName.Location = new System.Drawing.Point(151, 87);
            this.vcbFullName.Name = "vcbFullName";
            this.vcbFullName.Size = new System.Drawing.Size(300, 21);
            this.vcbFullName.TabIndex = 39;
            this.vcbFullName.TextChanged += new System.EventHandler(this.vcbFullName_TextChanged);
            this.vcbFullName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.vcbFullName_KeyUp);
            // 
            // vlbMtd
            // 
            this.vlbMtd.Location = new System.Drawing.Point(151, 106);
            this.vlbMtd.Name = "vlbMtd";
            this.vlbMtd.Size = new System.Drawing.Size(300, 13);
            this.vlbMtd.TabIndex = 40;
            // 
            // vlbFrml
            // 
            this.vlbFrml.Location = new System.Drawing.Point(151, 124);
            this.vlbFrml.Name = "vlbFrml";
            this.vlbFrml.Size = new System.Drawing.Size(300, 13);
            this.vlbFrml.TabIndex = 41;
            // 
            // vtbIstchnk
            // 
            this.vtbIstchnk.Location = new System.Drawing.Point(151, 144);
            this.vtbIstchnk.Name = "vtbIstchnk";
            this.vtbIstchnk.Size = new System.Drawing.Size(300, 20);
            this.vtbIstchnk.TabIndex = 42;
            // 
            // vcbApCmp
            // 
            this.vcbApCmp.FormattingEnabled = true;
            this.vcbApCmp.Location = new System.Drawing.Point(151, 164);
            this.vcbApCmp.Name = "vcbApCmp";
            this.vcbApCmp.Size = new System.Drawing.Size(300, 21);
            this.vcbApCmp.TabIndex = 43;
            // 
            // vtbBigMnm
            // 
            this.vtbBigMnm.Location = new System.Drawing.Point(151, 184);
            this.vtbBigMnm.Name = "vtbBigMnm";
            this.vtbBigMnm.Size = new System.Drawing.Size(300, 20);
            this.vtbBigMnm.TabIndex = 44;
            // 
            // vlbFTPDP
            // 
            this.vlbFTPDP.Location = new System.Drawing.Point(151, 204);
            this.vlbFTPDP.Name = "vlbFTPDP";
            this.vlbFTPDP.Size = new System.Drawing.Size(300, 13);
            this.vlbFTPDP.TabIndex = 45;
            this.vlbFTPDP.Click += new System.EventHandler(this.vlbFTPDP_Click);
            // 
            // vcbDprtmnt
            // 
            this.vcbDprtmnt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.vcbDprtmnt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.vcbDprtmnt.FormattingEnabled = true;
            this.vcbDprtmnt.Location = new System.Drawing.Point(151, 284);
            this.vcbDprtmnt.Name = "vcbDprtmnt";
            this.vcbDprtmnt.Size = new System.Drawing.Size(300, 21);
            this.vcbDprtmnt.TabIndex = 49;
            // 
            // vcbFIO
            // 
            this.vcbFIO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.vcbFIO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.vcbFIO.FormattingEnabled = true;
            this.vcbFIO.Location = new System.Drawing.Point(151, 304);
            this.vcbFIO.Name = "vcbFIO";
            this.vcbFIO.Size = new System.Drawing.Size(300, 21);
            this.vcbFIO.TabIndex = 50;
            this.vcbFIO.KeyUp += new System.Windows.Forms.KeyEventHandler(this.vcbFIO_KeyUp);
            // 
            // vdtpDate
            // 
            this.vdtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.vdtpDate.Location = new System.Drawing.Point(151, 324);
            this.vdtpDate.Name = "vdtpDate";
            this.vdtpDate.Size = new System.Drawing.Size(91, 20);
            this.vdtpDate.TabIndex = 51;
            // 
            // vcbMnm
            // 
            this.vcbMnm.FormattingEnabled = true;
            this.vcbMnm.Location = new System.Drawing.Point(151, 66);
            this.vcbMnm.Name = "vcbMnm";
            this.vcbMnm.Size = new System.Drawing.Size(211, 21);
            this.vcbMnm.TabIndex = 53;
            this.vcbMnm.SelectedIndexChanged += new System.EventHandler(this.vcbMnm_SelectedIndexChanged);
            this.vcbMnm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vcbMnm_KeyDown);
            // 
            // lbMnmNmbr
            // 
            this.lbMnmNmbr.Location = new System.Drawing.Point(11, 66);
            this.lbMnmNmbr.Name = "lbMnmNmbr";
            this.lbMnmNmbr.Size = new System.Drawing.Size(133, 20);
            this.lbMnmNmbr.TabIndex = 54;
            this.lbMnmNmbr.Text = "Название/номер";
            // 
            // vtbNmbr
            // 
            this.vtbNmbr.Location = new System.Drawing.Point(360, 66);
            this.vtbNmbr.Name = "vtbNmbr";
            this.vtbNmbr.Size = new System.Drawing.Size(91, 20);
            this.vtbNmbr.TabIndex = 55;
            this.vtbNmbr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.vtbNmbr_KeyUp);
            // 
            // btDownLoad
            // 
            this.btDownLoad.Location = new System.Drawing.Point(295, 350);
            this.btDownLoad.Name = "btDownLoad";
            this.btDownLoad.Size = new System.Drawing.Size(75, 23);
            this.btDownLoad.TabIndex = 57;
            this.btDownLoad.Text = "Загрузить";
            this.btDownLoad.UseVisualStyleBackColor = true;
            this.btDownLoad.Click += new System.EventHandler(this.btDownLoad_Click);
            // 
            // btSpravPath
            // 
            this.btSpravPath.Location = new System.Drawing.Point(427, 17);
            this.btSpravPath.Name = "btSpravPath";
            this.btSpravPath.Size = new System.Drawing.Size(25, 20);
            this.btSpravPath.TabIndex = 58;
            this.btSpravPath.Text = "...";
            this.btSpravPath.UseVisualStyleBackColor = true;
            this.btSpravPath.Click += new System.EventHandler(this.btSpravPath_Click);
            // 
            // hlbSpravPath
            // 
            this.hlbSpravPath.AutoSize = true;
            this.hlbSpravPath.Location = new System.Drawing.Point(11, 17);
            this.hlbSpravPath.Name = "hlbSpravPath";
            this.hlbSpravPath.Size = new System.Drawing.Size(105, 13);
            this.hlbSpravPath.TabIndex = 60;
            this.hlbSpravPath.Text = "Путь справочников";
            // 
            // vtbSpravPath
            // 
            this.vtbSpravPath.Location = new System.Drawing.Point(151, 17);
            this.vtbSpravPath.Name = "vtbSpravPath";
            this.vtbSpravPath.Size = new System.Drawing.Size(277, 20);
            this.vtbSpravPath.TabIndex = 61;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 23);
            this.button1.TabIndex = 62;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // vcbChckPP
            // 
            this.vcbChckPP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.vcbChckPP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.vcbChckPP.DisplayMember = "(нет)";
            this.vcbChckPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vcbChckPP.FormattingEnabled = true;
            this.vcbChckPP.Location = new System.Drawing.Point(151, 224);
            this.vcbChckPP.Name = "vcbChckPP";
            this.vcbChckPP.Size = new System.Drawing.Size(91, 21);
            this.vcbChckPP.TabIndex = 64;
            // 
            // vcbChckRE
            // 
            this.vcbChckRE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.vcbChckRE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.vcbChckRE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vcbChckRE.FormattingEnabled = true;
            this.vcbChckRE.Location = new System.Drawing.Point(151, 244);
            this.vcbChckRE.Name = "vcbChckRE";
            this.vcbChckRE.Size = new System.Drawing.Size(91, 21);
            this.vcbChckRE.TabIndex = 65;
            // 
            // vcbChckSchm
            // 
            this.vcbChckSchm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.vcbChckSchm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.vcbChckSchm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vcbChckSchm.FormattingEnabled = true;
            this.vcbChckSchm.Location = new System.Drawing.Point(151, 264);
            this.vcbChckSchm.Name = "vcbChckSchm";
            this.vcbChckSchm.Size = new System.Drawing.Size(91, 21);
            this.vcbChckSchm.TabIndex = 66;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 414);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 67;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(507, 493);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.vcbChckSchm);
            this.Controls.Add(this.vcbChckRE);
            this.Controls.Add(this.vcbChckPP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vtbSpravPath);
            this.Controls.Add(this.hlbSpravPath);
            this.Controls.Add(this.btSpravPath);
            this.Controls.Add(this.btDownLoad);
            this.Controls.Add(this.vtbNmbr);
            this.Controls.Add(this.lbMnmNmbr);
            this.Controls.Add(this.vcbMnm);
            this.Controls.Add(this.vdtpDate);
            this.Controls.Add(this.vcbFIO);
            this.Controls.Add(this.vcbDprtmnt);
            this.Controls.Add(this.vlbFTPDP);
            this.Controls.Add(this.vtbBigMnm);
            this.Controls.Add(this.vcbApCmp);
            this.Controls.Add(this.vtbIstchnk);
            this.Controls.Add(this.vlbFrml);
            this.Controls.Add(this.vlbMtd);
            this.Controls.Add(this.vcbFullName);
            this.Controls.Add(this.hlbChckSchm);
            this.Controls.Add(this.hlbFullName);
            this.Controls.Add(this.hlbChckPP);
            this.Controls.Add(this.hlbChckRE);
            this.Controls.Add(this.hlbFTPDP);
            this.Controls.Add(this.hlbBigMnm);
            this.Controls.Add(this.hlbApCmp);
            this.Controls.Add(this.hlbFrml);
            this.Controls.Add(this.hlbIstchnk);
            this.Controls.Add(this.hlbMtd);
            this.Controls.Add(this.hlbDprtmnt);
            this.Controls.Add(this.hlbDate);
            this.Controls.Add(this.hlbFIO);
            this.Controls.Add(this.btSave);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label hlbFIO;
        private System.Windows.Forms.Label hlbDate;
        private System.Windows.Forms.Label hlbDprtmnt;
        private System.Windows.Forms.Label hlbMtd;
        private System.Windows.Forms.Label hlbIstchnk;
        private System.Windows.Forms.Label hlbFrml;
        private System.Windows.Forms.Label hlbApCmp;
        private System.Windows.Forms.Label hlbBigMnm;
        private System.Windows.Forms.Label hlbFTPDP;
        private System.Windows.Forms.Label hlbChckRE;
        private System.Windows.Forms.Label hlbChckPP;
        private System.Windows.Forms.Label hlbFullName;
        private System.Windows.Forms.Label hlbChckSchm;
        private System.Windows.Forms.ComboBox vcbFullName;
        private System.Windows.Forms.Label vlbMtd;
        private System.Windows.Forms.Label vlbFrml;
        private System.Windows.Forms.TextBox vtbIstchnk;
        private System.Windows.Forms.ComboBox vcbApCmp;
        private System.Windows.Forms.TextBox vtbBigMnm;
        private System.Windows.Forms.Label vlbFTPDP;
        private System.Windows.Forms.ComboBox vcbDprtmnt;
        private System.Windows.Forms.ComboBox vcbFIO;
        private System.Windows.Forms.DateTimePicker vdtpDate;
        private System.Windows.Forms.ComboBox vcbMnm;
        private System.Windows.Forms.Label lbMnmNmbr;
        private System.Windows.Forms.TextBox vtbNmbr;
        private System.Windows.Forms.Button btDownLoad;
        private System.Windows.Forms.Button btSpravPath;
        private System.Windows.Forms.Label hlbSpravPath;
        private System.Windows.Forms.TextBox vtbSpravPath;
        private System.Windows.Forms.FolderBrowserDialog fbdSpravPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox vcbChckPP;
        private System.Windows.Forms.ComboBox vcbChckRE;
        private System.Windows.Forms.ComboBox vcbChckSchm;
        private System.Windows.Forms.TextBox textBox1;
    }
}

