using LibreriaLogicaAplicacion.Dtos.Expense;
using LibreriaLogicaAplicacion.Dtos.User;
using LibreriaLogicaNegocio.Entities;

namespace LibreriaLogicaAplicacion.Helpers
{
    public static class LogHelper
    {
        public static string BuildExpenseLogMessage(AddExpenseDto dto)
        {
            return $"Expense affected -> Name: {dto.Name}, Description: {dto.Description}";
        }
        public static string BuildExpenseLogMessage(Expense expense)
        {
            return $"Expense deleted -> Id: {expense.Id}, Name: {expense.Name}, Description: {expense.Description}";
        }
        public static string BuildExpenseLogMessage(ExpenseDto dto)
        {
            return $"Expense updated -> Id: {dto.Id}, Name: {dto.Name}, Description: {dto.Description}";
        }

    }
}
