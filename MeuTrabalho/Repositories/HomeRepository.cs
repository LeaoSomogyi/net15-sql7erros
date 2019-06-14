using MeuTrabalho.Contracts;

namespace MeuTrabalho.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly IDatabaseContext _context;

        public HomeRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void InsertLog(string text)
        {
            string command = "INSERT INTO TBLog VALUES (@text)";

            _context.ExecuteInsert(command, "@text", text);
        }
    }
}
