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

namespace shop.Forms
{
    public partial class formSearch : Form
    {
        public formSearch()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(connectionclass.constring);
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string keyword = textBox1 .Text;


            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [dbo].[item] WHERE itemname LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1 .DataSource = dt;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1 .Text == "Enter Item Name Here...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Item Name Here...";
                textBox1.ForeColor = Color.Silver;
            }
        }
        void binddata()
        {
            SqlCommand cmd = new SqlCommand("select * from item", conn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void formSearch_Load(object sender, EventArgs e)
        {
            binddata();
            //991, 428
        }
    }
}
