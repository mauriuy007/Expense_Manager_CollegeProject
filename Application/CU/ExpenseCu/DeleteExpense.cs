using LibreriaLogicaAplicacion.Dtos.Expense;
using LibreriaLogicaAplicacion.Helpers;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.RepoInterfaces;

public class DeleteExpense : ICuDelete<ExpenseDto>
{
    private readonly IExpenseRepo _expenseRepo;
    private readonly ILogRepo _logRepo;
    public DeleteExpense(IExpenseRepo expenseRepo, ILogRepo logRepo)
    {
        _expenseRepo = expenseRepo;
        _logRepo = logRepo;
    }
    public void Execute(int id)
    {
        var expense = _expenseRepo.GetById(id);
        if (expense != null)
        {
            _expenseRepo.Delete(expense);
        }
    }
}

