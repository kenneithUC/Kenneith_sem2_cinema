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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AD_ALP_sem_2
{
    public partial class Form12 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand mysqlcommand;
        MySqlDataAdapter MySqlDataAdapter;
        MySqlDataReader MySqlDataReader;
        DataTable dtshowuser = new DataTable();
        public Form12()
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
        public void updateuser()
        {
            dtshowuser.Clear();
            string pilihgambar = $"select* from`user` where statususer = 'user' order by namauser ";
            mysqlcommand = new MySqlCommand(pilihgambar, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtshowuser);
            dataGridView1.DataSource = dtshowuser;
        }
        public void statusfilm()
        {
            //if(dataGridView1.SelectedRows.)
            //updatestatus = $"UPDATE homepage set statusfilm='{radioButton1.Text}' WHERE judulfilm='{textBox1.Text.ToString()}';";
            //try
            //{
            //    sqlConnection.Open();
            //    mysqlcommand = new MySqlCommand(updatestatus, sqlConnection);
            //    MySqlDataReader = mysqlcommand.ExecuteReader();
            //}
            //catch (Exception f)
            //{
            //    MessageBox.Show(f.Message);
            //}
            //finally
            //{
            //    sqlConnection.Close();
            //}
        }


        private void Form12_Load(object sender, EventArgs e)
        {
            updateuser();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
