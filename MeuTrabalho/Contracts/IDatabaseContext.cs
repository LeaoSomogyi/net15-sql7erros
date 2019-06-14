using System.Collections.Generic;

namespace MeuTrabalho.Contracts
{
    public interface IDatabaseContext
    {
        /// <summary>
        /// Method responsible for execute inserts
        /// </summary>
        /// <param name="command">SQL Command</param>
        /// <param name="parameter">Parameter to be replaced on command</param>
        /// <param name="value">Parameter value</param>
        void ExecuteInsert(string command, string parameterName, string value);

        /// <summary>
        /// Method responsible for execute Stored Procedures
        /// </summary>
        /// <param name="name">Procedure Name</param>
        /// <param name="parameters">List of parameters and his values</param>
        /// <returns></returns>
        object ExecuteProcedure(string name, IEnumerable<KeyValuePair<string, string>> parameters);
    }
}
