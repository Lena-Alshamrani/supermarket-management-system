using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class Mglog : Form
    {
        public Mglog()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-D2JB7MH6;Initial Catalog=SuperMarket;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {

            String username, user_password;
            username = textBox1.Text;
            user_password = textBox2.Text;

            try
            {
                String querry = "SELECT * FROM Login_new WHERE username = '" + textBox1.Text + "' AND password ='" + textBox2.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(querry, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    user_password = textBox2.Text;

                    // Create an instance of Form4
                    controlP form4 = new controlP();
                    form4.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
