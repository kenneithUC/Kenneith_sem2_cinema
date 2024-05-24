using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace AD_ALP_sem_2
{
    public partial class Form4 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand mysqlcommand;
        MySqlDataAdapter MySqlDataAdapter;
        MySqlDataReader MySqlDataReader;
        public static DataTable dtuser = new DataTable();
        string pass,confirmpass;
        DateTime today;
        string username, tanggallahir;
        public Form4()
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
            //dataGridView1.DataSource = dtuser;
        }
        private void updatedatauser()
        {
            dtuser.Clear();
            try
            {
                string table = "select*from `user`;";
                mysqlcommand = new MySqlCommand(table, sqlConnection);
                MySqlDataAdapter = new MySqlDataAdapter(mysqlcommand);
                MySqlDataAdapter.Fill(dtuser);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.GotFocus += TextBox1_GotFocus;
            textBox2.GotFocus += TextBox2_GotFocus;
            textBox3.GotFocus += TextBox3_GotFocus;
            textBox4.GotFocus += TextBox4_GotFocus;
            updatedatauser();
        }

        public void pinconverter()
        {
            pass = "";
            pass = textBox3.Text;
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pass));
            byte[] result = md5.Hash;

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }

            pass = stringBuilder.ToString();

            confirmpass = "";
            confirmpass = textBox4.Text;
            MD5 md51 = new MD5CryptoServiceProvider();
            md51.ComputeHash(ASCIIEncoding.ASCII.GetBytes(confirmpass));
            byte[] result1 = md51.Hash;

            StringBuilder stringBuilder2 = new StringBuilder();
            for (int p = 0; p < result1.Length; p++)
            {
                stringBuilder2.Append(result1[p].ToString("x2"));
            }

            confirmpass = stringBuilder2.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "UserName" || textBox2.Text == "Year-MM-DD" || textBox4.Text == "PIN" || textBox3.Text == "Confirm PIN")
            {
                MessageBox.Show("Make sure to fill all the blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int user = dtuser.Rows.Count + 1;
                string nama = textBox1.Text;
                string tanggallahir = textBox2.Text;
                string[] year = tanggallahir.Split('-');
                int currentYear = DateTime.Today.Year;

                if (year[0].Length != 4)
                {
                    MessageBox.Show("Make sure the format is the same", "Error", MessageBoxButtons.OK);
                    textBox2.Text ="Year-MM-DD";

                }
                else
                {
                    int umur = currentYear - Convert.ToInt32(year[0]);
                    int pin = Convert.ToInt32(textBox3.Text);
                    today = DateTime.Today;
                    pinconverter();
                    if (pass != confirmpass)
                    {
                        MessageBox.Show("Make sure pin is the same", "Error", MessageBoxButtons.OK);
                    }
                    else
                    {
                        string insertuser = $"insert into `user` values('{user}','{nama}','{pin}','{pass}','{tanggallahir}','{umur}',0,'user')";
                        try
                        {
                            sqlConnection.Open();
                            mysqlcommand = new MySqlCommand(insertuser, sqlConnection);
                            MySqlDataReader = mysqlcommand.ExecuteReader();
                        }
                        catch (Exception d)
                        {
                            MessageBox.Show(d.Message);
                        }
                        finally
                        {
                            sqlConnection.Close();
                            updatedatauser();
                        }
                        //this.Hide();
                        //Form3 form3 = new Form3();
                        //form3.Show();
                        this.Controls.Clear();
                        Form3 signupconfirm = new Form3();
                        signupconfirm.Visible = true;
                        signupconfirm.FormBorderStyle = FormBorderStyle.None;
                        signupconfirm.Dock = DockStyle.Fill;
                        signupconfirm.TopLevel = false;
                        this.Controls.Add(signupconfirm);
                    }
                }
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        bool sudah = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(sudah==false)
            {
                button3.Enabled = true;
                sudah = true;
            }
            else
            {
                button3.Enabled=false;
                sudah = false;
            }

        }
        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }
        private void TextBox2_GotFocus(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
        }
        private void TextBox3_GotFocus(object sender, EventArgs e)
        {
            textBox3.Text ="";
            //textBox3.UseSystemPasswordChar = true;
            //textBox3.PasswordChar = '*';
            textBox3.KeyPress += NumericTextBox_KeyPress;
        }
        private void TextBox4_GotFocus(object sender, EventArgs e)
        {
            textBox4.Text = "";
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

        private void label1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Form2 signinpage = new Form2();
            signinpage.Visible = true;
            signinpage.FormBorderStyle = FormBorderStyle.None;
            signinpage.Dock = DockStyle.Fill;
            signinpage.TopLevel = false;
            this.Controls.Add(signinpage);
        }
        bool cek = true;
        string simpenpass;
        string simpenpassconfirm;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            simpenpass = textBox4.Text;
            if (cek == true)
            {
                textBox4.UseSystemPasswordChar = true;
                pictureBox2.Image = AD_ALP_sem_2.Properties.Resources.tutup;
                cek = false;
            }
            else
            {
                textBox4.UseSystemPasswordChar = false;
                pictureBox2.Image = AD_ALP_sem_2.Properties.Resources.buka;
                cek = true;
            }
            textBox4.Text = simpenpass;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            simpenpassconfirm = textBox3.Text;
            if (cek == true)
            {
                textBox3.UseSystemPasswordChar = true;
                pictureBox3.Image = AD_ALP_sem_2.Properties.Resources.tutup;
                cek = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = false;
                pictureBox3.Image = AD_ALP_sem_2.Properties.Resources.buka;
                cek = true;
            }
           textBox3.Text=simpenpassconfirm;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
