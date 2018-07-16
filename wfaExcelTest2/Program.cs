using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    //class cXmlData
    //{
    //    Loc
    //}
    class FTPParams
    {
        public static string FtpServer = "212.33.253.235";//sr.ReadLine();212.33.253.235
        public static int    FtpPort = 21;//int.Parse(sr.ReadLine());    21
        public static bool   Passive = true;//                           True
        public static int    FtpTimeout = 30000;//int.Parse(sr.ReadLine()); 30
        public static string Username = "malin";//sr.ReadLine();         malin
        public static string Password = "35MnUk7s";//sr.ReadLine();      35MnUk7s
        public static bool   ExtRicFolder = true; //                     False       
        public static string RicFolder = "";//                            попробовать /PRIBORI 
        /*
        public static string Proxy;
        public static int ProxyPort;
        public static string ProxyType;
        public static string ProxyUser;
        public static string ProxyPassword;
        public static bool ProxyUse;
        public static bool ProxyUserUse;
        */
    }

    class AB
    {
        public int A;
        public int B;
        public AB()
        {
            A = 1;//sr.ReadLine();212.33.253.235
            B = 2;//int.Parse(sr.ReadLine());    21
        }
    }
//A	#
//B	Полное название
//C	Адрес документации
//D	Название
//E	Паспорт
//F	РЭ
//G	Схема
//H	ОбрИсхLAS(В;К;?)
//I	ЗаводскойНомер
//J	FTP
//K	Большое название
//L	Аппаратурный комплекс
//M	Формула прибора
//N	Источники (рад.методы)
//O	Методы
//P	Группы методов
//Q	Имя LAS-файла
//R	Подразделение
//S	Подтверждение названия
//T	Примечания
//U	Корень имени прибора в las
//V	Имена прибора в Las
//W	Именя прибора в Las+#
//X	# в las
//Y	#+
//Z	Для сортировки
//AA	Дата добавления
//AB	ЗаводскойНомер без 0
//AC	Добавил (ФИО)

    class PPCols
    {
        public static string clFullName="B";
        public static string clMnm="D";
        public static string clNmbr="I";
        public static string clMtd="O";
        public static string clBigMnm="K";

        public static string clChckPP = "E";
        public static string clChckRE="F";
        public static string clChckSchema="G";

        public static string clFTPDP="J";
        public static string clApCmp="L";
        public static string clFrml="M";
        public static string clIstchnk="N";
        public static string clDprtmnt="R";

        public static string clFIO="AC";
        public static string clDate="AA";

        //public static string clMtdGroup="P";
        //public static string clMtdLasName="Q";
    }  

    class MyClass
    {
        public static int a;
        public static int b;
        public MyClass()
        {
            a = 1;
            b = 2;
        }

    }
}
