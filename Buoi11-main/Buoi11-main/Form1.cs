using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public SqlConnection connect;
        string a = "Data Source = A209PC41;Initial Catalog = siem;Integrated Security = true";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                connect = new SqlConnection(a);
                connect.Open();
                string InsertString = "insert into SinhVien values('"+ textBox1.Text +"','"+ textBox2.Text +"');";
                SqlCommand cmd = new SqlCommand(InsertString, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Text = genaralID();
        }

        public string genaralID()
        {
            string nam = DateTime.Now.Year.ToString();
            string thang = DateTime.Now.Month.ToString();
            string ngay = DateTime.Now.Day.ToString();
            string gio = DateTime.Now.Hour.ToString();
            string phut = DateTime.Now.Minute.ToString();
            string giay = DateTime.Now.Second.ToString();
            return nam + thang + ngay + gio + phut + giay;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                connect = new SqlConnection(a);
                connect.Open();
                string DeleteString = "delete SinhVien where MSSV = '"+ textBox1.Text +"'";
                SqlCommand cmd = new SqlCommand(DeleteString, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                connect = new SqlConnection(a);
                connect.Open();
                string UpdateString = "update SinhVien set MSSV = '"+ textBox1.Text +"' where MSSV = '"+ textBox3.Text +"'";
                SqlCommand cmd = new SqlCommand(UpdateString, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection(a);
            connect.Open();
            string ShowString = "select * from SinhVien";
            SqlDataAdapter adapter = new SqlDataAdapter(ShowString, connect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection(a);
            connect.Open();
            string ShowString = "select * from SinhVien";
            SqlDataAdapter adapter = new SqlDataAdapter(ShowString, connect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            
            textBox1.Text = genaralID();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n;
            n = e.RowIndex;
            try
            {
                textBox1.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
            }
            catch(Exception ex)
            {
                textBox1.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
            }
        }

    }
}
