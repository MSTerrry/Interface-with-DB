using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DW.UI
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrButton_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath.Substring(0, Application.StartupPath.IndexOf("DW.UI")) + @"DeliveryWizard\DwDatabase.mdf";
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";

            SqlConnection SqlCon = new SqlConnection(connection);

            if (PasswordBox.Text == PassdoublBox.Text)
            {                
                SqlCommand com = new SqlCommand("INSERT INTO LoginPasswords (Login,Password,Type) VALUES (@Login,@Password,@User)", SqlCon);
                com.Parameters.AddWithValue("Login", LoginBox.Text);
                com.Parameters.AddWithValue("Password", Encrypt());
                com.Parameters.AddWithValue("User", "user");
                SqlCon.Open();
                com.ExecuteNonQuery();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
            }
        }

        private string Encrypt()
        {
            MD5 Haser = MD5.Create();
            byte[] data = Haser.ComputeHash(Encoding.Default.GetBytes(PasswordBox.Text));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
