namespace LibreriaLogicaNegocio.Entities
{
    public class Log
    {
        public Guid Id { get; set; }

        public string Message { get; set; }
        public string Operation { get; set; }
        public DateTime DateTime { get; set; }

        public int ExpenseId { get; set; }
        public Expense Expense { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Log() { }

        public Log(string message, string operation, int expenseId, int userId)
        {
            Message = message;
            Operation = operation;
            DateTime = DateTime.Now;
            ExpenseId = expenseId;
            UserId = userId;
        }
    }
}   
