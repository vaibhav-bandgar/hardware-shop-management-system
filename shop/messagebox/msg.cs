using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop.messagebox
{
    public partial class msg : Form
    {
        public msg()
        {
            InitializeComponent();
            Loadtheme();
        }
        public static DialogResult   show (string text)
        {
            msg messagebox=new msg ();
            messagebox .label1 .Text = text;
            messagebox .ShowDialog ();
            return messagebox.DialogResult;
        }
        private void yes_Click(object sender, EventArgs e)
        {
            this .Hide ();
        }
        private void Loadtheme()
        {
            label1.ForeColor = ThemeColor.SecondryColor;
            yes.BackColor = ThemeColor.SecondryColor;
        }

        private void msg_Load(object sender, EventArgs e)
        {

        }





      

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }
    }
}
