using LibreriaLogicaAplicacion.Dtos.Payment;
using LibreriaLogicaAplicacion.Mapper;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.RepoInterfaces;

namespace LibreriaLogicaAplicacion.CU.PaymentCu
{
    public class GetPaymentById : ICuGetById<GetAllPaymentsDto>
    {
        private readonly IPaymentRepo _repo;
        private readonly PaymentMapper _mapper;
        public GetPaymentById(IPaymentRepo repo, PaymentMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public GetAllPaymentsDto Execute(int id)
        {
            return PaymentMapper.ToDto(_repo.GetById(id));
        }
    }
}
