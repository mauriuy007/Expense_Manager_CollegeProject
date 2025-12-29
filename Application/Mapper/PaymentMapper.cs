using LibreriaLogicaAplicacion.Dtos.Payment;
using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.Vo;

namespace LibreriaLogicaAplicacion.Mapper
{
    public class PaymentMapper
    {
        public static Payment FromDto(AddPaymentDto dto, int userId)
        {
            return dto.PaymentType switch
            {
                "Unique" => new UniquePayment
                {
                    PaymentMethod = new PaymentMethod(dto.PaymentMethod),
                    Description = new Description(dto.Description),
                    Amount = new Amount(dto.Amount),
                    ExpenseId = dto.ExpenseId,
                    UserId = userId,
                    PayDate = new PayDate(dto.PayDate!.Value),
                    BillNumber = new BillNumber(dto.BillNumber)
                },

                "Recurring" => new RecurringPayment
                {
                    PaymentMethod = new PaymentMethod(dto.PaymentMethod),
                    Description = new Description(dto.Description),
                    Amount = new Amount(dto.Amount),
                    ExpenseId = dto.ExpenseId,
                    UserId = userId,
                    DateFrom = new DateFrom(dto.DateFrom!.Value),
                    DateTill = new DateTill(dto.DateTill!.Value)
                },

                _ => throw new ArgumentException("Unknown payment type")
            };
        }

        public static GetAllPaymentsDto ToDto(Payment payment)
        {
            if (payment is UniquePayment up)
            {
                return new GetAllPaymentsDto
                {
                    Id = up.Id,
                    UserName = up.User.Name.Value,
                    Description = up.Description.Value,
                    Amount = up.Amount.Value,
                    PayDate = up.PayDate.Value,
                    PaymentType = "Unique",
                    ExpenseType = up.Expense.Name.Value,
                    RemainingBalance = 0
                };
            }
            else if (payment is RecurringPayment rp)
            {
                return new GetAllPaymentsDto
                {
                    Id = rp.Id,
                    UserName = rp.User.Name.Value,
                    Description = rp.Description.Value,
                    Amount = rp.Amount.Value,
                    PayDate = null,
                    PaymentType = "Recurring",
                    ExpenseType = rp.Expense.Name.Value,
                    RemainingBalance = RemainingBalance(rp)
                };
            }

            throw new ArgumentException("Unknown payment type");
        }




        private static double RemainingBalance(RecurringPayment rp)
        {
            DateTime from = rp.DateFrom.Value;
            DateTime to = rp.DateTill.Value;
            DateTime today = DateTime.Today;

            double remainingMonths = ((to.Year - today.Year) * 12) + to.Month - today.Month;
            if (remainingMonths < 0)
                remainingMonths = 0;

            return rp.Amount.Value * remainingMonths;
        }



    }
}
