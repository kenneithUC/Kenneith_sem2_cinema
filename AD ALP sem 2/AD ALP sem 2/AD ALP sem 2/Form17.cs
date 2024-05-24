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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form17_Load(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            Form10 loadingpage = new Form10();
            loadingpage.Visible = true;
            loadingpage.FormBorderStyle = FormBorderStyle.None;
            loadingpage.Dock = DockStyle.Fill;
            loadingpage.TopLevel = false;
            panel1.Controls.Add(loadingpage);
            loadingpage.Show();
        }
    }
}
