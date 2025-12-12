using LibreriaLogicaNegocio.RepoInterfaces;
using LibreriaLogicaAplicacion.Dtos.Log;
using LibreriaLogicaAplicacion.Mapper;
using LibreriaLogicaNegocio.ApplicationInterfaces;

namespace LibreriaLogicaAplicacion.CU.LogCu
{
    public class GetLogsByExpenseId : ICuGetById<IEnumerable<LogDto>>
    {
        private readonly ILogRepo _logRepo;

        public GetLogsByExpenseId(ILogRepo logRepo)
        {
            _logRepo = logRepo;
        }

        public IEnumerable<LogDto> Execute(int expenseId)
        {
            var logs = _logRepo
                .GetByExpenseId(expenseId)
                .Select(LogMapper.ToDto)
                .ToList();

            return logs;
        }
    }
}
