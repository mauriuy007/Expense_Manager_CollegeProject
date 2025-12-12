using LibreriaLogicaAplicacion.Dtos.Expense;
using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.Vo;


namespace LibreriaLogicaAplicacion.Mapper
{
    public class ExpenseMapper
    {
        public static Expense FromDto(AddExpenseDto expenseDto)
        {
            return new Expense
            {
                Name = new Name(expenseDto.Name),
                Description = new Description(expenseDto.Description)
            };
        }

        public static ExpenseDto ToDto(Expense expense)
        {
            return new ExpenseDto(expense.Id,expense.Name.Value, expense.Description.Value);
        }
        public static Expense FromDto(ExpenseDto expenseDto)
        {
            return new Expense
            {
                Id = expenseDto.Id,
                Name = new Name(expenseDto.Name),
                Description = new Description(expenseDto.Description)
            };
        }



    }
}
