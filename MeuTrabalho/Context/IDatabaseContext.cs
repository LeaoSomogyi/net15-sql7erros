using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho.Context
{
    public interface IDatabaseContext
    {
        SqlDataReader ExecuteCommand(string command);

        object ExecuteProcedure(string name, IEnumerable<KeyValuePair<string, string>> parameters);
    }
}
