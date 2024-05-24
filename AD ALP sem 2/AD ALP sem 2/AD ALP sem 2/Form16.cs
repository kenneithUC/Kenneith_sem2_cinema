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
    public partial class Form16 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand mysqlcommand;
        MySqlDataAdapter MySqlDataAdapter;
        MySqlDataReader MySqlDataReader;
        DataTable dtstatusfilm = new DataTable();
        public Form16()
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
        string updatestatus;
        private void updatefilm()
        {
            dtstatusfilm.Clear();
            string pilihgambar = $"select* from film order by 1";
            mysqlcommand = new MySqlCommand(pilihgambar, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtstatusfilm);
        }
        public void statusfilm()
        {
            if(radioButton1.Checked==true)
            {
                
                updatestatus = $"UPDATE film set statusfilm='{radioButton1.Text}' WHERE judulfilm='{textBox1.Text.ToString()}';";
            }
            if (radioButton2.Checked == true)
            {
                
                updatestatus = $"UPDATE film set statusfilm='{radioButton2.Text}' WHERE judulfilm='{textBox1.Text.ToString()}';";
            }
            if (radioButton3.Checked == true)
            {
                
                updatestatus = $"UPDATE film set statusfilm='{radioButton3.Text}' WHERE judulfilm='{textBox1.Text.ToString()}';";
            }
            try
            {
                sqlConnection.Open();
                mysqlcommand = new MySqlCommand(updatestatus, sqlConnection);
                MySqlDataReader = mysqlcommand.ExecuteReader();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void Form16_Load(object sender, EventArgs e)
        {
            updatefilm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            statusfilm();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
