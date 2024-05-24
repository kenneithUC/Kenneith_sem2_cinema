using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_ALP_sem_2
{
    public partial class Form8 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand mysqlcommand;
        MySqlDataAdapter MySqlDataAdapter;
        MySqlDataReader MySqlDataReader;
        DataTable dtupdatepembayaran=new DataTable();
        DataTable dtupdatetransaksi = new DataTable();
        public Form8()
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
        public static string kodefilm, kodestudio, Kodejumlahtiket;
        public static int kodeurutan,totalharga,jumlahtiket,jumlahkursi;
        public static double bookingfee;
        
        private void Form8_Load_1(object sender, EventArgs e)
        {
            jumlahkursi = Form7.totaltiket;
            updatetransaksi();
            Panel panel = new Panel();
            panel.Size = new Size(425,135);
            panel.Location = new Point(106,245);
            panel.BackColor = Color.White;
            panel.AutoScroll = true;
            this.Controls.Add(panel);

            Label namafilm = new Label();
            namafilm.Text = Form7.filmdipilih.ToString();
            namafilm.Location = new Point(17, 16);
            namafilm.Size = new Size(250, 19);
            namafilm.Font = new Font("Constantia", 12, FontStyle.Bold);
            namafilm.ForeColor = Color.Black;
            panel.Controls.Add(namafilm);

            Label jumlahtiket = new Label();
            jumlahtiket.Text = jumlahkursi + " Tickets";
            jumlahtiket.Location = new Point(17, 57);
            jumlahtiket.Size = new Size(150, 19);
            jumlahtiket.Font = new Font("Constantia", 12, FontStyle.Bold);
            jumlahtiket.ForeColor = Color.Black;
            panel.Controls.Add(jumlahtiket);

            Label kursipilih = new Label();
            kursipilih.Text += Form7.kodekursifix;
            kursipilih.Location = new Point(18,90);
            kursipilih.Size = new Size(200,20);
            kursipilih.AutoSize = false;
            kursipilih.Font = new Font("Constantia", 9, FontStyle.Bold);
            kursipilih.ForeColor = Color.Black;
            panel.Controls.Add(kursipilih);

            Label totalharga = new Label();
            if ((Convert.ToInt32(jumlahkursi.ToString()) * 35000) < 1000000 && (Convert.ToInt32(jumlahkursi.ToString()) * 35000) >= 100000)
            {
                totalharga.Text = "RP." + (Convert.ToInt32(jumlahkursi.ToString()) * 35000).ToString().Substring(0,3) +"."+ (Convert.ToInt32(jumlahkursi.ToString()) * 35000).ToString().Substring(3, 3);
            }
            else
            {
                totalharga.Text = "RP." + ((Convert.ToInt32(jumlahkursi.ToString()) * 35000).ToString().Substring(0, 2)) + "." + ((Convert.ToInt32(jumlahkursi.ToString()) * 35000).ToString().Substring(2, 3));
            }
            totalharga.Location = new Point(300, 98);
            totalharga.Size = new Size(150, 17);
            totalharga.Font = new Font("Constantia", 10, FontStyle.Bold);
            totalharga.ForeColor = Color.Black;
            panel.Controls.Add(totalharga);

            Label waktupesanan = new Label();
            waktupesanan.Text = DateTime.Now.ToString("g");
            waktupesanan.Location = new Point(280, 0);
            waktupesanan.Size = new Size(150, 19);
            waktupesanan.Font = new Font("Constantia", 12, FontStyle.Bold);
            waktupesanan.ForeColor = Color.Black;
            panel.Controls.Add(waktupesanan);

            Label subtotal = new Label();
            if ((Convert.ToInt32(jumlahkursi.ToString()) * 35000) < 1000000 && (Convert.ToInt32(jumlahkursi.ToString()) * 35000) >= 100000)
            {
                subtotal.Text = "RP." + (Convert.ToInt32(jumlahkursi.ToString()) * 35000).ToString().Substring(0, 3) + "." + (Convert.ToInt32(jumlahkursi.ToString()) * 35000).ToString().Substring(3, 3);
            }
            else
            {
                subtotal.Text = "RP." + ((Convert.ToInt32(jumlahkursi.ToString()) * 35000).ToString().Substring(0, 2)) + "." + ((Convert.ToInt32(jumlahkursi.ToString()) * 35000).ToString().Substring(2, 3));
            }
            subtotal.Location = new Point(483, 470);
            subtotal.Size = new Size(93,19);
            subtotal.Font = new Font("Constantia", 12, FontStyle.Bold);
            subtotal.ForeColor = Color.White;
            this.Controls.Add(subtotal);

            Label bookingfee = new Label();
            if(((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1)<10000)
            {
                bookingfee.Text = "Rp." + ((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1).ToString().Substring(0, 1) + "." + ((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1).ToString().Substring(1, 3);
            }
            if (((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1) >= 10000)
            {
                bookingfee.Text = "Rp." + ((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1).ToString().Substring(0, 2) + "." + ((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1).ToString().Substring(2, 3);
            }
            bookingfee.Location = new Point(483, 508);
            bookingfee.Size = new Size(100, 19);
            bookingfee.Font = new Font("Constantia", 12, FontStyle.Bold);
            bookingfee.ForeColor = Color.White;
            this.Controls.Add(bookingfee);

            Label total = new Label();
            if((((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1) + (Convert.ToInt32(jumlahkursi.ToString()) * 35000))<100000)
            {
                total.Text = "Rp." + ((((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1) + (Convert.ToInt32(jumlahkursi.ToString()) * 35000)).ToString().Substring(0,2))+"."+ ((((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1) + (Convert.ToInt32(jumlahkursi.ToString()) * 35000)).ToString().Substring(2,3));
            }
            if ((((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1) + (Convert.ToInt32(jumlahkursi.ToString()) * 35000)) < 1000000 && (((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1) + (Convert.ToInt32(jumlahkursi.ToString()) * 35000)) >= 100000)
            {
                total.Text = "Rp." + ((((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1) + (Convert.ToInt32(jumlahkursi.ToString()) * 35000)).ToString().Substring(0, 3)) + "." + ((((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1) + (Convert.ToInt32(jumlahkursi.ToString()) * 35000)).ToString().Substring(3, 3));
            }
            total.Location = new Point(475,579);
            total.Size = new Size(150, 19);
            total.Font = new Font("Constantia", 12, FontStyle.Bold);
            total.ForeColor = Color.White;
            this.Controls.Add(total);
        }
        private void updatetransaksi()
        {
            string transaksi = $"select * from transaksi;";
            mysqlcommand = new MySqlCommand(transaksi, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtupdatepembayaran);
        }

        private void inserttransaksi()
        {
            kodeurutan=Form2.urutan;
            kodefilm = Form5.movietype1;
            kodestudio = Form6.moviestudio.ToString();
            if(jumlahtiket>10)
            {
                Kodejumlahtiket = Form5.movietype +"0"+jumlahkursi.ToString();
            }
            else if(jumlahtiket<10)
            {
                Kodejumlahtiket = Form5.movietype +"00"+jumlahkursi.ToString();
            }
            jumlahtiket = jumlahkursi;
            totalharga = (Convert.ToInt32(jumlahkursi.ToString()) * 35000);
            bookingfee = Convert.ToDouble((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1);

            string transaksi = $"insert into transaksi values('{kodeurutan}','{kodefilm}','{kodestudio}','{Kodejumlahtiket}','{jumlahtiket}','{totalharga}','{bookingfee}')";
            try
            {
                sqlConnection.Open();
                mysqlcommand = new MySqlCommand(transaksi, sqlConnection);
                MySqlDataReader = mysqlcommand.ExecuteReader();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            finally
            {
                sqlConnection.Close();
                updatetransaksi();
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (Form2.saldo < ((Convert.ToInt32(jumlahkursi.ToString()) * 35000) + ((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1)))
            {
                MessageBox.Show("Eror", "Saldo tidak Cukup", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                foreach (Button button in Form7.film[Form7.durasitype, Form7.moviestudiotype])
                {
                    if (button.BackColor == Color.DeepSkyBlue)
                    {
                        button.BackColor = Color.White;
                    }
                }
                this.Controls.Clear();
                Form5 homepage = new Form5();
                homepage.Visible = true;
                homepage.FormBorderStyle = FormBorderStyle.None;
                homepage.Dock = DockStyle.Fill;
                homepage.TopLevel = false;
                this.Controls.Add(homepage);
            }
            else
            {
                inserttransaksi();
                Form2.saldo -= Convert.ToDouble(((Convert.ToInt32(jumlahkursi.ToString()) * 35000) + ((Convert.ToInt32(jumlahkursi.ToString()) * 35000) * 0.1)));
                if(Form2.saldo<0)
                {
                    Form2.saldo = 0;
                }
                foreach (Button button in Form7.film[Form7.durasitype, Form7.moviestudiotype])
                {
                    if (button.BackColor == Color.DeepSkyBlue)
                    {
                        button.BackColor = Color.Gray;
                        button.Enabled = false;
                    }
                }
                string updatesaldo = $"UPDATE `user` set saldo='{Form2.saldo}' WHERE kodeuser='{Form2.urutan}';";
                try
                {
                    sqlConnection.Open();
                    mysqlcommand = new MySqlCommand(updatesaldo, sqlConnection);
                    MySqlDataReader = mysqlcommand.ExecuteReader();
                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    this.Controls.Clear();
                    Form9 pembayaranberhasil = new Form9();
                    pembayaranberhasil.Visible = true;
                    pembayaranberhasil.FormBorderStyle = FormBorderStyle.None;
                    pembayaranberhasil.Dock = DockStyle.Fill;
                    pembayaranberhasil.TopLevel = false;
                    this.Controls.Add(pembayaranberhasil);
                }
            }
            //this.Hide();
            //Form5 form5 = new Form5();
            //form5.Show();
            //this.Controls.Clear();
            //Form9 pembayaranberhasil = new Form9();
            //pembayaranberhasil.Visible = true;
            //pembayaranberhasil.FormBorderStyle = FormBorderStyle.None;
            //pembayaranberhasil.Dock = DockStyle.Fill;
            //pembayaranberhasil.TopLevel = false;
            //this.Controls.Add(pembayaranberhasil);
        }
    }
}
