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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class prodcts : Form
    {
        public prodcts()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataTable dc = new DataTable();

        private void Form5_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=LAPTOP-D2JB7MH6;Initial Catalog=SuperMarket;Integrated Security=True";
            show();
        }

        private void show()
        {
            con.Open();
            var query = "Select id,name, category,brand,quantity,price from Product";
            da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox3.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                dc.Clear();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE id LIKE @searchText OR name LIKE @searchText OR category LIKE @searchText OR brand LIKE @searchText OR quantity LIKE @searchText OR price LIKE @searchText", con))
                {
                    cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dc);
                        dataGridView1.DataSource = dc;
                    }
                }
            }
            else
            {
                dc.Clear();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product", con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dc);
                        dataGridView1.DataSource = dc;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Basket (Name, Category, Brand, Quantity, Price) SELECT name, category, brand, '" + textBox5.Text + "', price FROM Product WHERE name = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            // Update the quantity in the Product table
            cmd.CommandText = "UPDATE Product SET quantity = quantity - '" + textBox5.Text + "' WHERE name = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Added successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Basket form7 = new Basket();
            form7.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}