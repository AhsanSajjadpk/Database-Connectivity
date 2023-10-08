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

namespace db_connectivity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;


        private void Form1_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=WS-015NCMSPL-3;Initial Catalog=Testdb;User ID=sa;Password=bimcs");
            cn.Open(); 
            GetAllEmployeeRecord();


        }


        private void GetAllEmployeeRecord()
        {
            cmd = new SqlCommand("GetData",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }


        private void button1_Click(object sender, EventArgs e)
        {
            // cmd = new SqlCommand("InsertData '"+txtname+"','"+txtaddress+"','"+txtdept+"'  ", cn);
             cmd = new SqlCommand("InsertData ", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name",txtname.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@dept", txtdept.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully run");
            txtid.Text =" ";
            txtname.Text = "";
            txtaddress.Text = "";
            txtdept.Text = "";



            //int a = cmd.ExecuteNonQuery();
            //if (a>0)
            //{
            //    MessageBox.Show("Successfully run");
            //}
            //else
            //{
            //    MessageBox.Show("failed ");
            //}
            //cn.Close();


        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtaddress.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtdept.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("UpdateData ", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtid.Text);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@dept", txtdept.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully run");
            txtid.Text = " ";
            txtname.Text = "";
            txtaddress.Text = "";
            txtdept.Text = "";
            GetAllEmployeeRecord();
        }
    }
}
