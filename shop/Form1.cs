using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop
{
    public partial class MainForm : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
       
        public MainForm()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false  ;


            btnProducts.MouseEnter += btnProducts_MouseEnter;
            btnProducts.MouseLeave += btnProducts_MouseLeave;
            btnOrders.MouseEnter += btnOrders_MouseEnter;
            btnOrders.MouseLeave += btnOrders_MouseLeave;
         

        }

       
        private Color SelectThemeColor()
        {
            int index= random .Next (ThemeColor .ColorList .Count);
            while (tempIndex ==index )
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color= ThemeColor.ColorList[index];
            return ColorTranslator .FromHtml(color);

        }

        private void ActiveButton(object btnSender)
        {
            if(btnSender != null )
            {

                if(currentButton!=(Button )btnSender)
                {
                    DisableButton();

                    Color color = SelectThemeColor();
                    currentButton =(Button)btnSender;
                    currentButton .BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton .Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitle.BackColor = color;
                    panelLogo .BackColor =   ThemeColor .ChangeColorBrightness (color, -0.3);

                    ThemeColor.PrimaryColor = color;
                    ThemeColor .SecondryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true ;

                }
            }
        }


        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu .Controls)
            {
                if(previousBtn .GetType () == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn .ForeColor = Color.Gainsboro ;
                    previousBtn .Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }




        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm  != null)
            {
                activeForm.Close();
            }
            ActiveButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm .FormBorderStyle = FormBorderStyle.None;
            childForm .Dock = DockStyle.Fill;
            this.panelDesktopPanel .Controls .Add(childForm );
            this.panelDesktopPanel .Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormItems(),sender );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormCategories(), sender);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormCustomer(), sender);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormBilling(), sender);
        }
















      
        private void button5_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Forms.formContact (), sender);
            OpenChildForm(new Forms.formSearch(), sender);
        }



        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton ();
            lblTitle.Text = "HOME";
            panelTitle.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm .Visible = false;
        }

        private void btnProducts_MouseEnter(object sender, EventArgs e)
        {
            btnProducts.Image = Properties.Resources.itemgif;
        }

        private void btnProducts_MouseLeave(object sender, EventArgs e)
        {
            btnProducts.Image = Properties.Resources.itempng;
        }

        private void btnOrders_MouseEnter(object sender, EventArgs e)
        {
            btnOrders.Image = Properties.Resources.categorygif; 
        }

        private void btnOrders_MouseLeave(object sender, EventArgs e)
        {
            btnOrders.Image = Properties.Resources.categorypng;
        }

        private void btnNotifications_MouseEnter(object sender, EventArgs e)
        {
        }

        private void btnNotifications_MouseLeave(object sender, EventArgs e)
        {
        }

        private void FormMainManu_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void panelDesktopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //OpenChildForm(new Forms.formSearch(), sender);
            OpenChildForm(new Forms.formContact(), sender);
        }
    }
}
