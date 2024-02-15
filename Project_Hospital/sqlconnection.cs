using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project_Hospital
{
    internal class sqlconnection
    {
        public SqlConnection connection()
        {
            SqlConnection connection1 = new SqlConnection("Data Source=Rabia\\SQLEXPRESS;Initial Catalog=HospitalProject;Integrated Security=True");
            connection1.Open();
            return connection1;
        }
    }
}
