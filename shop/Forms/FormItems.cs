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

namespace shop.Forms
{
    public partial class FormItems : Form
    {
        SqlConnection conn = new SqlConnection(connectionclass.constring);
        int id = 1;
        int count = 1;

        
        public FormItems()
        {
            InitializeComponent();
          
                       
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
           
        }

        private void LoadTheme()
        {
          

            button1 .BackColor = ThemeColor.PrimaryColor;
            button3 .BackColor =ThemeColor .SecondryColor;
            button1.ForeColor = Color.White;
            button3.ForeColor = Color.White;
         
            label7.ForeColor = ThemeColor.PrimaryColor;
        }

        private void FormProduct_Load_1(object sender, EventArgs e)
        {
            LoadTheme();
            binddata();
            empty();
            display();
           
        }

        void display()
        {
            SqlCommand cmd = new SqlCommand(@" select id ,category from category ", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            da.Fill(table1);

            DataRow itemrow = table1.NewRow ();
            itemrow[1] = "electronic";
            table1 .Rows .InsertAt (itemrow ,0);


            comboBox1 .DataSource = table1;
            comboBox1.DisplayMember = "category";
            comboBox1.ValueMember = "id";
        }

            private void button3_Click(object sender, EventArgs e)
        {
            
            if(string .IsNullOrWhiteSpace (comboBox1 .Text)  || string.IsNullOrWhiteSpace(textBox2.Text)  || string.IsNullOrWhiteSpace(textBox1.Text)  || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) )
            {
                msg.show("Enter complete value to insert item");
                return;
            }

           

            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[item]
           ([itemname]
           ,[category]
           ,[price]
           ,[stock]
           ,[Manufacture])
     VALUES
           ('" + textBox3.Text + "','" + comboBox1.Text + "','" + int.Parse(textBox2.Text) + "','" + int.Parse(textBox1.Text) + "','" + textBox4.Text + "')", conn);

                conn.Open();
                cmd .ExecuteNonQuery();
                conn.Close ();
                
                msg.show("Item insert successfully");
                binddata();
                empty();
                
                
              
            }
            catch (Exception )
            {
                msg.show("data is not inserted");
               
                msg.show(Convert.ToString(count));
            }
        }
        void empty()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            
        }
        void binddata()
        {
            SqlCommand cmd = new SqlCommand("select * from item", conn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                msg.show("Select item to update information");
                return;
            }

            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[item] set itemname='"+textBox3.Text +"', category ='"+comboBox1 .Text +"',price ='"+int.Parse (textBox2.Text )+"', stock ='"+int.Parse (textBox1.Text )+ "',Manufacture ='"+textBox4 .Text +"' where id='"+int.Parse (textBox5.Text )+"'", conn);

            try
            {
                conn.Open();
                cmd .ExecuteNonQuery();
                conn.Close ();
                
                msg.show("Information update successfully");
                
                binddata();
                empty();
            }
            catch (Exception ex)
            {
                msg.show(ex.Message );
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            

            if (textBox5.Text != "")
            {
                if (deletemsg .show ("are you sure to delete item") == DialogResult.OK  )
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"delete [dbo].[item ] where id='" + int.Parse(textBox5.Text) + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    msg.show("Item delete successfully");
                    binddata();
                   
                }
            }
            else
            {


                msg.show("Select item information ");
            }
            





        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.CurrentRow.Selected = true;
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
            comboBox1 .Text = dataGridView1.Rows[e.RowIndex].Cells["category"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Manufacture"].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["stock"].Value.ToString();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
         
            
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
