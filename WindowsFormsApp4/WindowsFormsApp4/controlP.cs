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
    public partial class controlP : Form
    {
        public controlP()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-D2JB7MH6;Initial Catalog=SuperMarket;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "insert into Product (id,name,category,brand,quantity,price) values ('" + textId.Text + "','" + textName.Text + "','" + textCategory.Text + "','" + textBrand.Text + "','" + textQuant.Text + "','" + textPrice.Text + "')";
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Added successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetDataa();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "delete from Product where id ='" + textId.Text+"'";

            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Delete successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetDataa();
        }

        private void GetDataa()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("select * from Product", con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }


        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        private void show()
        {
 con.ConnectionString = @"Data Source=LAPTOP-D2JB7MH6;Initial Catalog=SuperMarket;Integrated Security=True";
            con.Open();
            var query = "Select id,name, category, brand,quantity,price from Product";
            da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


        }
       private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Update Product" +
                " set name='" +textName.Text+ "',category='"+textCategory.Text+"',brand='"+textBrand.Text+ "',quantity='"+ textQuant.Text+ "',price='"+textPrice.Text+"' where id ='" + textId.Text + "'";

            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Update successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetDataa();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult res;
            res = MessageBox.Show("Do you want exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Welcome form1 = new Welcome();
                form1.Show();
            }
            else
            {
                this.Show();
            }
        }
    }
}
