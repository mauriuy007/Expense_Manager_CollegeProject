using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaLogicaAplicacion.Dtos.Log;
using LibreriaLogicaNegocio.Entities;

namespace LibreriaLogicaAplicacion.Mapper
{
    public static class LogMapper
    {
        public static LogDto ToDto(Log log)
        {
            return new LogDto(
                log.Id,
                log.Message,
                log.Operation,
                log.DateTime,
                log.ExpenseId,
                log.UserId
            );
        }
    }
}
