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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AD_ALP_sem_2
{
    public partial class Form15 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand mysqlcommand;
        MySqlDataAdapter MySqlDataAdapter;
        MySqlDataReader MySqlDataReader;
        DataTable dtisisaldo=new DataTable();
        public Form15()
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
        public static double isisaldo;

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.GotFocus += TextBox1_GotFocus;

            isisaldo = Convert.ToDouble(textBox1.Text);

            Form2.saldo += Convert.ToDouble(isisaldo.ToString());
            string updatetopup = $"UPDATE `user` set saldo='{Form2.saldo}' WHERE kodeuser='{Form2.urutan}';";
            try
            {
                sqlConnection.Open();
                mysqlcommand = new MySqlCommand(updatetopup, sqlConnection);
                MySqlDataReader = mysqlcommand.ExecuteReader();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            finally
            {
                sqlConnection.Close();
                updatesaldo();
            }
            //this.Hide();
            //Form5 form5=new Form5();
            //form5.Show();
            this.Controls.Clear();
            Form19 topup = new Form19();
            topup.Visible = true;
            topup.FormBorderStyle = FormBorderStyle.None;
            topup.Dock = DockStyle.Fill;
            topup.TopLevel = false;
            this.Controls.Add(topup);
        }
        public void updatesaldo()
        {
            string updateisisaldo = $"select * from `user`;";
            mysqlcommand = new MySqlCommand(updateisisaldo,sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtisisaldo);
        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }
        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.KeyPress += NumericTextBox_KeyPress;
        }
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignore the character
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.KeyPress += NumericTextBox_KeyPress;
            textBox1.GotFocus += TextBox1_GotFocus;
        }
    }
}
