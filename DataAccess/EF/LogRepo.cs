using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.RepoInterfaces;

namespace Infraestructura.EF
{
    public class LogRepo : ILogRepo
    {
        private readonly LibreriaContext _context;

        public LogRepo(LibreriaContext context)
        {
            _context = context;
        }

        public void Add(Log obj)
        {
            _context.Logs.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Log> GetByExpenseId(int expenseId)
        {
            return _context.Logs
                .Where(l => l.ExpenseId == expenseId)
                .OrderByDescending(l => l.DateTime)
                .ToList();
        }
    }
}
