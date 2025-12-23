using System;
using System.Collections;
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

namespace WindowsFormsApp4
{
    public partial class Basket : Form
    {
        public Basket()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataTable dc = new DataTable();

        private void Form7_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=LAPTOP-D2JB7MH6;Initial Catalog=SuperMarket;Integrated Security=True";
            show();


        }

        private void show()
        {
            con.Open();
            var query = "Select Name, Category, Brand, Quantity, Price from Basket";
            da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal totalPrice = CalculateTotalPrice();
            label2.Text = totalPrice.ToString("0.00");
        }
        private decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (DataRow row in dt.Rows)
            {
                decimal price = Convert.ToDecimal(row["Price"]);
                int quantity = Convert.ToInt32(row["Quantity"]);
                totalPrice += price * quantity;

            }

            return totalPrice;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string deleteQuery = "DELETE FROM Basket;";
            SqlCommand command = new SqlCommand(deleteQuery, con);
            command.ExecuteNonQuery();

            con.Close();
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from Basket where Name ='" + textBox1.Text + "'";

            cmd.ExecuteNonQuery();
            con.Close();
            GetDataa();



        }
        private void GetDataa()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("select * from Basket", con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
    }
    
}

