using LibreriaLogicaNegocio.Entities;


namespace LibreriaLogicaNegocio.RepoInterfaces
{
    public interface ILogRepo
    {
        void Add(Log obj);
        IEnumerable<Log> GetByExpenseId(int expenseId);
    }
}
