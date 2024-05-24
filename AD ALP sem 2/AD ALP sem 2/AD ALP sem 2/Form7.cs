using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace AD_ALP_sem_2
{
    public partial class Form7 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand mysqlcommand;
        MySqlDataAdapter MySqlDataAdapter;
        MySqlDataReader MySqlDataReader;
        DataTable dtpesan=new DataTable();
        DataTable namafilm = new DataTable();
        DataTable dtpesantiket = new DataTable();
        public Form7()
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
        //public Form6 f6 { get; set; }

        Button[,] tempatkursi = new Button[15,15];
        Label kursipilih ,peringatan;
        Label totalprice = new Label();
        Random rnd = new Random();
        Button confirm;
        public static List<Button>[,] film = new List<Button>[10000, 10000];
        public static int durasitype = Convert.ToInt32(Form6.movieduration);
        public static int moviestudiotype=Form6.moviestudio;
        int studiofilm = Form6.moviestudiotype;
        int counter;
        char[] angkabesar = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'j','K' };
        int spacing = 12;
        int startingX = Form6.posisikursiX;
        int startingY = Form6.posisikursiY;
        int kursi;
        int count = 0;
        int urutan = 0;
        int ulangan = 0;
        public static int totaltiket;
        List<int> kodeKursi = new List<int>();
        List<Button> selectedseat = new List<Button>();
        int sudahpesan/*,pesanancurrentuser*/;
        //int kursipilih1, totalprice1;
        public static string kodekursipilih, kodekursifix, kodekursifix1;
        public static string filmdipilih;
        public static string kodejumlahtiket, jumlahtiket, kodefilm, kodestudio, kodedurasi,filmmulai,filmselesai;
        public static int hargatiket, kodeuser;
        public static List<string> nomerkursipilih = new List<string>();
        public static List<string> nomerkursipilih1 = new List<string>();
        bool bener = false;

        public void updatekursi()
        {
            nomerkursipilih1.Clear();
            dtpesan.Clear();
            string pemesanan = $"select * from kursi where kodestudio='{moviestudiotype}' and filmmulai='{Form6.moviemulai}' and filmselesai='{Form6.movieselesai}'and kodefilm='{Form5.movietype1}';";
            mysqlcommand = new MySqlCommand(pemesanan, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtpesan);
            for (int k = 0; k <dtpesan.Rows.Count; k++)
            {
                ulangan++;
            }
            while(bener==false)
            {
                if (ulangan > 0)
                {
                    string[] kursitaken = dtpesan.Rows[urutan][6].ToString().Split(',');
                    foreach (string a in kursitaken)
                    {
                        nomerkursipilih1.Add(a);
                    }
                    urutan++;
                    ulangan--;
                }
                if (ulangan == 0)
                {
                    bener = true;
                }
            }
            /*dataGridView1.DataSource = dtpesan;*/
        }

        //private void label1_Click(object sender, EventArgs e)
        //{
        //    this.Controls.Clear();
        //    Form6 detailfilm= new Form6();
        //    detailfilm.Visible = true;
        //    detailfilm.FormBorderStyle = FormBorderStyle.None;
        //    detailfilm.Dock = DockStyle.Fill;
        //    detailfilm.TopLevel = false;
        //    this.Controls.Add(detailfilm);
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void homepagefilm()
        {
            string film = $"select * from film where kodefilm='{Form5.movietype1}';";
            mysqlcommand = new MySqlCommand(film, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(namafilm);
            /*dataGridView2.DataSource = namafilm;*/
            for (int k = 0; k < namafilm.Rows.Count; k++)
            {
                filmdipilih = namafilm.Rows[k][1].ToString();
            }
        }
        public void tampilkursi()
        {
            
            film[durasitype, moviestudiotype] = new List<Button>();
            counter = 0;
            for (int i = 0; i < Form6.p; i++)
            {
                for (int j = 0; j < Form6.u; j++)
                {
                    tempatkursi[i, j] = new Button();
                    tempatkursi[i, j].Location = new Point(j * (35 + spacing) + startingX, i * (35 + spacing) + startingY);
                    tempatkursi[i, j].Size = new Size(45, 45);
                    tempatkursi[i, j].ForeColor = Color.Black;
                    tempatkursi[i, j].BackColor = Color.White;
                    tempatkursi[i, j].Font = new Font("Costantia", 9, FontStyle.Bold);
                    tempatkursi[i, j].Text = angkabesar[counter].ToString() + (j + 1);
                    tempatkursi[i, j].Tag = (angkabesar[counter].ToString() + (j + 1)).ToString();
                    tempatkursi[i, j].Click += Form7_Click;
                    film[durasitype, moviestudiotype].Add(tempatkursi[i, j]);
                    foreach (string a in nomerkursipilih1)
                    {
                        if ((angkabesar[counter].ToString() + (j + 1)).ToString() == a)
                        {
                            tempatkursi[i, j].BackColor = Color.Gray;
                            tempatkursi[i, j].Enabled = true;
                        }
                    }
                }
                counter++;
            }
            nomerkursipilih1.Clear();

            foreach (Button button in film[durasitype, moviestudiotype])
            {
                this.Controls.Add(button);
            }
        }

        private void Form7_Click(object sender, EventArgs e)
        {
            var send = sender as Button;
            if (send.BackColor == Color.White)
            {
                send.BackColor = Color.DeepSkyBlue;
                kursi = Convert.ToInt32(send.Tag.ToString().Substring(1));
                nomerkursipilih.Add(send.Tag.ToString());
                nomerkursipilih1.Add(send.Tag.ToString());
                kodeKursi.Add(kursi);
                kursipilih.Text = "";
                kursipilih.Text = "Seats: ";
                kursipilih.Text += kodeKursi.Count.ToString();
                //totalprice.Text = "";
                //totalprice.Text = "IDR:";
                totalprice.Text ="IDR: " + ((kodeKursi.Count) * 35000).ToString();
                inserttiket();
                nomerkursipilih.Clear();
                //MessageBox.Show(kursipilih.Text);
                //selectedseat.Add(send);
                //kursipilih.Text = $"seats: {selectedseat.Count.ToString()}";
                //totalprice.Text = $"totalprice:{(selectedseat.Count*35000).ToString()}";
            }
            else if (send.BackColor == Color.DeepSkyBlue)
            {
                kursi = Convert.ToInt32(send.Tag.ToString().Substring(1));
                kodeKursi.Remove(kursi);
                nomerkursipilih.Remove(send.Tag.ToString());
                nomerkursipilih1.Remove(send.Tag.ToString());
                send.BackColor = Color.White;
                kursipilih.Text = "";
                kursipilih.Text = "Seats: ";
                kursipilih.Text += kodeKursi.Count.ToString();
                //totalprice.Text = "";
                //totalprice.Text = "IDR:";
                totalprice.Text ="IDR: "+((kodeKursi.Count) * 35000).ToString();
                string removetiket = $"delete from tiket where nomerkursi='{send.Tag.ToString()}'";
                mysqlcommand = new MySqlCommand(removetiket, sqlConnection);
                MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
                MySqlDataAdapter.Fill(dtpesantiket);
                nomerkursipilih.Clear();
                //selectedseat.Remove(send);
                //kursipilih.Text = $"seats: {selectedseat.Count.ToString()}";
                //totalprice.Text = $"totalprice:{(selectedseat.Count * 35000).ToString()}";
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            kursipilih = new Label();
            //kursipilih1 = kodeKursi.Count;
            //totalprice1= ((kodeKursi.Count) * 35000);
            //string pemesanan = $"select * from pemesanan where kodestudio='{moviestudiofilm}' and kodedurasi='{durasitype}';";
            //mysqlcommand = new MySqlCommand(pemesanan, sqlConnection);
            //MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            //MySqlDataAdapter.Fill(dtpesan);
            //for (int k = 0; k < dtpesan.Rows.Count; k++)
            //{
            //    sudahpesan += Convert.ToInt32(dtpesan.Rows[k][1].ToString());
            //}
            //dataGridView1.DataSource = dtpesan;
            updatekursi();
            tampilkursi();
            homepagefilm();

            pictureBox1.Image = Form5.films[Form5.movietype-1];
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            
            kursipilih.AutoSize = true;
            kursipilih.Location = new Point(30, 990);
            kursipilih.Font = new Font("Costantia", 14, FontStyle.Bold);
            kursipilih.ForeColor = Color.White;
            kursipilih.Text = "";
            kursipilih.Text = "Seats: ";
            this.Controls.Add(kursipilih);

            
            totalprice.AutoSize = true;
            totalprice.Location = new Point(200, 990);
            totalprice.Font = new Font("Costantia", 14, FontStyle.Bold);
            totalprice.ForeColor = Color.White;
            totalprice.Text = "";
            totalprice.Text = "IDR:";
            this.Controls.Add(totalprice);

            peringatan=new Label();
            peringatan.AutoSize = true;
            peringatan.Location = new Point(30, 1035);
            peringatan.Font = new Font("Costantia", 14, FontStyle.Bold);
            peringatan.ForeColor = Color.White;
            peringatan.Size = new Size(300, 30);
            peringatan.Text = "Tiket yang sudah dibeli tidak dapat ditukar atau dikembalikan";
            this.Controls.Add(peringatan);

            confirm = new Button();
            confirm.Text = "Confirm order";
            confirm.Location = new Point(450,980);
            confirm.Size = new Size(178, 41);
            confirm.Font = new Font("Costantia", 14, FontStyle.Regular);
            confirm.ForeColor = Color.White;
            confirm.BackColor = Color.DeepSkyBlue;
            confirm.Click += Confirm_Click;
            this.Controls.Add(confirm);

            Label screenLabel = new Label();
            screenLabel.ForeColor = Color.White;
            screenLabel.Text = "SCREEN";
            screenLabel.Font = new Font("Constantia", 32);
            screenLabel.AutoSize = true;
            int labelX = (8 * (60 + spacing) - screenLabel.Width) / 2;
            screenLabel.Location = new Point(labelX, 430);
            this.Controls.Add(screenLabel);

            Label horizontalLine = new Label();
            horizontalLine.ForeColor = Color.White;
            horizontalLine.BackColor = Color.Transparent;
            horizontalLine.Font = new Font("Constantia", 14);
            horizontalLine.Text = "------------------------------------------------------------------------";
            horizontalLine.AutoSize = true;
            horizontalLine.Width = 10 * (35 + spacing);
            int lineX = (7 * (72 + spacing) - horizontalLine.Width) / 2;
            horizontalLine.Location = new Point(lineX, 450);
            this.Controls.Add(horizontalLine);

            //    for (int i = 0; i < 10; i++)
            //    {
            //        for (int j = 0; j < 10; j++)
            //        {
            //            Button button = new Button();
            //            button.Location = new Point(j * (35 + spacing) + 250, i * (35 + spacing) + 80);
            //            button.Size = new Size(35, 35);
            //            button.Font = new Font("Constantia", 9);
            //            button.BackColor = Color.White;
            //            button.Text = alfabet[tambah] + nomer.ToString();
            //            button.ForeColor = Color.Black;
            //            this.Controls.Add(button);
            //            nomer++;

            //            if (tambah == 0 && nomer == 11)
            //            {
            //                Button exitButton = new Button();
            //                exitButton.Location = new Point(button.Right + 10, button.Top);
            //                exitButton.Size = new Size(45, 35);
            //                exitButton.Font = new Font("Constantia", 12);
            //                exitButton.BackColor = Color.Green;
            //                exitButton.Enabled = false;
            //                exitButton.Text = "Exit";
            //                exitButton.ForeColor = Color.White;
            //                this.Controls.Add(exitButton);
            //            }
            //        }
            //        nomer = 1;
            //        tambah++;
            //    }
        }
        private void insertkursi()
        {
            kodekursifix = null;
            hargatiket = 35000;
            kodefilm = (Form5.movietype1);
            kodeuser = Form2.urutan;
            filmmulai = Form6.moviemulai;
            filmselesai = Form6.movieselesai;
            kodestudio = moviestudiotype.ToString();
            foreach(string k in nomerkursipilih1)
            {
                if(kodekursifix==null)
                {
                    kodekursifix += k;
                }
                else
                {
                    kodekursifix += "," + k;
                }
            }
            string sudahpemesanan = $"insert into kursi values('{hargatiket}','{kodefilm}','{kodeuser}','{filmmulai}','{filmselesai}','{kodestudio}','{kodekursifix}')";
            try
            {
                sqlConnection.Open();
                mysqlcommand = new MySqlCommand(sudahpemesanan, sqlConnection);
                MySqlDataReader = mysqlcommand.ExecuteReader();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            finally
            {
                sqlConnection.Close();
                updatekursi();
                
            }
        }
        private void updatetiket()
        {
            string tiket = $"select * from tiket where kodestudio='{Form7.moviestudiotype}' and kodefilm='{Form5.movietype1}';";
            mysqlcommand = new MySqlCommand(tiket, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtpesantiket);
        }
        private void inserttiket()
        {
            kodeuser = Form2.urutan;
            kodefilm = (Form5.movietype1);
            filmmulai = Form6.moviemulai;
            filmselesai = Form6.movieselesai;
            kodestudio = moviestudiotype.ToString();
            foreach (string k in nomerkursipilih)
            {
                kodekursifix1 = k;
            }
            string tambahtiket = $"insert into tiket values('{kodeuser}','{kodefilm}','{filmmulai}','{filmselesai}','{kodestudio}','{kodekursifix1}')";
            try
            {
                sqlConnection.Open();
                mysqlcommand = new MySqlCommand(tambahtiket, sqlConnection);
                MySqlDataReader = mysqlcommand.ExecuteReader();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            finally
            {
                sqlConnection.Close();
                updatetiket();
            }
        }
        //private void removetiket()
        //{
        //    string removetiket = $"delete from tiket where nomerkursi='{}'";
        //    mysqlcommand = new MySqlCommand(removetiket, sqlConnection);
        //    MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
        //    MySqlDataAdapter.Fill(dtpesantiket);
        //}
        private void Confirm_Click(object sender, EventArgs e)
        {
            totaltiket = Convert.ToInt32(kodeKursi.Count.ToString());
            if (totaltiket * 35000 > Form2.saldo)
            {
                this.Controls.Clear();
                Form8 pembayaran = new Form8();
                pembayaran.Visible = true;
                pembayaran.FormBorderStyle = FormBorderStyle.None;
                pembayaran.Dock = DockStyle.Fill;
                pembayaran.TopLevel = false;
                this.Controls.Add(pembayaran);
            }
            else
            {
                //if (kodeKursi.Count < 10)
                //{
                //    kodekursipilih = "00" + kodeKursi.Count.ToString();
                //}
                //else if(kodeKursi.Count > 9 && kodeKursi.Count < 100)
                //{
                //    kodekursipilih = "0" + kodeKursi.Count.ToString();
                //}
                //else
                //{
                //    kodekursipilih= kodeKursi.Count.ToString();
                //}
                insertkursi();
                kodeKursi.Clear();
                //selectedseat.Clear();
                //this.Controls.Remove(kursipilih);
                //this.Controls.Remove(totalprice);
                //this.Close();
                //Form8 form8 = new Form8();
                //form8.Show();
                this.Controls.Clear();
                Form8 pembayaran = new Form8();
                pembayaran.Visible = true;
                pembayaran.FormBorderStyle = FormBorderStyle.None;
                pembayaran.Dock = DockStyle.Fill;
                pembayaran.TopLevel = false;
                this.Controls.Add(pembayaran);
            }
        }
    }
}
