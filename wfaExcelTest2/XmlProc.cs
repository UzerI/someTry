using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization; //это для сохранения классов — что и есть серилизация (стрёмное слово)

using System.Collections.ObjectModel; //ObservableCollection
using System.Collections.Specialized; //ObservableCollection

namespace WindowsFormsApplication1
{
    //Класс работы с настройками
    public class cxmlProc
    {
        public cxmlData xmlData;

        public cxmlProc()
        {
            xmlData = new cxmlData();
        }
        //Запись настроек в файл
        public void WriteXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(cxmlData));

            TextWriter writer = new StreamWriter(xmlData.FileName);
            ser.Serialize(writer, xmlData);
            writer.Close();
        }
        //Чтение насроек из файла
        public void ReadXml()
        {
            if (File.Exists(xmlData.FileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(cxmlData));
                TextReader reader = new StreamReader(xmlData.FileName);
                xmlData = ser.Deserialize(reader) as cxmlData;
                reader.Close();
            }
            else
            {
                //можно написать вывод сообщения если файла не существует
            }
        }

    }
    public class cxmlData // имя выбрано просто для читаемости кода впоследствии
    {

        public string FileName = Environment.CurrentDirectory + "\\data.xml";

        public string xfSpravPath; // это собственно для хранения X верхнего левого угла окна
        public string xfPrbFTPfpPrbPNG;//INNOVATION/WRITING/ILPST/SPRAV/
        //List<string> xlDeps;
        public ObservableCollection<string> xlFios;
        public List<string> xlDprtmnt;
        public List<string> xlNoneExist;
        //public SerializableDictionary<string, string> xdPRBRecToCntrls;
        public List<string> xlPRBRecKeys;
        public List<string> xlPRBCntrlsValues;
        public cxmlData()
        {

            xlFios = new ObservableCollection<string>();
            xlDprtmnt = new List<string>();
            xlNoneExist = new List<string>();
            //xdPRBRecToCntrls = new SerializableDictionary<string, string>();
            xlPRBRecKeys = new List<string>();
            xlPRBCntrlsValues = new List<string>();
        }

        //public int Y_pos; // ну а это, соответственно Y
    }
    //public struct fcstring
    //{
    //    public static string sForm;
    //    public static string sControl;
    //    //public fcstring(string sForm, string sControl)
    //    //{
    //    //    this.sForm = sForm;
    //    //    this.sControl = sControl;
    //    //}
    //}


}
