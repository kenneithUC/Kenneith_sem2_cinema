using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AD_ALP_sem_2
{
    public partial class Form2 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand mysqlcommand;
        MySqlDataAdapter MySqlDataAdapter;
        DataTable dtuserada=new DataTable();
        public static DataTable currentuser =new DataTable();
        int count = 1;
        public static string username;
        public static double saldo;
        public static int urutan;
        string password;
        public Form2()
        {
            try
            {
                string connection = "server=localhost;uid=root;pwd=;database=db_cinema";
                sqlConnection = new MySqlConnection(connection);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            password = "";
            password = textBox4.Text;
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] result = md5.Hash;

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }

            password = stringBuilder.ToString();

            currentuser.Clear();
            for (int i = 0; i < dtuserada.Rows.Count; i++)
            {
                if ((dtuserada.Rows[i][0].ToString() == textBox1.Text.ToString()) && (dtuserada.Rows[i][1].ToString() == password))
                {
                    string query = $"select*from `user` where namauser='{textBox1.Text.ToString()}' and pinmd5converter='{password}'";
                    mysqlcommand = new MySqlCommand(query, sqlConnection);
                    MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
                    MySqlDataAdapter.Fill(currentuser);
                    /*dataGridView1.DataSource = currentuser;*/
                    urutan = Convert.ToInt32(currentuser.Rows[0][0]);
                    username = currentuser.Rows[0][1].ToString();
                    saldo = Convert.ToInt32(currentuser.Rows[0][6]);
                    count--;
                    //this.Hide();
                    if (dtuserada.Rows[i][2].ToString()=="user")
                    {
                        //this.Hide();
                        //Form5 form5 = new Form5();
                        //form5.Show();
                        this.Controls.Clear();
                        Form5 Homepage = new Form5();
                        Homepage.Visible = true;
                        Homepage.FormBorderStyle = FormBorderStyle.None;
                        Homepage.Dock = DockStyle.Fill;
                        Homepage.TopLevel = false;
                        this.Controls.Add(Homepage);
                    }
                    else
                    {
                        this.Controls.Clear();
                        Form11 admin = new Form11();
                        admin.Visible = true;
                        admin.Dock = DockStyle.Fill;
                        admin.TopLevel = false;
                        this.Controls.Add(admin);
                    }
                }
            }
            if (count == 1)
            {
                MessageBox.Show("salah username atau pin","error", MessageBoxButtons.OK);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string adadata = $"select namauser,pinmd5converter,statususer from `user`";
            mysqlcommand = new MySqlCommand(adadata, sqlConnection);
            MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
            MySqlDataAdapter.Fill(dtuserada);
            //dataGridView1.DataSource = dtuserada;

            textBox1.GotFocus += TextBox1_GotFocus;
            textBox4.GotFocus += TextBox4_GotFocus;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //textBox4.Text = string.Empty;
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }
        private void TextBox4_GotFocus(object sender, EventArgs e)
        {
            textBox4.Text ="";
            //textBox4.UseSystemPasswordChar = true;
            //textBox4.PasswordChar = '*';
            textBox4.KeyPress += NumericTextBox_KeyPress;
        }
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignore the character
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Form4 signup = new Form4();
            signup.Visible = true;
            signup.FormBorderStyle = FormBorderStyle.None;
            signup.Dock = DockStyle.Fill;
            signup.TopLevel = false;
            this.Controls.Add(signup);
        }

        bool cek = true;
        string simpen;

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            simpen = textBox4.Text;
            if (cek == true)
            {
                textBox4.UseSystemPasswordChar = true;
                pictureBox3.Image = AD_ALP_sem_2.Properties.Resources.tutup;
                cek = false;
            }
            else
            {
                textBox4.UseSystemPasswordChar = false;
                pictureBox3.Image = AD_ALP_sem_2.Properties.Resources.buka;
                cek = true;
            }
            textBox4.Text = simpen;
        }
    }
}
