using LibreriaLogicaNegocio.Interfaces;
using LibreriaLogicaNegocio.Vo;

namespace LibreriaLogicaNegocio.Entities
{
    public class Payment : IEntity, IValidation
    {
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Expense Expense { get; set; }
        public int ExpenseId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Description Description { get; set; }
        public Amount Amount { get; set; }

        public Payment(PaymentMethod paymentMethod, Expense expense, User user, Description description, Amount amount)
        { 
            PaymentMethod = paymentMethod;
            Expense = expense;
            User = user;
            Description = description;
            Amount = amount;
        }

        public Payment() { }
        public void Validate()
        {

        }

    }
}

