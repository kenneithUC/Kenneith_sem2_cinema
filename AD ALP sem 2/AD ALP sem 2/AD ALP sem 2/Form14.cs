using MySql.Data.MySqlClient;
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
    public partial class Form14 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand mysqlcommand;
        MySqlDataAdapter MySqlDataAdapter;
        MySqlDataReader MySqlDataReader;
        DataTable dtaddfilm = new DataTable();
        DataTable dtaddstudio = new DataTable();
        DataTable dtaddjadwal = new DataTable();
        public Form14()
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

        string kodefilm,judulfilm,gambarfilm,genre,rating,statusfilm,synopsis;
        string studio,kodestudio,namastudio,row;
        string filmmulai, filmselesai;
        string column = "10";
        int kodefilm1;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            kodefilm1 = Convert.ToInt32((dtaddfilm.Rows.Count + 1).ToString());
            kodestudio = kodefilm1.ToString() + "01";
            namastudio = "studio1";
            row = "12";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            kodefilm1 = Convert.ToInt32((dtaddfilm.Rows.Count + 1).ToString());
            kodestudio = kodefilm1.ToString() + "02";
            namastudio = "studio2";
            row = "11";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            kodefilm1 = Convert.ToInt32((dtaddfilm.Rows.Count + 1).ToString());
            kodestudio = kodefilm1.ToString() + "03";
            namastudio = "studio3";
            row = "10";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            kodefilm1 = Convert.ToInt32((dtaddfilm.Rows.Count + 1).ToString());
            kodestudio = kodefilm1.ToString() + "04";
            namastudio = "studio4";
            row = "9";
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            kodefilm1 = Convert.ToInt32((dtaddfilm.Rows.Count + 1).ToString());
            kodestudio = kodefilm1.ToString() + "05";
            namastudio = "studio5";
            row = "8";
        }

        private void updatefilm()
        {
            dtaddfilm.Clear();
            string pilihgambar = $"select* from film order by 1";
            mysqlcommand = new MySqlCommand(pilihgambar, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtaddfilm);
            dataGridView1.DataSource = dtaddfilm;
        }
        private void insertfilm()
        {
            kodefilm1 = Convert.ToInt32((dtaddfilm.Rows.Count + 1).ToString());
            if (kodefilm1< 10)
            {
                kodefilm = "00" + kodefilm1.ToString();
            }
            else
            {
                kodefilm = "0" + kodefilm1.ToString();
            }
            judulfilm = textBox1.Text;
            if (textBox5.Text == $"{(dtaddfilm.Rows.Count + 1)}.jpg")
            {
                gambarfilm += $"\\\\alp_cinema\\\\{(dtaddfilm.Rows.Count + 1)}.jpg"; ;
            }
            else if (textBox5.Text == $"{(dtaddfilm.Rows.Count + 1)}.jpeg")
            {
                gambarfilm += $"\\\\alp_cinema\\\\{(dtaddfilm.Rows.Count + 1)}.jpeg";
            }
            genre = textBox2.Text;
            rating = textBox4.Text;
            statusfilm = "coming soon";
            synopsis = textBox3.Text;
            string tambahfilm = $"insert into film values('{kodefilm1}','{judulfilm}','{gambarfilm}','{genre}','{rating}','{statusfilm}','{synopsis}')";
            try
            {
                sqlConnection.Open();
                mysqlcommand = new MySqlCommand(tambahfilm, sqlConnection);
                MySqlDataReader = mysqlcommand.ExecuteReader();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            finally
            {
                sqlConnection.Close();
                updatefilm();
            }
        }
        private void updatestudio()
        {
            dtaddstudio.Clear();
            string studio = $"select* from studio";
            mysqlcommand = new MySqlCommand(studio, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtaddstudio);
            dataGridView1.DataSource = dtaddstudio;
        }
        private void insertstudio()
        {
            kodefilm1 = Convert.ToInt32((dtaddfilm.Rows.Count + 1).ToString());
            if (kodefilm1 < 10)
            {
                kodefilm = "00" + kodefilm1.ToString();
            }
            else
            {
                kodefilm = "0" + kodefilm1.ToString();
            }
            string masukinstudio = $"insert into studio values('{kodefilm}','{kodestudio}','{namastudio}','{row}','{column}')";
            try
            {
                sqlConnection.Open();
                mysqlcommand = new MySqlCommand(masukinstudio, sqlConnection);
                MySqlDataReader = mysqlcommand.ExecuteReader();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            finally
            {
                sqlConnection.Close();
                updatestudio();
            }

        }
        private void updatejadwal()
        {
            dtaddjadwal.Clear();
            string jadwal = $"select* from jadwal";
            mysqlcommand = new MySqlCommand(jadwal, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtaddjadwal);
            dataGridView1.DataSource = dtaddjadwal;
        }
        private void insertjadwal()
        {
            filmmulai = textBox6.Text;
            filmselesai = textBox7.Text;
            kodefilm1 = Convert.ToInt32((dtaddfilm.Rows.Count + 1).ToString());
            if (kodefilm1 < 10)
            {
                kodefilm = "00" + kodefilm1.ToString();
            }
            else
            {
                kodefilm = "0" + kodefilm1.ToString();
            }
            string masukinstudio = $"insert into jadwal values('{filmmulai}','{filmselesai}','{kodefilm}','{kodestudio}')";
            try
            {
                sqlConnection.Open();
                mysqlcommand = new MySqlCommand(masukinstudio, sqlConnection);
                MySqlDataReader = mysqlcommand.ExecuteReader();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            finally
            {
                sqlConnection.Close();
                updatejadwal();
            }

        }
        private void Form14_Load(object sender, EventArgs e)
        {
            updatejadwal();
            updatestudio();
            updatefilm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Form14 addmovie = new Form14();
            addmovie.Visible = true;
            addmovie.FormBorderStyle = FormBorderStyle.None;
            addmovie.Dock = DockStyle.Fill;
            addmovie.TopLevel = false;
            this.Controls.Add(addmovie);
            insertjadwal();
            insertstudio();
            insertfilm();
        }
    }
}
