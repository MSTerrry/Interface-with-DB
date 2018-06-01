using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliveryWizard;

namespace DW.UI
{
    public partial class CabForm : Form
    {
        static string path = Application.StartupPath.Substring(0, Application.StartupPath.IndexOf("DW.UI")) + @"DeliveryWizard\DwDatabase.mdf";
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";

        public CabForm()
        {
            InitializeComponent();
        }
        private bool checkClosing = true;
        
        private int id;
        private string type;
        
        private List<int> listbox1Id = new List<int>();
        private List<int> listbox2Id = new List<int>();

        DataTable dtbl = new DataTable();

        public CabForm(DataTable e)
        {  
            InitializeComponent();
            id = (int)e.Rows[0][0];
            type = e.Rows[0][3].ToString();
            StatusBar.Text = ("You logged in as:" + type);
            CheckOrders();
        }

        private void CheckOrders()
        {
            dtbl = new DataTable();
            SqlConnection sqlcon = new SqlConnection(connection);

            if (type != "admin")
            {
                string querry = "SELECT * FROM Orders WHERE UserId = '" + id + "'";

                SqlDataAdapter sda = new SqlDataAdapter(querry, sqlcon);
                
                sda.Fill(dtbl);
                FillingListboxes(dtbl);
            }
            else
            {
                string querry = "SELECT * FROM Orders";

                SqlDataAdapter sda = new SqlDataAdapter(querry, sqlcon);
                                
                sda.Fill(dtbl);
                FillingListboxes(dtbl);
            }
        }

        private void FillingListboxes(DataTable dtbl)
        {
            listbox1Id = new List<int>();
            listbox2Id = new List<int>();
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {                
                string str = dtbl.Rows[i][1].ToString();
                for (int j = 2; j < 5; j++)
                {
                    str +=" " + dtbl.Rows[i][j];
                }
                if (dtbl.Rows[i][4].ToString() != "закрыт")
                {
                    listbox1Id.Add(Convert.ToInt32(dtbl.Rows[i][0].ToString()));
                    listBox1.Items.Add(str);
                }
                else
                {
                    listbox2Id.Add(Convert.ToInt32(dtbl.Rows[i][0].ToString()));
                    listBox2.Items.Add(str);
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthForm f = new AuthForm();
            f.Show();
            if (f.DialogResult == DialogResult.OK)
            {
                this.Close();
                checkClosing = false;
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа DeliveryWizard 1.0 предназначена для работы с продуктовыми заказами");
        }

        private void списокПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (type == "admin")
            {
                UserList f = new UserList();
                f.ShowDialog();
            }
            else MessageBox.Show("Данное меню доступно только администратору");
        }

        private void NewOrder_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(id,type);
            f.ShowDialog();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            dtbl = new DataTable();
            CheckOrders();
        }
        private void Refresh()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            dtbl = new DataTable();
            CheckOrders();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {            
            if (listBox1.SelectedIndex != -1)
            {
                var form = new Form1(id, type, listbox1Id[listBox1.SelectedIndex]);
                form.ShowDialog();
            }
        }


        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                var form = new Form1(id, type, listbox2Id[listBox2.SelectedIndex]);
                form.ShowDialog();
            }
        }

        private void CabForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(checkClosing)
                Application.Exit();
        }


        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void информацияОФайлеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OrderControl.SelectedIndex == 0)
            {
                if (listBox1.SelectedIndex != -1)
                {  
                    InfoForm f = new InfoForm(PathReturnFromListBox1(), listbox1Id[listBox1.SelectedIndex]);
                    f.Show();
                }
            }
            else
            {
                if (listBox2.SelectedIndex != -1)
                {   
                    InfoForm f = new InfoForm(PathReturnFromListBox2(), listbox2Id[listBox2.SelectedIndex]);
                    f.Show();
                }
            }
        }
        private string PathReturnFromListBox1()
        {
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                if (dtbl.Rows[i][0].ToString() == listbox1Id[listBox1.SelectedIndex].ToString())
                {
                    return dtbl.Rows[i][5].ToString();                    
                }
            }
            return null;
        }
        private string PathReturnFromListBox2()
        {
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                if (dtbl.Rows[i][0].ToString() == listbox2Id[listBox2.SelectedIndex].ToString())
                {
                    return dtbl.Rows[i][5].ToString();                    
                }
            }
            return null;
        }


        private void DeleteOrderButton_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(connection);

            if (OrderControl.SelectedIndex == 0)
            {
                string querry = "DELETE FROM Orders WHERE Id = '"+listbox1Id[listBox1.SelectedIndex] + "'";
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(querry, sqlcon);               
                cmd.ExecuteNonQuery();
                sqlcon.Close();               
            }
            Refresh();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var temp = "";            
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                if (dtbl.Rows[i][0].ToString() == listbox1Id[listBox1.SelectedIndex].ToString())
                    temp = dtbl.Rows[i][4].ToString();
            }            
            if (listBox1.SelectedIndex != -1 && temp == "принят к обработке")
            {
                DeleteOrderButton.Visible = true;                      
            }
        }

        private void экспортЗаказаВWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OrderControl.SelectedIndex == 0)
            {
                if (listBox1.SelectedIndex != -1)
                {                   
                    var dto = DeliverySerializer.LoadFromFile(PathReturnFromListBox1());
                    CheckExistFile(DeliverySerializer.newPath, listbox1Id[listBox1.SelectedIndex]);
                    WordExportOrders.WordExport(dto);
                }
            }
            else
                if (listBox2.SelectedIndex != -1)
                {                
                var dto = DeliverySerializer.LoadFromFile(PathReturnFromListBox2());
                CheckExistFile(DeliverySerializer.newPath, listbox1Id[listBox1.SelectedIndex]);
                WordExportOrders.WordExport(dto);
                }
        }

        private void CheckExistFile(string path,int orderId)
        {
            bool check = false;
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                if (dtbl.Rows[i][4].ToString() == path)
                    check = true;
            }
            if(!check)
            {
                SqlConnection sqlcon = new SqlConnection(connection);
                SqlCommand com = new SqlCommand("UPDATE Orders SET Filepath = N'" + path + "'  WHERE Id = '" + orderId + "'", sqlcon);
                sqlcon.Open();
                com.ExecuteNonQuery();                
            }
        }
    }
}
