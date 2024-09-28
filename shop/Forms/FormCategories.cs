using shop.messagebox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace shop.Forms
{
    public partial class FormCategories : Form
    {
        public FormCategories()
        {
            InitializeComponent();
        }
        
        private void FormCategories_Load(object sender, EventArgs e)
        {
            LoadTheme();
            binddata();
            empty();
        }

        private void LoadTheme()
        {
            button1.BackColor = ThemeColor.PrimaryColor;
            button2.BackColor = ThemeColor.SecondryColor;
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;

            label3.ForeColor = ThemeColor.PrimaryColor;
        }

      

        private void label3_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(connectionclass.constring);

        public void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtcategory .Text) )
            {
                msg.show("write category first");
                return;
            }

            SqlCommand cmd = new SqlCommand(@" INSERT INTO [dbo].[category]
           ([category])
     VALUES
           ('"+txtcategory .Text +"') ", conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                msg.show("category insert successfully");
                binddata();
                empty();
            }
            catch (Exception ex)
            {
                msg.show(ex.Message);
            }

        }
        void binddata()
        {
            SqlCommand cmd = new SqlCommand("select * from category", conn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void empty()
        {
            textBox1.Text = "";
            txtcategory .Text = "";

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1  .Text != "")
            {
                if (deletemsg.show("are you sure to delete category") == DialogResult.OK)
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(@"delete [dbo].[category] where id='" + textBox1.Text + "'", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        msg.show("category delete successfully");
                        binddata();
                        empty();
                    }
                    catch (Exception)
                    {
                        msg.show("category is not insert");
                    }
                }
            }
            else
            {
                msg.show("Select category ");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox1 .Text = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            txtcategory.Text = dataGridView1.Rows[e.RowIndex].Cells["category"].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcategory .Text) )
            {
                msg.show("Select category for edit");
                return;
            }
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[category] set category='" + txtcategory .Text  + "' where id='" + int.Parse(textBox1.Text) + "'", conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                msg.show("category update successfully");
                empty();
                binddata();
                
            }
            catch (Exception ex)
            {
                msg.show(ex.Message );
            }



        }
    }

}
