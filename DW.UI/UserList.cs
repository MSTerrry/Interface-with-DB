using Microsoft.Office.Interop.Excel;
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
    public partial class UserList : Form
    {
        static string path = System.Windows.Forms.Application.StartupPath.Substring(0, System.Windows.Forms.Application.StartupPath.IndexOf("DW.UI")) + @"DeliveryWizard\DwDatabase.mdf";
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        string sql = "SELECT * FROM LoginPasswords";
        public UserList()
        {
            InitializeComponent();
            GridUserList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridUserList.AllowUserToAddRows = false;
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                sqlcon.Open();
                adapter = new SqlDataAdapter(sql, connection);

                ds = new DataSet();
                adapter.Fill(ds);
                GridUserList.DataSource = ds.Tables[0];                
                GridUserList.Columns["Id"].ReadOnly = true;
            }                        
        }

        private void Add_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row); 
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GridUserList.SelectedRows)
            {
                if (row.Cells[0].Value.ToString() != "")
                {
                    using (SqlConnection sqlcon = new SqlConnection(connection))
                    {
                        sqlcon.Open();
                        string querry = "DELETE FROM Orders WHERE Id = '" + (int)row.Cells[0].Value + "'";
                        SqlCommand cmd = new SqlCommand(querry, sqlcon);
                        cmd.ExecuteNonQuery();
                    }
                }
                GridUserList.Rows.Remove(row);
            }
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {            
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                sqlcon.Open();
                adapter = new SqlDataAdapter(sql, sqlcon);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = new SqlCommand("sp_InsertUser", sqlcon);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Login", SqlDbType.NVarChar, 50, "Login"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 50, "Password"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 50, "Type"));

                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                adapter.Update(ds);
            }
        }

        private string Encrypt(string str)
        {
            MD5 Haser = MD5.Create();
            byte[] data = Haser.ComputeHash(Encoding.Default.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }

        string temp = "";

        private void GridUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                temp = GridUserList[e.ColumnIndex, e.RowIndex].Value.ToString();                
            }
        }

        private void GridUserList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var value = GridUserList[e.ColumnIndex, e.RowIndex].Value.ToString();            
            if (e.ColumnIndex == 2 && value != temp)
            {                
                GridUserList[e.ColumnIndex,e.RowIndex].Value = Encrypt(value);
            }
        }

        private void ExportBut_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook ExcelWorkBook;
            Worksheet ExcelWorkSheet;            
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);            
            ExcelWorkSheet = (Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < GridUserList.ColumnCount; i++)
            {
                ExcelApp.Cells[1, i+1] = GridUserList.Columns[i].HeaderText;
            }
            for (int i = 0; i < GridUserList.Rows.Count; i++)
            {
                for (int j = 0; j < GridUserList.ColumnCount; j++)
                {                                        
                   ExcelApp.Cells[i + 2, j + 1] = GridUserList.Rows[i].Cells[j].Value;                    
                }
            }            
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
    }
}
