using MeuTrabalho.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MeuTrabalho.Context
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly ConnectionSettings _connectionSettings;

        public DatabaseContext(ConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }

        public void ExecuteInsert(string command, string parameterName, string value)
        {
            SqlConnection connection = new SqlConnection(_connectionSettings.Conn);

            try
            {
                connection.Open();

                SqlCommand sql = new SqlCommand(command, connection);
                sql.Parameters.AddWithValue(parameterName, value);

                sql.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public object ExecuteProcedure(string name, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionSettings.Conn);

            try
            {
                connection.Open();

                SqlCommand sql = new SqlCommand(name, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    sql.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                SqlDataReader reader = sql.ExecuteReader();

                if (reader.Read())
                {
                    return reader[0];
                }
                else
                {
                    return null;
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
