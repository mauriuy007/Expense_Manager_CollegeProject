using LibreriaLogicaAplicacion.Dtos.Expense;
using LibreriaLogicaAplicacion.Mapper;
using LibreriaLogicaNegocio.ApplicationInterfaces;

public class GetExpenseById : ICuGetById<ExpenseDto>
{
    private readonly IExpenseRepo _expenseRepo;
    public GetExpenseById(IExpenseRepo expenseRepo)
    {
        _expenseRepo = expenseRepo;
    }
    public ExpenseDto Execute(int id)
    {
        var expense = _expenseRepo.GetById(id);
        if (expense == null) return null;

        return ExpenseMapper.ToDto(expense);
    }
}
