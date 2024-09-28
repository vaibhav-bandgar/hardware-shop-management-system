using shop.messagebox;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace shop.Forms
{
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
        }
        private void FormCustomer_Load(object sender, EventArgs e)
        {
            LoadTheme();
            binddata();

        }
        private void LoadTheme()
        {
            button1.BackColor = ThemeColor.PrimaryColor;
            button2.BackColor = ThemeColor.SecondryColor;
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;

            label5.ForeColor = ThemeColor.PrimaryColor;
        }
        SqlConnection conn = new SqlConnection(connectionclass.constring );

        private void button2_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox1.Text)  )
            {
                msg.show("Enter complete information to save ");
                return;
            }



            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[customer]
           ([cust_name]
           ,[cust_gender]
           ,[cust_phone])
     VALUES
           ('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "')", conn);

            try
            {

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                msg.show("information insert successfully");
                binddata();

            }
            catch (Exception )
            {
                msg.show("information is not insert");
            }
        }
        void binddata()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[customer]", conn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (deletemsg.show("are you sure to delete person") == DialogResult.OK)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"delete [dbo].[customer] where cust_id='" + int.Parse(textBox3.Text) + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    msg.show("person information delete successfully");
                    binddata();
                }
            }
            else
            {
                msg.show("Select person information ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                msg.show("Select complete information to save data");
                return;
            }

            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[customer] set cust_name='"+textBox1.Text  +"',cust_gender='"+comboBox1.Text  + "',cust_phone='"+textBox2.Text  +"' where cust_id='" + int.Parse(textBox3.Text) + "'", conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                msg.show("information update successfully");
                binddata();
            }
            catch (Exception)
            {
                msg.show("information are not update");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["cust_id"].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["cust_name"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["cust_gender"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["cust_phone"].Value.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
