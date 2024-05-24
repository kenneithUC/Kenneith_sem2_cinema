using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;




namespace AD_ALP_sem_2
{
    public partial class Form5 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand mysqlcommand;
        MySqlDataAdapter MySqlDataAdapter;
        MySqlDataReader MySqlDataReader;
        DataTable dtfilm = new DataTable();
        DataTable dtgambarfilm = new DataTable();
        //string workingDirectory;
        //string projectDirectory;
        //string gambar;
        //string fullurl;
        public Form5()
        {
            try
            {
                string connection = "server=localhost;uid=root;pwd=;database=db_cinema";
                sqlConnection = new MySqlConnection(connection);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            InitializeComponent();
        }
        //string path = @"C:\Users\ROG\source\repos\AD ALP sem 2\AD ALP sem 2\alp_cinema\listcinema.txt";
        public static List<string> judul = new List<string>();
        public static List<string> poster = new List<string>();
        public static List<Image> films = new List<Image>();
        private int currentIndex = 0;
        public static int movietype;
        public static string imagepath,movietype1;
        PictureBox [] picturebox;
        PictureBox[] picturebox1;
        Label[] label;
        Label[] label3;
        Label[] expire;
        Button[] button;
        private void Form5_Load(object sender, EventArgs e)
        {
            string pilihgambar = $"select* from film order by 1";
            mysqlcommand = new MySqlCommand(pilihgambar, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtgambarfilm);
            //dataGridView1.DataSource = dtgambarfilm;

            picturebox = new PictureBox[dtgambarfilm.Rows.Count];
            picturebox1 = new PictureBox[dtgambarfilm.Rows.Count];
            label = new Label[dtgambarfilm.Rows.Count];
            label3 = new Label[dtgambarfilm.Rows.Count];
            expire = new Label[dtgambarfilm.Rows.Count];
            button = new Button[dtgambarfilm.Rows.Count];
            timer1.Start();
            timer1.Interval = 1000; // Change this value to adjust the slide interval

            label5.Text = Form2.username + "!";

            if(Form2.saldo<1000000 && Form2.saldo >=100000)
            {
                label4.Font = new Font("Constantia", 15.75f, FontStyle.Bold);
                label4.Text = "saldo: Rp. "+Form2.saldo.ToString().Substring(0,3) + "." + Form2.saldo.ToString().Substring(3,3);
            }
            if (Form2.saldo < 100000&& Form2.saldo>10000)
            {
                label4.Font = new Font("Constantia", 15.75f, FontStyle.Bold);
                label4.Text = "saldo: Rp. " + Form2.saldo.ToString().Substring(0, 2) + "."+Form2.saldo.ToString().Substring(2,3);
            }
            if (Form2.saldo < 10000 && Form2.saldo >0)
            {
                label4.Font = new Font("Constantia", 15.75f, FontStyle.Bold);
                label4.Text = "saldo: Rp. " + Form2.saldo.ToString().Substring(0, 1) + "." + Form2.saldo.ToString().Substring(1,3);
            }
            if (Form2.saldo >= 1000000)
            {
                label4.Font = new Font("Constantia", 15.75f, FontStyle.Bold);
                label4.Text = "saldo: Rp. " + Form2.saldo.ToString().Substring(0, 1) + "."+Form2.saldo.ToString().Substring(1, 3)+"."+ Form2.saldo.ToString().Substring(3, 3);
            }
            if (Form2.saldo ==0)
            {
                label4.Font = new Font("Constantia", 15.75f, FontStyle.Bold);
                label4.Text = "saldo: Rp. " + Form2.saldo.ToString();
            }
            if (Form2.saldo < 0)
            {
                label4.Font = new Font("Constantia", 15.75f, FontStyle.Bold);
                label4.Text = "saldo: Rp. " + Form2.saldo.ToString();
            }
            

                //using (StreamReader p = new StreamReader(path))
                //{
                //    string b;
                //    while ((b = p.ReadLine()) != null)
                //    {
                //        string[] parts = b.Split(',');
                //        if (parts.Length == 2)
                //        {
                //            films.Add(Image.FromFile(parts[1]));
                //        }
                //    }
                //}

                for (int h = 0; h < dtgambarfilm.Rows.Count; h++)
                {
                if (dtgambarfilm.Rows[h][2].ToString() == $"\\alp_cinema\\{h + 1}.jpeg")
                {
                    films.Add(Image.FromFile($@".\alp_cinema\{h + 1}.jpeg"));
                }
                if (dtgambarfilm.Rows[h][2].ToString() == $"\\alp_cinema\\{h + 1}.jpg")
                {
                    films.Add(Image.FromFile($@".\alp_cinema\{h + 1}.jpg"));
                }
            }

            int x = 20;
            int y = 750;
            int count = 0;
            int hello = 1;
            for (int i = 0; i < dtgambarfilm.Rows.Count; i++)
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                imagepath = projectDirectory + dtgambarfilm.Rows[i][2].ToString();
                picturebox[i] = new PictureBox();
                picturebox[i].ImageLocation = imagepath;
                picturebox[i].Size = new Size(270, 270);
                picturebox[i].SizeMode = PictureBoxSizeMode.Zoom;
                picturebox[i].Location = new Point(x, y);
                this.Controls.Add(picturebox[i]);
                poster.Add(imagepath);
                count++;
                x += 300;
                if (count % 2 == 0)
                {
                    x = 30;
                    y += 400;
                }
                picturebox[i].Tag = Convert.ToInt32(dtgambarfilm.Rows[i][0].ToString());

                /*picturebox.Click += PictureBox_Click;*/
                label[i] = new Label();
                label[i].Text = dtgambarfilm.Rows[i][1].ToString();
                label[i].Font = new Font("Courier", 14, FontStyle.Bold);
                label[i].Size = new Size(picturebox[i].Size.Width - 20, 50);
                label[i].Location = new Point(picturebox[i].Left + (picturebox[i].Width - label[i].Width) / 2, picturebox[i].Bottom + 5);
                label[i] .AutoSize = false;
                label[i].TextAlign = ContentAlignment.MiddleCenter;
                label[i].ForeColor = Color.White;
                this.Controls.Add(label[i]);
                if (dtgambarfilm.Rows[i][5].ToString()== "order now")
                {
                    button[i] = new Button();
                    button[i].Text = "ORDER NOW";
                    button[i].Font = new Font("Constantia", 12, FontStyle.Bold);
                    button[i].Size = new Size(picturebox[i].Size.Width - 20, 50);
                    button[i].Location = new Point(picturebox[i].Left + (picturebox[i].Width - label[i].Width) / 2, picturebox[i].Bottom + 60);
                    button[i].AutoSize = false;
                    button[i].TextAlign = ContentAlignment.MiddleCenter;
                    button[i].ForeColor = Color.White;
                    button[i].Tag = Convert.ToInt32(dtgambarfilm.Rows[i][0].ToString());
                    button[i].Click += Button_Click;
                    this.Controls.Add(button[i]);
                }
                else if((dtgambarfilm.Rows[i][5].ToString() == "coming soon"))
                {
                    label3[i] = new Label();
                    label3[i].Text = "COMING SOON";
                    label3[i].Font = new Font("Courier", 14, FontStyle.Bold);
                    label3[i].Size = new Size(picturebox[i].Size.Width - 20, 50);
                    label3[i].Location = new Point(picturebox[i].Left + (picturebox[i].Width - label[i].Width) / 2, picturebox[i].Bottom + 60);
                    label3[i].AutoSize = false;
                    label3[i].TextAlign = ContentAlignment.MiddleCenter;
                    label3[i].ForeColor = Color.Yellow;
                    this.Controls.Add(label3[i]);
                }
                else if((dtgambarfilm.Rows[i][5].ToString() == "expired"))
                {
                    expire[i] = new Label();
                    expire[i].Text = "Expired";
                    expire[i].Font = new Font("Courier", 14, FontStyle.Bold);
                    expire[i].Size = new Size(picturebox[i].Size.Width - 20, 50);
                    expire[i].Location = new Point(picturebox[i].Left + (picturebox[i].Width - label[i].Width) / 2, picturebox[i].Bottom + 60);
                    expire[i].AutoSize = false;
                    expire[i].TextAlign = ContentAlignment.MiddleCenter;
                    expire[i].ForeColor = Color.Red;
                    this.Controls.Add(expire[i]);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var send = sender as Button;
            movietype = Convert.ToInt32(send.Tag.ToString());
            if(movietype<10)
            {
                movietype1 = "00" + movietype.ToString();
            }
            else
            {
                movietype1 = "0" + movietype.ToString();
            }
            //this.Hide();
            //Form6 form6 = new Form6();
            //form6.Show();
            this.Controls.Clear();
            Form6 moviedescription = new Form6();
            moviedescription.Visible = true;
            moviedescription.FormBorderStyle = FormBorderStyle.None;
            moviedescription.Dock = DockStyle.Fill;
            moviedescription.TopLevel = false;
            this.Controls.Add(moviedescription);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (currentIndex >= dtgambarfilm.Rows.Count)
            {
                currentIndex = 0;
            }
            pictureBox1.Image = films[currentIndex];
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            currentIndex++;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form2 form2 = new Form2();
            //form2.Show();
            this.Controls.Clear();
            Form1 signinsignup = new Form1();
            signinsignup.Visible = true;
            signinsignup.FormBorderStyle = FormBorderStyle.None;
            signinsignup.Dock = DockStyle.Fill;
            signinsignup.TopLevel = false;
            this.Controls.Add(signinsignup);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form15 topup = new Form15();
            //topup.Show();
            this.Controls.Clear();
            Form15 topup = new Form15();
            topup.Visible = true;
            topup.FormBorderStyle = FormBorderStyle.None;
            topup.Dock = DockStyle.Fill;
            topup.TopLevel = false;
            this.Controls.Add(topup);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
