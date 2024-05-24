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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void aDDMOVIEToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form14 addmovie = new Form14();
            addmovie.Visible = true;
            addmovie.FormBorderStyle = FormBorderStyle.None;
            addmovie.Dock = DockStyle.Fill;
            addmovie.TopLevel = false;
            panel2.Controls.Add(addmovie);
        }

        private void hISTORYORDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form13 history = new Form13();
            history.Visible = true;
            history.FormBorderStyle = FormBorderStyle.None;
            history.Dock = DockStyle.Fill;
            history.TopLevel = false;
            panel2.Controls.Add(history);
        }

        private void uSERSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form12 users = new Form12();
            users.Visible = true;
            users.FormBorderStyle = FormBorderStyle.None;
            users.Dock = DockStyle.Fill;
            users.TopLevel = false;
            panel2.Controls.Add(users);
        }

        private void sTATUSMOVIEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form16 status = new Form16();
            status.Visible = true;
            status.FormBorderStyle = FormBorderStyle.None;
            status.Dock = DockStyle.Fill;
            status.TopLevel = false;
            panel2.Controls.Add(status);
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Form1 admin = new Form1();
            admin.Visible = true;
            admin.Dock = DockStyle.Fill;
            admin.TopLevel = false;
            this.Controls.Add(admin);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
