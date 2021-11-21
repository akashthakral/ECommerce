using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Ecommerce.DataAccess
{
    public class DbManager : ConnectionManager
    {
        public DbManager(string connectionString) : base(connectionString) { }
        public void ExecuteQuery(string sqlCommand,CommandType commandType, Dictionary<string,object> paramCollection = null)
        {
            using SqlConnection _connection = CreateConnection();
            SqlCommand _sqlCommand = new SqlCommand(sqlCommand, _connection);
            _sqlCommand.CommandType = commandType;
            if (paramCollection!=null && paramCollection.Count > 0)
            {
                foreach (var param in paramCollection)
                    _sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
            }
            _sqlCommand.ExecuteNonQuery();
        }
        public DataTable ReadData(string sqlCommand,CommandType commandType, Dictionary<string,object> paramCollection = null)
        {
            using SqlConnection _connection = CreateConnection();
            SqlDataAdapter _sqlAdapted = new SqlDataAdapter(sqlCommand,_connection);
            _sqlAdapted.SelectCommand.CommandType = commandType;
            if(paramCollection!=null && paramCollection.Count > 0)
            {
                foreach (var param in paramCollection)
                    _sqlAdapted.SelectCommand.Parameters.AddWithValue(param.Key, param.Value);
            }
            DataTable dt = new DataTable();
            _sqlAdapted.Fill(dt);
            return dt;
        }
        public object ReadSigularData(string sqlCommand,CommandType commandType, Dictionary<string,object> paramCollection)
        {
            using SqlConnection _connection = CreateConnection();
            SqlCommand _sqlCommand = new SqlCommand(sqlCommand, _connection);
            _sqlCommand.CommandType = commandType;
            if (paramCollection != null && paramCollection.Count > 0)
            {
                foreach (var param in paramCollection)
                    _sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
            }
            return _sqlCommand.ExecuteScalar();
        }
    }
}
