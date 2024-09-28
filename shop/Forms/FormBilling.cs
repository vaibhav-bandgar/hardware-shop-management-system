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
    public partial class FormBilling : Form
    {
        SqlConnection conn = new SqlConnection(connectionclass.constring);
        SqlCommand cmd;
        SqlDataReader dr;       
        public FormBilling()
        {
            InitializeComponent();
        }
        private void FormBilling_Load(object sender, EventArgs e)
        {
            LoadTheme();
            display();
            binddata();
            empty();           
        }
        private void LoadTheme()
        {
            button1.BackColor = ThemeColor.PrimaryColor;
            button3.BackColor = ThemeColor.SecondryColor;
            button1.ForeColor = Color.White;
            button3.ForeColor = Color.White;         
            label6.ForeColor = ThemeColor.PrimaryColor;
        }
        void binddata()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[billing]", conn);           
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void empty()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
        }
        void display()
        {
            string sql = "select * from item";
            cmd=new SqlCommand (sql,conn);
            conn.Open();
            dr = cmd.ExecuteReader ();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["itemname"]);
            }
            conn.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from item where itemname=@itemnamedemo", conn);
            cmd.Parameters.AddWithValue("@itemnamedemo", comboBox1.Text);
            conn.Open();
            dr = cmd.ExecuteReader ();
            while (dr.Read())
            {
                string itemcategory = dr["category"].ToString();
                string itemprice = dr["price"].ToString ();
                textBox3.Text = itemcategory;
                textBox1 .Text = itemprice;
                textBox2.Text = "";
                textBox4.Text = "";
            }
            conn.Close();                           
        }
        int demototal = 0;       
        void demoaddvalue()
        {
            int raughvalue = 0;
            int value1 = 0;
            Int32.TryParse(textBox1.Text, out value1);
            int value2 = 0;
            Int32.TryParse(textBox2.Text, out value2);
            raughvalue = value1 * value2;
            demototal = demototal + raughvalue;           
            textBox5.Text = demototal.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                msg.show("Enter complete value to add bill");
                return;
            }
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[billing]
           ([itemname]
           ,[category]
           ,[price]
           ,[unit])
     VALUES
           ('" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "'  )", conn);
                conn.Open();
                cmd.ExecuteNonQuery();              
                conn.Close();
                demoaddvalue();
                msg.show("Item add successfully in bill");
                binddata();         
                empty();
            }           
            catch (Exception ex)
            {
                msg.show(ex.Message);
                
            }
        }
        private void Button2_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;       
            comboBox1 .Text = dataGridView1.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
            textBox3 .Text = dataGridView1.Rows[e.RowIndex].Cells["category"].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["unit"].Value.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {            
            if (deletemsg.show("are you sure to delete item") == DialogResult.OK)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(@"truncate  table [dbo].[billing];", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    msg.show("bill reset successfully");
                    binddata();
                    demototal = 0;
                    textBox5.Text = "0";
                    empty();
                }
                catch (Exception ex)
                {
                    msg.show(ex.Message);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                if (deletemsg.show("are you sure to delete bill") == DialogResult.OK)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"delete [dbo].[billing ] where id='" + int.Parse(textBox4.Text) + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    int value1 = 0;
                    Int32.TryParse(textBox1.Text, out value1);
                    int value2 = 0;
                    Int32.TryParse(textBox2.Text, out value2);
                    int valuedelete = value1 * value2;
                    demototal = demototal - valuedelete;
                    textBox5.Text = demototal.ToString();
                    msg.show("bill delete successfully");
                    binddata();
                }
            }
            else
            {
                msg.show("Select bill ");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            try
            {
                SqlCommand cmd = new SqlCommand(@"truncate  table [dbo].[billing];", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();              
                binddata();
                demototal = 0;
                textBox5.Text = "0";
                empty();
            }
            catch (Exception ex)
            {
                msg.show(ex.Message);
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap objbmp = new Bitmap(this.dataGridView1.Width,this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(objbmp , new Rectangle (0,0,this.dataGridView1 .Width ,this.dataGridView1 .Height ));
            e.Graphics.DrawImage(objbmp, 250, 120);
            e.Graphics .DrawString ("Print",new Font("arial",22,FontStyle .Bold ),Brushes.Black ,new Point (350,60));
            e.Graphics.DrawString("total =", new Font("arial", 22, FontStyle.Bold), Brushes.Black, new Point(250, 480));
            e.Graphics.DrawString(textBox5 .Text , new Font("arial", 22, FontStyle.Bold), Brushes.Black, new Point(340, 480));
            e.Graphics.DrawString("Thank you for visit...", new Font("arial", 22, FontStyle.Bold), Brushes.Black, new Point(280, 550));
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
