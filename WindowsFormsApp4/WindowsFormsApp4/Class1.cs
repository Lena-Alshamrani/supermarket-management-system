using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    
        public class class1
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-D2JB7MH6;Initial Catalog=SuperMarket;Integrated Security=True");


        public static string search(string Name, string Category)
        {
            var quary = "from ele in Product where  ele.name ==Name && ele.category == Category select ele";
            bool a;
            if (quary != null)
            {
                a = true;
            }
            else
            {
                a = false;
            }
            if (a == true)
            {
                return quary;
            }
            else
            {
                return "is not exist";
            }

        }
    }
    }

