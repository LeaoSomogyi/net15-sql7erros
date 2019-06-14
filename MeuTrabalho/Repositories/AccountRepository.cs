using MeuTrabalho.Contracts;
using System.Collections.Generic;

namespace MeuTrabalho.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDatabaseContext _context;

        public AccountRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public string Login(string email, string password)
        {
            IEnumerable<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("@Email", email),
                    new KeyValuePair<string, string>("@Pwd", password)
                };

            var result = _context.ExecuteProcedure("SP_Login", parameters);

            return result?.ToString();
        }
    }
}
