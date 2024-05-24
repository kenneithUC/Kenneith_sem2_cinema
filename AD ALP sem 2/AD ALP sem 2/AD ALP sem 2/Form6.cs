using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_ALP_sem_2
{
    public partial class Form6 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand mysqlcommand;
        MySqlDataAdapter MySqlDataAdapter;
        MySqlDataReader MySqlDataReader;
        DataTable dtfilm=new DataTable();
        DataTable dtfilmrow = new DataTable();
        DataTable dtstudio = new DataTable();
        DataTable dtdurasi = new DataTable();
        Button[] button1 = new Button[10];
        public static List<string> jam1 = new List<string>();
        PictureBox pictureBox1;
        string Movienumber =Form5.movietype1;
        public static string movieduration,moviemulai,movieselesai;
        public static int u, posisikursiX, posisikursiY, totaljam,moviestudio, moviestudiotype;

        //private void label1_Click(object sender, EventArgs e)
        //{
        //    this.Controls.Clear();
        //    Form5 hoomepage = new Form5();
        //    hoomepage.Visible = true;
        //    hoomepage.FormBorderStyle = FormBorderStyle.None;
        //    hoomepage.Dock = DockStyle.Fill;
        //    hoomepage.TopLevel = false;
        //    this.Controls.Add(hoomepage);
        //}

        int o;
        public static int p = 10;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public Form6()
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
        //public Form7 f7{get;set;}
        private void Form6_Load(object sender, EventArgs e)
        {
            jam1.Clear();
            string film = "select*from film;";
            mysqlcommand = new MySqlCommand(film, sqlConnection);
            MySqlDataAdapter=new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtfilm);

            string studio = $"select*from studio where kodefilm='{Movienumber}';";
            mysqlcommand = new MySqlCommand(studio, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtstudio);
           /* dataGridView1.DataSource = dtstudio;*/

            string jam = $"select*from jadwal where kodefilm='{Movienumber}';";
            mysqlcommand = new MySqlCommand(jam, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtdurasi);
            //dataGridView2.DataSource = dtdurasi;

            totaljam = dtdurasi.Rows.Count;
            for(int i = 0; i < dtdurasi.Rows.Count; i++)
            {
                jam1.Add(dtdurasi.Rows[i][0].ToString() +"-"+ dtdurasi.Rows[i][1].ToString());
            }

            int labelHeight = 35;
            int spacing = 40;
            int startX = 125;
            int startY = 800;
            int buttonWidth = 120;

            Label judul = new Label();
            judul.Text = "judul";
            judul.Size = new Size(240, 30);
            judul.ForeColor = Color.White;
            judul.Font = new Font("Constantia", 16, FontStyle.Bold);
            judul.AutoSize = false;
            judul.Location = new Point(125, 470);
            this.Controls.Add(judul);

            Label rate = new Label();
            rate.Text = "rate umur";
            rate.ForeColor = Color.White;
            rate.Font = new Font("Constantia", 12, FontStyle.Bold);
            rate.Location = new Point(125, 500);
            this.Controls.Add(rate);

            Label genre = new Label();
            genre.Text = "("+"genre"+")";
            genre.ForeColor = Color.White;
            genre.Font = new Font("Constantia", 14, FontStyle.Regular);
            genre.Location = new Point(455, 470);
            this.Controls.Add(genre);

            Label sinopsis = new Label();
            sinopsis.Text = "sinopsis";
            sinopsis.ForeColor = Color.White;
            sinopsis.Font = new Font("Constantia", 14, FontStyle.Regular);
            sinopsis.Location = new Point(125, 520);
            sinopsis.AutoSize = true;
            sinopsis.TextAlign = ContentAlignment.TopLeft;
            sinopsis.AutoEllipsis = true;
            sinopsis.MaximumSize = new Size(400, 0);
            this.Controls.Add(sinopsis);

            for (int j = 1; j <= totaljam; j++)
            {
                button1[j] = new Button();
                button1[j].Text = jam1[j - 1];
                button1[j].Font = new Font("Constantia", 15, FontStyle.Regular);
                button1[j].BackColor = Color.White;
                button1[j].ForeColor = Color.Black;
                button1[j].Size=new Size(buttonWidth,labelHeight);
                button1[j].Location = new Point(startX, startY);
                button1[j].Tag = dtdurasi.Rows[j - 1][0].ToString() +"-"+ dtdurasi.Rows[j - 1][1].ToString()+","+ dtdurasi.Rows[j - 1][3].ToString();
                button1[j].Click += Form6_Click;
                this.Controls.Add(button1[j]);
                startX += 130;
                if (j % 3 == 0)
                {
                    startX = 125;
                    startY += 50;
                }
                
            }


            pictureBox1 = new PictureBox();
            pictureBox1.Size = new Size(400, 450);
            pictureBox1.Location = new Point(125, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBox1);
            switch (Convert.ToInt32(Movienumber))
            {
                case 1:
                    o = 0;
                    pictureBox1.Image= Form5.films[o];
                    judul.Text = dtfilm.Rows[o][1].ToString();
                    genre.Text = "("+dtfilm.Rows[o][3].ToString()+")";
                    rate.Text = dtfilm.Rows[o][4].ToString();
                    sinopsis.Text = dtfilm.Rows[o][6].ToString();
                    break;
                case 2:
                    o = 1;
                    pictureBox1.Image = Form5.films[o];
                    judul.Text = dtfilm.Rows[o][1].ToString();
                    genre.Text = "(" + dtfilm.Rows[o][3].ToString() + ")";
                    rate.Text = dtfilm.Rows[o][4].ToString();
                    sinopsis.Text = dtfilm.Rows[o][6].ToString();
                    break;
                case 3:
                    o = 2;
                    pictureBox1.Image = Form5.films[o];
                    judul.Text = dtfilm.Rows[o][1].ToString();
                    genre.Text = "(" + dtfilm.Rows[o][3].ToString() + ")";
                    rate.Text = dtfilm.Rows[o][4].ToString();
                    sinopsis.Text = dtfilm.Rows[o][6].ToString();
                    break;
                case 4:
                    o = 3;
                    pictureBox1.Image = Form5.films[o];
                    judul.Text = dtfilm.Rows[o][1].ToString();
                    genre.Text = "(" + dtfilm.Rows[o][3].ToString() + ")";
                    rate.Text = dtfilm.Rows[o][4].ToString();
                    sinopsis.Text = dtfilm.Rows[o][6].ToString();
                    break;
                case 5:
                    o = 4;
                    pictureBox1.Image = Form5.films[o];
                    judul.Text = dtfilm.Rows[o][1].ToString();
                    genre.Text = "(" + dtfilm.Rows[o][3].ToString() + ")";
                    rate.Text = dtfilm.Rows[o][4].ToString();
                    sinopsis.Text = dtfilm.Rows[o][6].ToString();
                    break;
                case 6:
                    o = 5;
                    pictureBox1.Image = Form5.films[o];
                    judul.Text = dtfilm.Rows[o][1].ToString();
                    genre.Text = "(" + dtfilm.Rows[o][3].ToString() + ")";
                    rate.Text = dtfilm.Rows[o][4].ToString();
                    sinopsis.Text = dtfilm.Rows[o][6].ToString();
                    break;
                case 7:
                    o = 6;
                    pictureBox1.Image = Form5.films[o];
                    judul.Text = dtfilm.Rows[o][1].ToString();
                    genre.Text = "(" + dtfilm.Rows[o][3].ToString() + ")";
                    rate.Text = dtfilm.Rows[o][4].ToString();
                    sinopsis.Text = dtfilm.Rows[o][6].ToString();
                    break;
                case 8:
                    o = 7;
                    pictureBox1.Image = Form5.films[o];
                    judul.Text = dtfilm.Rows[o][1].ToString();
                    genre.Text = "(" + dtfilm.Rows[o][3].ToString() + ")";
                    rate.Text = dtfilm.Rows[o][4].ToString();
                    sinopsis.Text = dtfilm.Rows[o][6].ToString();
                    break;

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form6_Click(object sender, EventArgs e)
        {
            var send =sender as Button;
            for (int i = 1; i <=totaljam; i++)
            {
                if (sender == button1[i])
                {
                    movieduration = button1[i].Tag.ToString().Substring(0, 2) + button1[i].Tag.ToString().Substring(3, 2);//0800
                    moviemulai = button1[i].Tag.ToString().Substring(0,5);//08:00
                    movieselesai = button1[i].Tag.ToString().Substring(6,5);//11:10
                    moviestudio = Convert.ToInt32(button1[i].Tag.ToString().Substring(12));//101
                    moviestudiotype = Convert.ToInt32(button1[i].Tag.ToString().Substring(14));//1
                    string filmrow = $"select `row` from studio where kodestudio='{moviestudio}';";
                    mysqlcommand = new MySqlCommand(filmrow, sqlConnection);
                    MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
                    MySqlDataAdapter.Fill(dtfilmrow);
                    //dataGridView1.DataSource=dtfilmrow;
                    u = Convert.ToInt32(dtfilmrow.Rows[0][0].ToString());
                    switch (moviestudiotype)
                    {
                        case 1:
                            posisikursiX = 40;
                            posisikursiY = 500;
                            break;
                        case 2:
                            posisikursiX = 60;
                            posisikursiY = 500;
                            break;
                        case 3:
                            posisikursiX = 80;
                            posisikursiY = 500;
                            break;
                        case 4:
                            posisikursiX = 100;
                            posisikursiY = 500;
                            break;
                        case 5:
                            posisikursiX = 120;
                            posisikursiY = 500;
                            break;
                    }
                    //this.Hide();
                    //Form7 form7 = new Form7();
                    //form7.Show();
                    this.Controls.Clear();
                    Form7 pembayaran = new Form7();
                    pembayaran.Visible = true;
                    pembayaran.FormBorderStyle = FormBorderStyle.None;
                    pembayaran.Dock = DockStyle.Fill;
                    pembayaran.TopLevel = false;
                    this.Controls.Add(pembayaran);
                    //if(f7==null)
                    //{
                    //    Form7 form7 = new Form7();
                    //    form7.Show();
                    //}
                    //else
                    //{
                    //    f7.show
                    //}
                }
            }
        }
    }
}
