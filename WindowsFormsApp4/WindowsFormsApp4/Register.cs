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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        string connctionString = "Data Source=LAPTOP-D2JB7MH6;Initial Catalog=SuperMarket;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.textBox1.Text;
            string password = this.textBox2.Text;
            using (SqlConnection con = new SqlConnection(connctionString))
            {
                string quary = "insert into Coustmer (name, password) values (@name, @password)";
                using (SqlCommand command = new SqlCommand(quary, con))
                {
                    command.Parameters.AddWithValue("name", name);
                    command.Parameters.AddWithValue("password", password);
                    con.Open();
                    int rowAffected = command.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("accont added");
                    }
                    else
                        MessageBox.Show("failed");
                    
                }

            }
            this.Hide();
        }
    }
}
