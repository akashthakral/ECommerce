using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ecommerce.DataAccess
{
    
    public class ConnectionManager
    {
        static string _connectionString;
        public ConnectionManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static SqlConnection CreateConnection()
        {
            SqlConnection con = new SqlConnection();
            con.Open();
            return con;
        }
    }
}
