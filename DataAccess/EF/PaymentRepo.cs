using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
namespace Infraestructura.EF
{
    public class PaymentRepo : IPaymentRepo
    {
        private readonly LibreriaContext _context;
        public PaymentRepo(LibreriaContext context)
        {
            _context = context;
        }
        public void Add(Payment obj)
        {
            _context.Payments.Add(obj);
            _context.SaveChanges();
        }
        public IEnumerable<Payment> GetAll()
        {
            return _context.Payments
                .Include(p => p.User)       
                .Include(p => p.Expense)   
                .ToList();
        }
        public IEnumerable<Payment> GetPaymentByYearMonth(int year, int month)
        {
            var uniquePayments = _context.Payments
                .OfType<UniquePayment>()
                .Include(p => p.User)
                .Include(p => p.Expense)
                .Where(up => up.PayDate.Value.Year == year && up.PayDate.Value.Month == month)
                .ToList(); 

            var recurringPayments = _context.Payments
                .OfType<RecurringPayment>()
                .Include(p => p.User)
                .Include(p => p.Expense)
                .Where(rp =>
                    (rp.DateFrom.Value.Year <= year && rp.DateFrom.Value.Month <= month) &&
                    (rp.DateTill.Value.Year >= year && rp.DateTill.Value.Month >= month))
                .ToList(); 

            return uniquePayments
                .Cast<Payment>()
                .Concat(recurringPayments.Cast<Payment>())
                .ToList();
        }
        public IEnumerable<Payment> GetUsersByHigherAmount(double amount)
        {
            return _context.Payments.Where(p => p.Amount.Value > amount).Include(p => p.User).ToList();
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public Payment GetById(int id)
        {
            return _context.Payments
                .Include(p => p.User)
                .Include(p => p.Expense)
                .FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Payment> GetPaymentsByUserId(int userId)
        {
            return _context.Payments
                .Include(p => p.User)
                .Include(p => p.Expense)
                .Where(p => p.UserId == userId)
                .ToList();
        }


        public int AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return payment.Id;
        }



    }
}
