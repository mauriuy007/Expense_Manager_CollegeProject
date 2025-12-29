using LibreriaLogicaAplicacion.Dtos.Payment;
using LibreriaLogicaAplicacion.Mapper;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.RepoInterfaces;

public class GetAllPayments : ICuGetAll<GetAllPaymentsDto>
{
    private readonly IPaymentRepo _repo;
    private readonly PaymentMapper _mapper;
    public GetAllPayments(IPaymentRepo repo)
    {
        _repo = repo;
    }
    public IEnumerable<GetAllPaymentsDto> Execute()
    {
        var payments = _repo.GetAll();
        return payments.Select(p => PaymentMapper.ToDto(p)).ToList();
    }
}

