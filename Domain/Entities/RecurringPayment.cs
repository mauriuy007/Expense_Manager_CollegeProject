using LibreriaLogicaNegocio.Vo;

namespace LibreriaLogicaNegocio.Entities
{
    public class RecurringPayment : Payment
    {
        public DateFrom DateFrom { get; set; }
        public DateTill DateTill { get; set; }

        public RecurringPayment(
            PaymentMethod paymentMethod,
            Expense expense,
            User user,
            Description description,
            Amount amount,
            DateFrom dateFrom,
            DateTill dateTill
        ) : base(paymentMethod, expense, user, description, amount)
        {
            DateFrom = dateFrom;
            DateTill = dateTill;
        }

        public RecurringPayment() { }
    }
}
