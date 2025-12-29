using LibreriaLogicaNegocio.Vo;

namespace LibreriaLogicaNegocio.Entities
{
    public class UniquePayment : Payment
    {
        public PayDate PayDate { get; set; }
        public BillNumber BillNumber { get; set; }
        
        public UniquePayment(
            PaymentMethod paymentMethod,
            Expense expense,
            User user,
            Description description,
            Amount amount,
            PayDate paydate,
            BillNumber billNumber
        ) : base(paymentMethod, expense, user, description, amount)
        {
            PayDate = paydate;
            BillNumber = billNumber;
        }

        public UniquePayment() { }
    }
}
