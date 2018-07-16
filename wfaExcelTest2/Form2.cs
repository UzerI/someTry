using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BytesRoad.Net.Ftp;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        string sDest;
        public Form2(string s)
        {
            InitializeComponent();
            treeView1.ImageList = imageList1;
            sDest = s;
        }
        //_/Добавление из примера
        //Сам клиент ФТП

        FtpClient client = new FtpClient();
        //FTPParams Params = new FTPParams();
        //Подключение к ФТП
        private void ConnectFTP()
        {
            try
            {      
                
                client.PassiveMode = FTPParams.Passive;
                client.Connect(FTPParams.FtpTimeout, FTPParams.FtpServer, FTPParams.FtpPort);
                client.Login(FTPParams.FtpTimeout, FTPParams.Username, FTPParams.Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        //Отключение от FTP
        private void DisconnectFTP()
        {
            client.Disconnect(FTPParams.FtpTimeout);
            treeView1.Nodes.Clear();
            //disconnect.Enabled = false;
            //connect.Enabled = true;
            //contextMenuStrip1.Enabled = false;
        }
        //Получение списка файлов текущего каталога с ФТП
        private void GetItemsFromFtp()
        {
            foreach (FtpItem item in client.GetDirectoryList(FTPParams.FtpTimeout))
            {
                TreeNode node = new TreeNode(item.Name);

                node.ImageIndex = 2;
                node.SelectedImageIndex = 2;
                node.Tag = 0;
                if (item.ItemType == FtpItemType.Directory)
                {
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    node.Tag = 1;
                }
                if (item.ItemType == FtpItemType.File)
                {
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;

                }
                if (item.ItemType == FtpItemType.Link)
                {
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                }
                treeView1.Nodes.Add(node);

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //contextMenuStrip1.Enabled = false;
            //comboBox1.SelectedIndex = 0;
            //Загружаем параметры.
            try
            {
                ConnectFTP();
                client.ChangeDirectory(FTPParams.FtpTimeout, "PRIBORI");
                treeView1.Nodes.Clear();
                GetItemsFromFtp();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            string ftpdp;
            //ftpdp = treeView1.SelectedNode.Text;
            ftpdp = client.GetWorkingDirectory(FTPParams.FtpTimeout) +"/"+ treeView1.SelectedNode.Text;
            (Application.OpenForms["Form1"].Controls[sDest] as Label).Text = ftpdp;
            DisconnectFTP();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            //При двойном щелчке если папка открываем
            try
            {
                if (treeView1.SelectedNode.Tag.ToString() == "1")
                {
                //MessageBox.Show(treeView1.SelectedNode.Text);

                client.ChangeDirectory(FTPParams.FtpTimeout, treeView1.SelectedNode.Text);
                treeView1.Nodes.Clear();
                GetItemsFromFtp();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            if((e.KeyCode==Keys.Enter))
            {
                this.Close();
            }
        }






        //        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        if (treeView1.SelectedNode.Tag.ToString() == "1")
        //        {
        //            (Application.OpenForms["Form1"].Controls["vlbFTPDP"] as Label).Text = "SomeText";
        //            DisconnectFTP();
        //        }
 
        //    }

        //} 
        //Добавление из примера/_

    }
}
