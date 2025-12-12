using LibreriaLogicaAplicacion.Dtos.Payment;
using LibreriaLogicaAplicacion.Mapper;
using LibreriaLogicaNegocio.RepoInterfaces;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.Exceptions;

namespace LibreriaLogicaAplicacion.CU.PaymentCu
{
    public class GetPaymentByYearMonth : ICuGetPaymentByYearMonth<GetAllPaymentsDto>
    {
        private readonly IPaymentRepo _repo; 
        private readonly PaymentMapper _mapper;
        public GetPaymentByYearMonth(IPaymentRepo repo)
        {
            _repo = repo;
        }
        public IEnumerable<GetAllPaymentsDto> Execute(int? year, int? month)
        {
            if (!year.HasValue || !month.HasValue || year <= 0 || month <= 0 || month > 12)
            {
                throw new IncorrectFilterException();
            }

            var payments = _repo.GetPaymentByYearMonth(year.Value, month.Value);
            return payments.Select(p => PaymentMapper.ToDto(p)).ToList();
        }
    }
}
