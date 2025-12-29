using LibreriaLogicaAplicacion.Dtos.Expense;
using LibreriaLogicaAplicacion.Helpers;
using LibreriaLogicaAplicacion.Mapper;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.Exceptions;
using LibreriaLogicaNegocio.RepoInterfaces;

namespace LibreriaLogicaAplicacion.CU.ExpenseCu
{
    public class UpdateExpense : ICuUpdate<ExpenseDto>
    {
        private readonly IExpenseRepo _repo;
        private readonly ILogRepo _logRepo;

        public UpdateExpense(IExpenseRepo repo, ILogRepo logRepo)
        {
            _repo = repo;
            _logRepo = logRepo;
        }
        public void Execute(ExpenseDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Description))
                throw new NullExpenseException();

            bool exists = _repo
            .GetAll()
            .Any(e => e.Id != dto.Id &&
                      e.Name.Value.Equals(dto.Name, StringComparison.OrdinalIgnoreCase));

            if (exists)
                throw new DuplicatedExpenseNameException();

            var expenseEntity = ExpenseMapper.FromDto(dto);

            _repo.Update(expenseEntity);
        }
    }
}
