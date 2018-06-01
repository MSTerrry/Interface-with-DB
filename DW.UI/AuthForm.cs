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
    public partial class AuthForm : Form
    {
        SqlConnection SqlConnection;

        public AuthForm()
        {
            InitializeComponent();            
        }
                
        private void Okbutton_Click(object sender, EventArgs e)
        {            
            string path = Application.StartupPath.Substring(0, Application.StartupPath.IndexOf("DW.UI")) + @"DeliveryWizard\DwDatabase.mdf";
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";

            SqlConnection = new SqlConnection(connection);

            string querry = "SELECT * FROM LoginPasswords WHERE Login = '" + LoginBox.Text+"' and Password = '"+ Encrypt() +"'";

            SqlDataAdapter sda = new SqlDataAdapter(querry,SqlConnection);
            
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                this.Hide();
                CabForm f = new CabForm(dtbl);                
                f.Show();                
            }
            else
            {
                MessageBox.Show("проверьте логин или пароль");
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

        private void RegistrationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm f = new RegistrationForm();
            f.Show();
        }
    }
}
