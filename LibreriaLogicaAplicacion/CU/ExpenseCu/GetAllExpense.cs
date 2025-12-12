using LibreriaLogicaAplicacion.Dtos.Expense;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.RepoInterfaces;

namespace LibreriaLogicaAplicacion.CU.ExpenseCu
{
    public class GetAllExpense : ICuGetAll<ExpenseDto>
    {
        private readonly IExpenseRepo _expenseRepo;
        private readonly ILogRepo _logRepo;
        public GetAllExpense(IExpenseRepo expenseRepo, ILogRepo logRepo)
        {
            _expenseRepo = expenseRepo;
            _logRepo = logRepo;
        }
        public IEnumerable<ExpenseDto> Execute()
        {
            var expenses = _expenseRepo.GetAll()
                .Select(expense => new ExpenseDto(
                    expense.Id,
                    expense.Name.Value,
                    expense.Description.Value
                ))
                .ToList();
            return expenses;
        }
    }
}
