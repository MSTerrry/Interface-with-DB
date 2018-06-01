using DeliveryWizard;
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

namespace DW.UI
{
    public partial class Form1 : Form
    {        
        static string path = Application.StartupPath.Substring(0, Application.StartupPath.IndexOf("DW.UI")) + @"DeliveryWizard\DwDatabase.mdf";
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            TimeToDeliverPicker.Value = TimeToDeliverPicker.Value.AddHours(1);
        }

        public string type;
        int id;
        int orderId;
        DataTable dtbl = new DataTable();

        public Form1(int id, string type)
        {
            InitializeComponent();
            TimeToDeliverPicker.Value = TimeToDeliverPicker.Value.AddHours(1);
            this.id = id;
            this.type = type;
            if (type == "admin")
                StateBox.Enabled = true;            
        }

        public DeliveryRquestDto dto { get; set; }
        public Form1(int id, string type, int orderId)
        {
            InitializeComponent();                                   
            TimeToDeliverPicker.Value = TimeToDeliverPicker.Value.AddHours(1);
            this.id = id;
            this.type = type;
            this.orderId = orderId;
            if (type == "admin")
                StateBox.Enabled = true;
            dtbl = new DataTable();
            SqlConnection sqlcon = new SqlConnection(connection);
            string querry = "SELECT * FROM Orders WHERE Id = '" + orderId + "'";

            SqlDataAdapter sda = new SqlDataAdapter(querry, sqlcon);
                        
            sda.Fill(dtbl);            
            if(dtbl.Rows.Count != 0)
                SetModel(dtbl.Rows[0][5].ToString());            
        }

        DeliveryRquestDto GetModelFromUI()
        {
            return new DeliveryRquestDto()
            {
                Filled = dateTimePicker1.Value,
                FullName = FullNameBox.Text,
                WayPoints = listBox1.Items.OfType<WayPoint>().ToList(),
                TimeDeliver = TimeToDeliverPicker.Value,
                ClientAddress = AddressBox.Text,
                TotalCost = CostUD.Value,
                State = StateBox.SelectedItem.ToString(),
            };
        }
        private void SetModelToUI(DeliveryRquestDto dto)
        {
            dateTimePicker1.Value = dto.Filled;
            FullNameBox.Text = dto.FullName;
            TimeToDeliverPicker.Value = dto.TimeDeliver;
            AddressBox.Text = dto.ClientAddress;
            listBox1.Items.Clear();
            CostUD.Value = dto.TotalCost;
            foreach (var e in dto.WayPoints)
            {
                listBox1.Items.Add(e);
            }
            StateBox.SelectedItem = dto.State;
            if (StateBox.SelectedItem.ToString() == "закрыт" || type != "admin" && StateBox.SelectedItem.ToString() != "принят к обработке")
            {
                Save.Enabled = false;
                Open.Enabled = false;
                Add.Enabled = false;
                StateBox.Enabled = false;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(connection);                      
            
            if (dtbl.Rows.Count == 0 && type != "admin")
            {
                var sfd = new SaveFileDialog() { Filter = "Файлы заказов|*.dw", InitialDirectory = Application.StartupPath };
                var result = sfd.ShowDialog(this);
                SqlCommand com = new SqlCommand("INSERT INTO Orders (Name,PlacesAmount,TotalPrice, State, Filepath, UserId) VALUES (@Name,@PlacesAmount,@TotalPrice,@State,@Filepath,@UserId)", sqlcon);
                com.Parameters.AddWithValue("Name", FullNameBox.Text);
                com.Parameters.AddWithValue("PlacesAmount", listBox1.Items.Count);
                com.Parameters.AddWithValue("TotalPrice", CostUD.Value);
                if (StateBox.SelectedItem == null)
                    StateBox.SelectedItem = "принят к обработке";
                com.Parameters.AddWithValue("State", StateBox.SelectedItem.ToString());                
                com.Parameters.AddWithValue("Filepath", sfd.FileName);
                com.Parameters.AddWithValue("UserId", id);
                sqlcon.Open();
                com.ExecuteNonQuery();
                if (result == DialogResult.OK)
                {
                    var dto = GetModelFromUI();
                    DeliverySerializer.WriteToFile(sfd.FileName, dto);
                    Close();
                }
            }
            else
            {          
                SqlCommand com = new SqlCommand("UPDATE Orders SET State = N'"+ StateBox.SelectedItem.ToString() + "', Filepath = N'"+ DeliverySerializer.newPath+"'  WHERE Id = '"+ orderId + "'", sqlcon);
                sqlcon.Open();
                com.ExecuteNonQuery();
                var dto = GetModelFromUI();
                DeliverySerializer.WriteToFile(DeliverySerializer.newPath, dto);
                Close();
            }                        
        }

        private void Open_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() {};
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = DeliverySerializer.LoadFromFile(ofd.FileName);
                SetModelToUI(dto);
            }
        }

        private void SetModel(string fileName)
        {
            var ofd = new OpenFileDialog() { FileName = fileName};            
            var dto = DeliverySerializer.LoadFromFile(ofd.FileName);
            SetModelToUI(dto);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var form = new WayPointF(new WayPoint());
            var res = form.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                listBox1.Items.Add(form.wp);                
            }
            CostUD.Value += form.wp.TotalCost;            
        }

        private void Delete_Click(object sender, EventArgs e)
        {            
                var wp = (WayPoint)listBox1.SelectedItem;
                CostUD.Value -= wp.TotalCost;
                listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            var wp = listBox1.SelectedItem as WayPoint;
            if (wp == null)
                return;
            CostUD.Value -= wp.TotalCost;
            var form = new WayPointF(wp.Clone(), type, StateBox.SelectedItem.ToString());
            var res = form.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                var si = listBox1.SelectedIndex;
                listBox1.Items.Remove(listBox1.SelectedItem);
                listBox1.Items.Insert(si, form.wp);
            }
            CostUD.Value += form.wp.TotalCost;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (listBox1.SelectedIndex != -1 && !(StateBox.SelectedItem.ToString() == "закрыт" || type != "admin" && StateBox.SelectedItem.ToString() != "принят к обработке"))
                    Delete.Enabled = true;
                else
                    Delete.Enabled = false;
         }

        private void StateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
