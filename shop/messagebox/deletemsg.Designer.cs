namespace shop.messagebox
{
    partial class deletemsg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.yesbutton = new System.Windows.Forms.Button();
            this.messagelabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // yesbutton
            // 
            this.yesbutton.BackColor = System.Drawing.Color.Crimson;
            this.yesbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.yesbutton.FlatAppearance.BorderSize = 0;
            this.yesbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yesbutton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesbutton.ForeColor = System.Drawing.Color.White;
            this.yesbutton.Location = new System.Drawing.Point(103, 109);
            this.yesbutton.Name = "yesbutton";
            this.yesbutton.Size = new System.Drawing.Size(113, 39);
            this.yesbutton.TabIndex = 1;
            this.yesbutton.Text = "&ok";
            this.yesbutton.UseVisualStyleBackColor = false;
            this.yesbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // messagelabel
            // 
            this.messagelabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagelabel.Location = new System.Drawing.Point(20, 55);
            this.messagelabel.Name = "messagelabel";
            this.messagelabel.Size = new System.Drawing.Size(412, 33);
            this.messagelabel.TabIndex = 2;
            this.messagelabel.Text = "are you sure to delete value";
            this.messagelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 34);
            this.panel1.TabIndex = 0;
            // 
            // cancelbutton
            // 
            this.cancelbutton.BackColor = System.Drawing.Color.Green;
            this.cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelbutton.FlatAppearance.BorderSize = 0;
            this.cancelbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbutton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbutton.ForeColor = System.Drawing.Color.White;
            this.cancelbutton.Location = new System.Drawing.Point(240, 109);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(113, 39);
            this.cancelbutton.TabIndex = 3;
            this.cancelbutton.Text = "&Cancel";
            this.cancelbutton.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel2.Location = new System.Drawing.Point(-15, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 164);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel3.Location = new System.Drawing.Point(454, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 173);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel4.Location = new System.Drawing.Point(-10, 168);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(494, 12);
            this.panel4.TabIndex = 6;
            // 
            // deletemsg
            // 
            this.AcceptButton = this.yesbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.yesbutton;
            this.ClientSize = new System.Drawing.Size(455, 169);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.messagelabel);
            this.Controls.Add(this.yesbutton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "deletemsg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "deletemsg";
            this.Load += new System.EventHandler(this.deletemsg_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button yesbutton;
        private System.Windows.Forms.Label messagelabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}