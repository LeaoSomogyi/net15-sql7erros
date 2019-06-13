using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho.Context
{
    public class DatabaseContext : IDatabaseContext
    {
        private ConnectionSettings _connectionSettings;

        public DatabaseContext(ConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }

        public DatabaseContext()
        {

        }

        public SqlDataReader ExecuteCommand(string command)
        {
            SqlConnection connection = new SqlConnection(_connectionSettings.Conn);

            try
            {
                connection.Open();

                SqlCommand sql = new SqlCommand(command, connection);

                return sql.ExecuteReader();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public object ExecuteProcedure(string name, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionSettings.Conn);

            try
            {
                connection.Open();

                SqlCommand sql = new SqlCommand(name, connection);
                sql.CommandType = System.Data.CommandType.StoredProcedure;                

                foreach (var parameter in parameters)
                {
                    sql.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                var reader = sql.ExecuteReader();

                if (reader.Read())
                {
                    return reader["username"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}
