using LibreriaLogicaAplicacion.Dtos.Payment;
using LibreriaLogicaAplicacion.Mapper;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.Exceptions;
using LibreriaLogicaNegocio.RepoInterfaces;

public class AddPaymentAPI : ICuAddPaymentAPI<AddPaymentDto>
{
    private readonly IPaymentRepo _paymentRepo;
    public AddPaymentAPI(IPaymentRepo paymentRepo)
    {
        _paymentRepo = paymentRepo;
    }
    public int Execute(AddPaymentDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.PaymentMethod) ||
        string.IsNullOrWhiteSpace(dto.Description) ||
        string.IsNullOrWhiteSpace(dto.PaymentType) ||
        dto.Amount <= 0 ||
        dto.ExpenseId <= 0 ||
        dto.UserId <= 0)
            throw new InvalidPaymentException();

        if (dto.DateFrom.HasValue && dto.DateTill.HasValue && dto.DateFrom > dto.DateTill)
            throw new InvalidPaymentDatesException();

        if (dto.PayDate.HasValue && dto.PayDate < dto.DateFrom)
            throw new InvalidPaymentDatesException();

        if (!string.IsNullOrWhiteSpace(dto.BillNumber))
        {
            if (dto.BillNumber.Length > 20 || !dto.BillNumber.All(char.IsDigit))
                throw new InvalidPaymentBillException();
        }
        if (dto.PaymentMethod != "Efectivo" && dto.PaymentMethod != "Credito")
        {
            throw new InvalidPaymentMethodException();
        }
        var payment = PaymentMapper.FromDto(dto, dto.UserId);
        return _paymentRepo.AddPayment(payment);
  
    }
}
