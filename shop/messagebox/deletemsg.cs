using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop.messagebox
{
    public partial class deletemsg : Form
    {
        public DialogResult userchoice {  get; private  set; }

       
        public deletemsg ()
        {
            InitializeComponent();
           
        }
        
        public static DialogResult show (string text)
        {
            deletemsg messagebox=new deletemsg ();
            messagebox .messagelabel .Text = text;
            messagebox .ShowDialog ();

            return messagebox.DialogResult;
        }
        private   void  button1_Click(object sender, EventArgs e)
        {
          
            DialogResult =DialogResult.OK;
        }

        private void no_Click(object sender, EventArgs e)
        {
          
            DialogResult = DialogResult.Cancel;
        }

        private void deletemsg_Load(object sender, EventArgs e)
        {

        }

    }
}
