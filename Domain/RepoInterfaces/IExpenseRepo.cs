using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.RepoInterfaces;

public interface IExpenseRepo : IAddRepo<Expense>, 
    IDeleteRepo<Expense>, 
    IGetAllRepo<Expense>, 
    IGetById<Expense>, 
    IUpdateRepo<Expense>
{
}
