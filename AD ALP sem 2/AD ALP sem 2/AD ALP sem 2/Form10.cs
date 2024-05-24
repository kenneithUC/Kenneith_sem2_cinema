using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AD_ALP_sem_2
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
        }

        private void Form10_Load_1(object sender, EventArgs e)
        {
            int p = 20;

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, args)=>
            {
                progressBar1.Value += p;

                if (progressBar1.Value >= 100)
                {
                    timer.Stop();
                    this.Controls.Clear();
                    Form1 loginpage = new Form1();
                    loginpage.Visible = true;
                    loginpage.FormBorderStyle = FormBorderStyle.None;
                    loginpage.Dock = DockStyle.Fill;
                    loginpage.TopLevel = false;
                    this.Controls.Add(loginpage);
                }
            };
            timer.Start();
        }
    }
}
