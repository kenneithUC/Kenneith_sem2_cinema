using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_ALP_sem_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Form2 signinpage = new Form2();
            signinpage.Visible = true;
            signinpage.FormBorderStyle = FormBorderStyle.None;
            signinpage.Dock = DockStyle.Fill;
            signinpage.TopLevel =false;
            this.Controls.Add(signinpage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Form4 signuppage = new Form4();
            signuppage.Visible = true;
            signuppage.FormBorderStyle = FormBorderStyle.None;
            signuppage.Dock = DockStyle.Fill;
            signuppage.TopLevel = false;
            this.Controls.Add(signuppage);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
