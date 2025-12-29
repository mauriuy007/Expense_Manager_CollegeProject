using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaLogicaAplicacion.Dtos.Log
{
    public record LogDto(
        Guid Id,
        string Message,
        string Operation,
        DateTime DateTime,
        int ExpenseId,
        int UserId
    );
}
