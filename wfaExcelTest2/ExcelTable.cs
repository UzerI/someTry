using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel; //ObservableCollection
using System.Collections.Specialized; //ObservableCollection
using Excel = Microsoft.Office.Interop.Excel; //Excel
using System.Windows.Forms;//

namespace WindowsFormsApplication1
{
    class ExcelTable
    {
        private int OldCount;
        private string sCF;
        private string sCL;
        private int RF;
        private int RL;
        private string sCKey;
        public string SheetName;
        private string BookFullName;
        public List<List<string>> TABLE;
        public ObservableCollection<string> KEYCOLL;
        public List<string> CURREC;
        //private
        public ExcelTable(string sCF, string sCL, int RF, string SheetName, string sCKey)
        {
            this.sCF = sCF;
            this.sCL = sCL;
            this.RF = RF;
            //this.RL = RL; вычисляется после загрузки
            this.sCKey = sCKey;
            this.SheetName = SheetName;
            TABLE = new List<List<string>>();
            KEYCOLL = new ObservableCollection<string>();
            CURREC = new List<string>();
        }
        public void LoadFromFile(string BookFullName)
        {
            this.BookFullName = BookFullName;
            Excel.Application App;
            //переменная для Workbooks
            Excel.Workbooks WBs;
            Excel.Workbook WB;
            //переменная для Sheets
            Excel.Sheets Sheets;
            Excel.Worksheet Sheet;

            App = new Microsoft.Office.Interop.Excel.Application();
            //добавляем в файл Excel книгу. Параметр в данной функции - используемый для создания книги шаблон.
            //если нас устраивает вид по умолчанию, то можно спокойно передавать пустой параметр.
            WBs = App.Workbooks;            
            WB = WBs.Open(BookFullName);//xlsWBs.Add(missingValue);
            Sheets = WB.Worksheets;
            
            Sheet = (Excel.Worksheet)Sheets.get_Item(1);           
            int row = RF;
            //RL = Sheet.Cells[RF,sCKey].            
            while (Sheet.get_Range(sCKey + row).Value2 != null)
            {
                KEYCOLL.Add(Sheet.get_Range(sCKey + row).Value2.ToString());
                List<string> tempList = new List<string>();
                //Excel.Range cll;
                Excel.Range rngRec = Sheet.get_Range(sCF + row + ":" + sCL + row) as Excel.Range;
                foreach (Excel.Range cll in rngRec)
                {
                    //tempList.Add(сll.Value2 != null ? cll.Value2.ToString() : "");
                    if (cll.Value2 != null)
                    {
                        tempList.Add(cll.Value.ToString());
                    }
                    else
                    {
                        tempList.Add("");
                    }
                }
                //for (char column = 'A'; column < 'J'; column++)
                //{
                //    Excel.Range cell = Sheet.get_Range(column + row);
                //    tempList.Add(сell != null ? cell.Value2.ToString() : "");
                //}
                TABLE.Add(tempList);
                row++;
            }
            RL = row;
            OldCount = RL - RF;
            CURREC.AddRange(TABLE[TABLE.Count-1].ToArray());
            /*
            Вот таким нехитрым способом, мы отмапили из экселевского файла 
            ячеки в двухмерный список, с которым дальше можно и работать, 
            не прибегая, к всяким жутким ухищрениям.
            Да, чуть не забыл, проверка в while, проверяет есть ли хоть что-то 
            в первом столбце в текущей строке, если есть, 
            то добро пожаловать в мапинг. если нет, то файл кончился 
            (ну у меня просто файл такой, у вас может быть другое условие разбора. 
            Например, нужно перетащить наперед заданное число строк, или как нибудь еще).*/
            //6. Закрываем Excel
            App.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Sheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Sheets);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(WB);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(WBs);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(App); 
        }
        public void SaveToFile(string BookFullName)
        {
        }
        public void ExportRecToForm(List<string> valsCNTRLS, List<string> keysHEADS, int Row)
        {
            int Col;
            string sForm;
            string sControl;
            foreach (string cntrl in valsCNTRLS)
            {
                sForm = cntrl.Split(';')[0];
                sControl = cntrl.Split(';')[1];
                Col = TABLE[0].IndexOf(keysHEADS[valsCNTRLS.IndexOf(cntrl)]);
                if (Col > -1)
                {
                    (Application.OpenForms[sForm].Controls[sControl] as Control).Text = CURREC[Col];
                    (Application.OpenForms[sForm].Controls[sControl] as Control).Tag = CURREC[Col];
                    //(Application.OpenForms[sForm].Controls[sControl] as Control)
                }
            }
        }
    }
}
