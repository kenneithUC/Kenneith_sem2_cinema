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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form1 form1 = new Form1();
            //form1.Show();
            this.Controls.Clear();
            Form1 login = new Form1();
            login.Visible = true;
            login.FormBorderStyle = FormBorderStyle.None;
            login.Dock = DockStyle.Fill;
            login.TopLevel = false;
            this.Controls.Add(login);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
