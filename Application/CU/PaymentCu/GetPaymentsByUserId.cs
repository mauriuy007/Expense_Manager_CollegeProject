using LibreriaLogicaAplicacion.Dtos.Payment;
using LibreriaLogicaAplicacion.Mapper;
using LibreriaLogicaNegocio.RepoInterfaces;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.Exceptions;
using LibreriaLogicaNegocio.Entities;

namespace LibreriaLogicaAplicacion.CU.PaymentCu
{
   public class GetPaymentsByUserId : ICuGetPaymentsByUserId<GetAllPaymentsDto>
    {
        private readonly IPaymentRepo _repo;
        private readonly PaymentMapper _mapper;

        public GetPaymentsByUserId(IPaymentRepo repo)
        {
            _repo = repo;
        }
        public IEnumerable<GetAllPaymentsDto> Execute(int id)
        {
            var payments = _repo.GetPaymentsByUserId(id);
            return payments.Select(p => PaymentMapper.ToDto(p)).ToList();
        }
    }
}
