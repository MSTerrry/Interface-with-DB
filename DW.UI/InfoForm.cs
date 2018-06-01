using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DW.UI
{
    public partial class InfoForm : Form
    {
        static string path = Application.StartupPath.Substring(0, Application.StartupPath.IndexOf("DW.UI")) + @"DeliveryWizard\DwDatabase.mdf";
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
        public InfoForm(string filePath, int orderId)
        {
            SqlConnection sqlcon = new SqlConnection(connection);
            InitializeComponent();
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                MessageBox.Show("Путь к файлу заказа был изменен, укажите новый путь к файлу. Предыдущий путь к файлу:" + filePath);
                OpenFileDialog ofd = new OpenFileDialog();
                var result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileInfo = new FileInfo(ofd.FileName);
                    filePath = ofd.FileName;
                    SqlCommand com = new SqlCommand("UPDATE Orders SET Filepath = N'" + filePath + "'  WHERE Id = '" + orderId + "'", sqlcon);
                    sqlcon.Open();
                    com.ExecuteNonQuery();                    
                }
            }        
            NameChangeLabel.Text = fileInfo.Name;
            PathChangeLabel.Text = filePath;
            ExtensionChangeLabel.Text = fileInfo.Extension;
            CreationChangeLabel.Text = fileInfo.CreationTime.ToString();            
            ReadOnlyChangeLabel.Text = fileInfo.IsReadOnly? "Редактирование доступно": "Редактирование не доступно";
            AccessChangeLabel.Text = fileInfo.LastAccessTime.ToString();
            WriteChangeLabel.Text = fileInfo.LastWriteTime.ToString();
            LengthChangeLabel.Text =  fileInfo.Length.ToString();
        }
    }
}
