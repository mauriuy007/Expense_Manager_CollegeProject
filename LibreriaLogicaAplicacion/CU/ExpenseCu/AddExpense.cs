using LibreriaLogicaAplicacion.Dtos.Expense;
using LibreriaLogicaAplicacion.Helpers;
using LibreriaLogicaAplicacion.Mapper;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.Exceptions;
using LibreriaLogicaNegocio.RepoInterfaces;

public class AddExpense : ICuAdd<AddExpenseDto>
{
    private readonly IExpenseRepo _expenseRepo;
    private ILogRepo _repoLog;
    public AddExpense(IExpenseRepo expenseRepo, ILogRepo logRepo)
    {
        _expenseRepo = expenseRepo;
        _repoLog = logRepo;
    }
    public void Execute(AddExpenseDto dto)
    {
        bool exists = _expenseRepo
        .GetAll()
        .Any(e => e.Name.Value.Equals(dto.Name, StringComparison.OrdinalIgnoreCase));
        if (exists)
            throw new DuplicatedExpenseNameException();

        if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Description))
            throw new NullExpenseException();
        _expenseRepo.Add(ExpenseMapper.FromDto(dto));


    }
}

