using Infraestructura.EF;
using LibreriaLogicaNegocio.Entities;

public class ExpenseRepo : IExpenseRepo
{
    private readonly LibreriaContext _context;
    public ExpenseRepo(LibreriaContext context)
    {
        _context = context;
    }
    public void Add(Expense obj)
    {
            _context.Expenses.Add(obj);
            _context.SaveChanges();   
    }
    public void Delete(Expense obj)
    {
        _context.Expenses.Remove(obj);
        _context.SaveChanges();
    }
    public IEnumerable<Expense> GetAll()
    {
        return _context.Expenses.ToList();
    }
    public Expense GetById(int id)
    {
        return _context.Expenses.FirstOrDefault(e => e.Id == id);
    }
    public void Update(Expense expense)
    {
        var existingExpense = _context.Expenses.FirstOrDefault(e => e.Id == expense.Id);

        if (existingExpense == null)
            throw new Exception("Expense not found");

        existingExpense.Name = expense.Name;
        existingExpense.Description = expense.Description;

        _context.SaveChanges();
    }
}

