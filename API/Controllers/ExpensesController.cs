using System.Runtime.CompilerServices;
using LibreriaLogicaAplicacion.Dtos.Expense;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaAplicacion.CU.LogCu;
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ICuGetAll<ExpenseDto> _getAllExpenses;
        private readonly GetLogsByExpenseId _getLogsByExpenseId;
        public ExpensesController(ICuGetAll<ExpenseDto> getAllExpenses, GetLogsByExpenseId getLogsByExpenseId)
        {
            _getAllExpenses = getAllExpenses;
            _getLogsByExpenseId = getLogsByExpenseId;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_getAllExpenses.Execute());
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{expenseId}/logs")]
        public IActionResult GetLogsByExpenseId(int expenseId)
        {
            var logs = _getLogsByExpenseId.Execute(expenseId);

            if (!logs.Any())
                return NoContent();

            return Ok(logs);
        }

    }
}
