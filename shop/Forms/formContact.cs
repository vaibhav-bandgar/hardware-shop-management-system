using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop.Forms
{
    public partial class formContact : Form
    {
        public formContact()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadTheme()
        {
           


            label6 .ForeColor  = ThemeColor.PrimaryColor;
            //button3.BackColor = ThemeColor.SecondryColor;
            //button1.ForeColor = Color.White;
            //button3.ForeColor = Color.White;

        }
        private void formContact_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
