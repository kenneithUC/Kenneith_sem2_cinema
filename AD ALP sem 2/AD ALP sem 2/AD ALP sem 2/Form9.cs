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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Form5 homepage = new Form5();
            homepage.Visible = true;
            homepage.FormBorderStyle = FormBorderStyle.None;
            homepage.Dock = DockStyle.Fill;
            homepage.TopLevel = false;
            this.Controls.Add(homepage);
        }

        private void Form9_Load_1(object sender, EventArgs e)
        {

        }
    }
}
