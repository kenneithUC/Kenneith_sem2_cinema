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
    public partial class Form13 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand mysqlcommand;
        MySqlDataAdapter MySqlDataAdapter;
        MySqlDataReader MySqlDataReader;
        DataTable dthistorypembayaran = new DataTable();
        public Form13()
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
        public void updatehistory()
        {
            dthistorypembayaran.Clear();
            string pilihgambar = $"select* from transaksi ";
            mysqlcommand = new MySqlCommand(pilihgambar, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dthistorypembayaran);
            dataGridView1.DataSource = dthistorypembayaran;
        }

        private void Form13_Load_1(object sender, EventArgs e)
        {
            updatehistory();
        }
    }
}
