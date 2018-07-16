using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using BytesRoad.Net.Ftp;
using System.IO; // это для работы с файлами
//using System.Xml.Serialization; //это для сохранения классов — что и есть серилизация (стрёмное слово)

//using System.Collections.ObjectModel; //ObservableCollection 
//using System.Collections.Specialized; //ObservableCollection
using System.Text.RegularExpressions; 

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {

        public Form1()

        {
            InitializeComponent();
            /*

             */
        }

        ExcelTable PRBPNG = new ExcelTable("A", "AC", 1, "PRBPNG", "B");

        public AutoCompleteStringCollection ComboBoxAutoCompleteList(ref ComboBox ComboBoxSource)
        {
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            coll.Clear();
            for (int i = 0; i < ComboBoxSource.Items.Count; i++)
            {
                if (ComboBoxSource.Items[i].ToString().Contains(ComboBoxSource.Text))
                {
                    coll.Add(ComboBoxSource.Items[i].ToString());
                }
            }

            return coll;
        }
        //protected override void OnKeyPress(KeyPressEventArgs e, string sPattern)
        //{

        //    string s = new string(e.KeyChar, 1);
        //    if (Regex.IsMatch(s, sPattern))//@"[а-яА-ЯёЁa-zA-Z0-9' /-(),.+]$"))
        //    {
        //        MessageBox.Show(s);
        //    }
        //}

        #region XmlProc action
        BindingSource bsFIO = new BindingSource();
        cxmlProc xmlProc = new cxmlProc(); //экземпляр класса с настройками
        //SerializableDictionary<string, string> xdPRBRecToCntrls = new SerializableDictionary<string, string>();
        //Запись настроек
        private void writeSetting()
        {
            //Запись значения в ComboBox1
            xmlProc.xmlData.xfSpravPath = vtbSpravPath.Text;
            xmlProc.WriteXml();
        }
        //Чтение настроек
        private void readSetting()
        {
            xmlProc.ReadXml();
            vtbSpravPath.Text = xmlProc.xmlData.xfSpravPath;
            bsFIO.DataSource = xmlProc.xmlData.xlFios;
            vcbFIO.DataSource = bsFIO;
            vcbDprtmnt.DataSource = xmlProc.xmlData.xlDprtmnt;
            for (int i = 0; i < xmlProc.xmlData.xlNoneExist.Count; i++)
            {
                vcbChckPP.Items.Add(xmlProc.xmlData.xlNoneExist[i]);
                vcbChckRE.Items.Add(xmlProc.xmlData.xlNoneExist[i]);
                vcbChckSchm.Items.Add(xmlProc.xmlData.xlNoneExist[i]);
            }
            vcbChckPP.SelectedIndex = 0;
            vcbChckRE.SelectedIndex = 0;
            vcbChckSchm.SelectedIndex = 0;
        }
        #endregion

        // Чтение из книги Excel.


        // вот этот самый класс, который мы будем сохранять

        //***FTP***

        FtpClient client = new FtpClient();
        //Excel.Application ExcelApp = new Excel.Application(); восстановить позже
        //Подключение к ФТП
        private void ConnectFTP()
        {
            try
            {
                client.PassiveMode = FTPParams.Passive;
                client.Connect(FTPParams.FtpTimeout, FTPParams.FtpServer, FTPParams.FtpPort);
                client.Login(FTPParams.FtpTimeout, FTPParams.Username, FTPParams.Password);
                //client.GetFile(FTPParams.FtpTimeout);
                //client.Sa
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        public string fnPrbPNG = "ПриборыПНГ.xlsx";
        public string ftpSprav = "INNOVATION/WRITING/ILPST/SPRAV/";//ПриборыПНГ.xlsx";
        private void DownloadPrbPNG()
        {
            try
            {
                client.GetFile(FTPParams.FtpTimeout, vtbSpravPath.Text + Path.DirectorySeparatorChar + fnPrbPNG, ftpSprav + fnPrbPNG);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeletePrbPNGFromFTP()
        {
            client.DeleteFile(FTPParams.FtpTimeout, ftpSprav + fnPrbPNG);
        }


        // Установите метку заголовка и значения в ListBox.
        // Получить заголовок из ячейки (строка, col). Получить значения из
        // cell (row + 1, col) в конец столбца.
        private void SetTitleAndListValues(Excel.Worksheet sheet,
            int row, int col, Label lbl, ListBox lst)
        {
            Excel.Range range;

            // Установите заголовок.
            range = (Excel.Range)sheet.Cells[row, col];
            lbl.Text = (string)range.Value2;
            lbl.ForeColor = System.Drawing.ColorTranslator.FromOle(
                (int)(double)range.Font.Color);
            lbl.BackColor = System.Drawing.ColorTranslator.FromOle(
                (int)(double)range.Interior.Color);

            // Получаем значения.
            // Найти последнюю ячейку в столбце.
            range = (Excel.Range)sheet.Columns[col, Type.Missing];
            Excel.Range last_cell =
                range.get_End(Excel.XlDirection.xlDown);

            // Получить диапазон, содержащий значения.
            Excel.Range first_cell =
                (Excel.Range)sheet.Cells[row + 1, col];
            Excel.Range value_range =
                (Excel.Range)sheet.get_Range(first_cell, last_cell);

            // Получаем значения.
            object[,] range_values = (object[,])value_range.Value2;

            // Преобразуем это в одномерный массив.
            // Обратите внимание, что массив Range имеет нижние границы 1.
            int num_items = range_values.GetUpperBound(0);
            string[] values1 = new string[num_items];
            for (int i = 0; i < num_items; i++)
            {
                values1[i] = (string)range_values[i + 1, 1];
            }

            // Отображение значений в ListBox.
            lst.DataSource = values1;
        }
        private void SetTitleAndListValues(Excel.Worksheet sheet,
            int row, int col, Label lbl, ComboBox Cmb)
        {
            Excel.Range range;

            // Установите заголовок.
            range = (Excel.Range)sheet.Cells[row, col];
            lbl.Text = (string)range.Value2;
            lbl.ForeColor = System.Drawing.ColorTranslator.FromOle(
                (int)(double)range.Font.Color);
            lbl.BackColor = System.Drawing.ColorTranslator.FromOle(
                (int)(double)range.Interior.Color);

            // Получаем значения.
            // Найти последнюю ячейку в столбце.
            range = (Excel.Range)sheet.Columns[col, Type.Missing];
            Excel.Range last_cell =
                range.get_End(Excel.XlDirection.xlDown);

            // Получить диапазон, содержащий значения.
            Excel.Range first_cell =
                (Excel.Range)sheet.Cells[row + 1, col];
            Excel.Range value_range =
                (Excel.Range)sheet.get_Range(first_cell, last_cell);

            // Получаем значения.
            object[,] range_values = (object[,])value_range.Value2;

            // Преобразуем это в одномерный массив.
            // Обратите внимание, что массив Range имеет нижние границы 1.
            int num_items = range_values.GetUpperBound(0);
            string[] values1 = new string[num_items];
            for (int i = 0; i < num_items; i++)
            {
                values1[i] = (string)range_values[i + 1, 1];
            }

            // Отображение значений в ListBox.
            Cmb.DataSource = values1;
        }
        private void UploadPrbPNG()
        {            
            try
            {                
                //client.PutFile(FTPParams.FtpTimeout, vtbSpravPath.Text + Path.DirectorySeparatorChar + fnPrbPNG);
                client.ChangeDirectory(FTPParams.FtpTimeout, ftpSprav);                                            
                client.PutFile(FTPParams.FtpTimeout, fnPrbPNG, vtbSpravPath.Text + Path.DirectorySeparatorChar + fnPrbPNG);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Отключение от FTP
        private void DisconnectFTP()
        {
            client.Disconnect(FTPParams.FtpTimeout);
            //disconnect.Enabled = false;
            //connect.Enabled = true;
            //contextMenuStrip1.Enabled = false;
        }

       
        //***FTP***//
        private void button1_Click(object sender, EventArgs e)
        {
            //FtpClient client = new FtpClient();
            //client = null;
            //client.Disconnect(TimeoutFTP);
            
            double x;
            //string s;
            // Получить объект приложения Excel.
            Excel.Application ExcelApp = new Excel.Application();//ApplicationClass();

            // Сделать Excel видимым (необязательно).
            //ExcelApp.Visible = true;

            // Откройте рабочую книгу только для чтения.
            Excel.Workbook workbook = ExcelApp.Workbooks.Open(@"D:\_Las_Samples\1.xlsx");//,Type.Missing,false);

            // Получить первый рабочий лист.
            Excel.Worksheet sheet = (Excel.Worksheet)workbook.Sheets["Лист1"];

            // Получить заголовки и значения.
            
            //MessageBox.Show(sheet.get_Range("A1").Value.ToString()); //работает
            x = sheet.get_Range("A1").Value;
            sheet.Cells[1, 1] = x + 1;
            //sheet.Cells[1,1]=8;            
            //x = (int)sheet.Cells(1, 2);
            //sheet.Cells[1,2]=x+1;
            //MessageBox.Show(sheet.Range("A1"));
            //SetTitleAndListValues(sheet, 1, 1, lblTitle1, lstItems1);
            //SetTitleAndListValues(sheet, 1, 2, lblTitle2, lstItems2);




            // Закройте книгу без сохранения изменений.
            workbook.Close(true);//, Type.Missing, Type.Missing);

            // Закройте сервер Excel.
            ExcelApp.Quit();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readSetting();
            // загружаем данные из файла program.xml 
            //using (Stream stream = new FileStream("data.xml", FileMode.Open))
            //{
            //    //XmlSerializer serializer = new XmlSerializer(typeof(xmlData));
            //    //// в тут же созданную копию класса iniSettings под именем iniSet
            //    //xmlData xmlData_ = (xmlData)serializer.Deserialize(stream);
            //    //vtbSpravPath.Text = xmlData_.xfSpravPath;// = new Point(iniSet.X_pos, iniSet.Y_pos);
            //    ////xmlData_.xfPrbFTPfpPrbPNG = "INNOVATION/WRITING/ILPST/SPRAV/";
            //    ////vtbSpravPath.Text = xmlData_.xfSpravPath;
            //}           
            
        }

        private void vlbFTPDP_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2("vlbFTPDP");
            newForm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            writeSetting();
            // создаём копию класса iniSettings с именем iniSet
            //xmlData xmlData_ = new xmlData();
            //// записываем в переменные класса текущие координаты верхнего левого угла окна
            //xmlData_.xfSpravPath = vtbSpravPath.Text;
            ////xmlData_.xfPrbFTPfpPrbPNG = "INNOVATION/WRITING/ILPST/SPRAV/";
            //// выкидываем класс iniSet целиком в файл program.xml
            //using (Stream writer = new FileStream("data.xml", FileMode.Create))
            //{
            //    XmlSerializer serializer = new XmlSerializer(typeof(xmlData));
            //    serializer.Serialize(writer, xmlData_);
            //}
        }

        private void btSpravPath_Click(object sender, EventArgs e)
        {
            if (fbdSpravPath.ShowDialog() == DialogResult.OK)
            {
                vtbSpravPath.Text = fbdSpravPath.SelectedPath;    
            }
        }
        public string shPrbPNG = "PRBPNG";
        public string shPrbTypes = "PRBTYPES";
        private void btDownLoad_Click(object sender, EventArgs e)
        {
            ConnectFTP();
            DownloadPrbPNG();
            DeletePrbPNGFromFTP();
            //Client.
            DisconnectFTP();
            //--vtbSpravPath.Text + Path.DirectorySeparatorChar + fnPrbPNG
            
            PRBPNG.LoadFromFile(vtbSpravPath.Text + Path.DirectorySeparatorChar + fnPrbPNG);
            PRBPNG.ExportRecToForm(xmlProc.xmlData.xlPRBCntrlsValues, xmlProc.xmlData.xlPRBRecKeys, PRBPNG.TABLE.Count - 1);
            //MessageBox.Show(PRBPNG.KEYCOLL[1]);
            // Получить объект приложения Excel.
            //Excel.Application ExcelApp = new Excel.Application();
            //// Откройте рабочую книгу только для чтения.
            //Excel.Workbook workbook = ExcelApp.Workbooks.Open(
            //    vtbSpravPath.Text + Path.DirectorySeparatorChar + fnPrbPNG,
            //    Type.Missing, true, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing);

            //// Получить первый рабочий лист.
            //Excel.Worksheet sheet = (Excel.Worksheet)workbook.Sheets[shPrbPNG];

            //// Получить заголовки и значения.
            ////SetTitleAndListValues(sheet, 1, 1, lblTitle1, lstItems1);
            ////SetTitleAndListValues(sheet, 1, 2, lblTitle2, lstItems2);

            //// Закройте книгу без сохранения изменений.
            //workbook.Close(false, Type.Missing, Type.Missing);

            //// Закройте сервер Excel.
            //ExcelApp.Quit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btSpravFTPPath_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2("vlbFTPDP");
            newForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //private List<System.Windows.Forms.Keys> Keyis;
            //StreamWriter SW = new StreamWriter(new FileStream("FileName.txt", FileMode.Create, FileAccess.Write));
            //foreach( Keyi in Keys) //(int i = 0; i < vcbFullName.Items.Count; i++)
            //{
            //    SW.WriteLine(vcbFullName.Items[i].ToString());
            //}
            
            //SW.Close();
            //MessageBox.Show(Keys.Oemtilde.ToString());
            //string s = new string(e.KeyChar, 1);
            //MessageBox.Show(Regex.IsMatch(textBox1.Text, @"[а-яА-ЯёЁa-zA-Z0-9' \-(),.+]$").ToString());
            //MessageBox.Show(Application.OpenForms["Form1"].Controls["vlbFTPDP"].GetType().ToString());
            //(Application.OpenForms["Form1"].Controls["vlbFTPDP"] as Control).Text = "1";
            //List<string> L = new List<string>();
            //L.Add("njjkfgbd");
            //L.Add("hbdfv");
            //L.Add("njjkfgbd");
            //L.Add("njjresgkfgbd");
            //MessageBox.Show((Application.OpenForms["Form1"].Controls["vdtpDate"] as Control).GetType().ToString());
            //vdtpDate.Value=Convert.ToDateTime(textBox1.Text);//.ToString());
            //MessageBox.Show(vdtpDate.Text);
            //vdtpDate.Text = "14.11.1982";
            //MessageBox.Show(vdtpDate.Value.ToString());
            vcbFullName.Tag = vcbFullName.Text;
            MessageBox.Show(PRBPNG.CURREC[1]);

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            ConnectFTP();
            UploadPrbPNG();
            DisconnectFTP();
        }








        private void vcbFIO_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (vcbFIO.Items.IndexOf(vcbFIO.Text) == -1)
                {
                    DataAccessor daFIO = new DataAccessor(bsFIO, @"^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$");
                    daFIO.Add(vcbFIO.Text);
                    vcbFIO.SelectedIndex = vcbFIO.Items.Count - 1;
                    //vcbFIO.Text = bs[bs.Count - 1];
                }

            }
        }







        private void vcbFullName_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void vcbFullName_TextChanged(object sender, EventArgs e)
        {
            vcbFullName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            vcbFullName.AutoCompleteCustomSource = ComboBoxAutoCompleteList(ref vcbFullName);
            vcbFullName.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void vcbMnm_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void vcbMnm_KeyDown(object sender, KeyEventArgs e)
        {
            
           // SendKeys.SendWait(Keys.A.ToString());
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sKey = new string(e.KeyChar, 1);
            if (!Regex.IsMatch(sKey, @"[а-яА-ЯёЁa-zA-Z0-9' \-(),.+]$"))
            {
                e.Handled = true;
            }
            else
            {
                bool keypassno = true;
                string s;
                for (int i = 0; i < vcbFIO.Items.Count; i++)
                {
                    s = textBox1.Text + sKey;
                    string sItem = vcbFIO.Items[i].ToString();
                    //MessageBox.Show(s + sItem);
                    if (sItem.IndexOf(s) == 0)
                    {
                        keypassno = false;
                        break;
                    }
                }
                if (keypassno) e.Handled = true;
            }
        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Skip @ character
            if (e.KeyCode == Keys.D2 && e.Modifiers == Keys.Shift)
            {
                //e.SuppressKeyPress = true;
            }
        }



        private void vchbChckPP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vchbChckPP_CheckedChanged_1(object sender, EventArgs e)
        {

        }



        private void vtbNmbr_KeyUp(object sender, KeyEventArgs e)
        {
            if (vtbNmbr.Text.Length > 0)
            {
                if (vtbNmbr.Text[0].ToString() != "#")
                {
                    vtbNmbr.Text = "#" + vtbNmbr.Text;
                    vtbNmbr.SelectionStart = vtbNmbr.Text.Length; 
                }
            }
        }


    }
    //class PtPrbPNG
    //{
    //    public string FullPath;
    //    public string Name {get;set;};
    //}
    class PriborParams
    {
        //public int Row;
        //public string ppFullName;
        //public string ppMnm;
        //public string ppNmbr;
        //public string ppMtd;
        //public string ppBigMnm;

        //public bool ppChckPP;
        //public bool ppChckRE;
        //public bool ppChckSchema;

        //public string ppFTPDP;
        //public string ppApCmp;
        //public string ppFrml;
        //public string ppIstchnk;
        //public string ppExpdtn;

        //public string ppFIO;
        //public string ppDate;

        //public string ppMtdGroup;
        //public string ppMtdLasName;

        public void ImportParamsFromExSheet(ref Excel.Worksheet wsPRBPNG)
        {

        }
        //public 
    }


    class DataAccessor
    {
        private BindingSource bs;
        private string sPattern;
        public DataAccessor(BindingSource bs, string sPattern)
        {
            this.bs = bs;
            this.sPattern = sPattern;
        }
        public void Add(string s)
        {
            if (IsValid(s))
                bs.Add(s);
        }
        private bool IsValid(string s)
        {
            //Ваша логика ограничений
            return Regex.IsMatch(s, sPattern); //);
        }
    }

    class KeyFilter
    {
        private ComboBox cb;
        private string sPattern;
        public KeyFilter(ComboBox cb, string sPattern)
        {
            this.cb = cb;
            this.sPattern = sPattern;
        }
        public void Add(string s)
        {
            //if (IsValid(s))
            //bs.Add(s);
        }
        private bool IsValid(string s)
        {
            //Ваша логика ограничений
            return Regex.IsMatch(s, sPattern); //);
        }
    }

    class CorrComboText
    {
        private ComboBox cb;
        public CorrComboText(ComboBox cb)
        {
            this.cb = cb;
        }
        //public void Add(string s)
        //{
        //    if (IsValid(s))
        //        bs.Add(s);
        //}
        public static void ValidText(string s)
        {


        }
    }
    //class BindingList
    //{
    //    public List<Binding> BindingList;
    //    public BindingList(SerializableDictionary<string, string> FRMCNTRLS, List<string> HEADROW, ref List<string> CURROW)
    //    {
    //        BindingList = new List<Binding>();
    //        int Col;
    //        string sForm;
    //        string sControl;
    //        foreach (var cntrl in FRMCNTRLS)
    //        {
    //            sForm = cntrl.Value.Split(';')[0];
    //            sControl = cntrl.Value.Split(';')[1];
    //            Col = HEADROW.IndexOf(cntrl.Key);
    //            if (Col > -1)
    //            {

    //                //(Application.OpenForms[sForm].Controls[sControl] as Control).Text = TABLE[Row][Col];
    //            }
    //        }
    //    }        

    //}

                //    KEYCOLL.Add(Sheet.get_Range(sCKey + row).Value2.ToString());
                //List<string> tempList = new List<string>();
                ////Excel.Range cll;
                //Excel.Range rngRec = Sheet.get_Range(sCF + row + ":" + sCL + row) as Excel.Range;
                //foreach (Excel.Range cll in rngRec)
                //{
                //    //tempList.Add(сll.Value2 != null ? cll.Value2.ToString() : "");
                //    if (cll.Value2 != null)
                //    {
                //        tempList.Add(cll.Value.ToString());
                //    }
                //    else
                //    {
                //        tempList.Add("");
                //    }
                //}
                ////for (char column = 'A'; column < 'J'; column++)
                ////{
                ////    Excel.Range cell = Sheet.get_Range(column + row);
                ////    tempList.Add(сell != null ? cell.Value2.ToString() : "");
                ////}
                //TABLE.Add(tempList);
                //row++;

}
