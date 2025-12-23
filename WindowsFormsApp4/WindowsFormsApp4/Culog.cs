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

namespace WindowsFormsApp4
{
    public partial class Culog : Form
    {
        public Culog()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-D2JB7MH6;Initial Catalog=SuperMarket;Integrated Security=True");


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register form6 = new Register();
            form6.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name, password;

            name = textBox1.Text;

            password = textBox2.Text;


            try
            {
                String querry = "SELECT * FROM Coustmer WHERE name= '" + textBox1.Text + "'AND password= '" + textBox2.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    name = textBox1.Text;
                    password = textBox2.Text;

                    prodcts form5 = new prodcts();
                    form5.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("invalid log in", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();

                    textBox1.Focus();
                }
            }
            catch
            {
                MessageBox.Show("error");
            }
            finally
            {
                con.Close();
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
    