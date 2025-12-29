using Infraestructura.EF;
using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.Vo;

namespace Infraestructura.Data
{
    public class SeedData
    {
        private readonly LibreriaContext _context;

        public SeedData(LibreriaContext context)
        {
            _context = context;
        }
        public void Run()
        {
            if (!_context.Teams.Any()) CreateTeams();
            if (!_context.Users.Any()) CreateUsers();
            if (!_context.Expenses.Any()) CreateExpenses();
            if (!_context.Payments.Any()) CreatePayments();
            if (!_context.Logs.Any()) CreateLogs();
        }
        private void CreateTeams()
        {
            var teams = new List<Team>
            {
                new Team(new Name("Equipo Alpha")),
                new Team(new Name("Equipo Beta")),
                new Team(new Name("Equipo Gamma")),
                new Team(new Name("Equipo Delta")),
                new Team(new Name("Equipo Omega")),
                new Team(new Name("Equipo Phoenix")),
                new Team(new Name("Equipo Titan")),
                new Team(new Name("Equipo Nova")),
                new Team(new Name("Equipo Eclipse")),
                new Team(new Name("Equipo Vanguard"))
            };

            _context.Teams.AddRange(teams);
            _context.SaveChanges();
        }
        private void CreateUsers()
        {
            var teams = _context.Teams.ToList();
            var admins = new List<Administrator>
    {
                new Administrator(new Name("Lucero"), new LastName("González"), new Email("lucgon@laempresa.com"), new Password("12345654451"), teams[0]),
                new Administrator(new Name("Antonio"), new LastName("Vargas"), new Email("antvar@laempresa.com"), new Password("admin12342123"), teams[0]),
                new Administrator(new Name("Yamila"), new LastName("Lopez"), new Email("yamlop@laempresa.com"), new Password("aaa3213213232"), teams[1]),
                new Administrator(new Name("Celeste"), new LastName("Romero"), new Email("celrom@laempresa.com"), new Password("bbbVVDD233"), teams[1]),
                new Administrator(new Name("Felipe"), new LastName("Suarez"), new Email("felsua@laempresa.com"), new Password("ccc2312321gfg"), teams[2])
    };

            var employees = new List<Employee>
    {
                new Employee(new Name("Marcos"), new LastName("Pérez"), new Email("marper@laempresa.com"), new Password("abcd23123ffd"), teams[2]),
                new Employee(new Name("Goncho"), new LastName("Fernandez"), new Email("gonfer@laempresa.com"), new Password("efgh23123fffd"), teams[2]),
                new Employee(new Name("Kyoto"), new LastName("Martinez"), new Email("kyomar@laempresa.com"), new Password("ijkl23244f"), teams[3]),
                new Employee(new Name("Akame"), new LastName("Silva"), new Email("akasiv@laempresa.com"), new Password("mnop2323ggrfd23"), teams[3]),
                new Employee(new Name("Osito"), new LastName("Torres"), new Email("ositto@laempresa.com"), new Password("qrstdsqdsad213"), teams[4])
    };

            var managers = new List<Manager>
    {
                new Manager(new Name("Mauricio"), new LastName("Parodi"), new Email("maupar@laempresa.com"), new Password("pass2132442321"), teams[4]),
                new Manager(new Name("Lucía"), new LastName("Flores"), new Email("lucflo@laempresa.com"), new Password("1223434223"), teams[0]),
                new Manager(new Name("Ezequiel"), new LastName("Ramos"), new Email("ezeram@laempresa.com"), new Password("456aasdsda"), teams[1]),
                new Manager(new Name("Paula"), new LastName("Cruz"), new Email("paucru@laempresa.com"), new Password("789dfdsdfd"), teams[2]),
                new Manager(new Name("Martina"), new LastName("Sosa"), new Email("marsos@laempresa.com"), new Password("321asdsdffwe"), teams[3])
    };

            _context.Users.AddRange(admins);
            _context.Users.AddRange(employees);
            _context.Users.AddRange(managers);
            _context.SaveChanges();
        }


        private void CreateExpenses()
        {
            var expenses = new List<Expense>
            {
                new Expense(new Name("Electricidad"), new Description("Factura mensual de electricidad")),
                new Expense(new Name("Internet"), new Description("Conexión de fibra óptica para la oficina")),
                new Expense(new Name("Agua"), new Description("Pago del servicio de agua")),
                new Expense(new Name("Suministros"), new Description("Compra de suministros de oficina")),
                new Expense(new Name("Software"), new Description("Suscripciones a herramientas y licencias")),
                new Expense(new Name("Mantenimiento"), new Description("Mantenimiento de edificios y equipos")),
                new Expense(new Name("Limpieza"), new Description("Servicios profesionales de limpieza")),
                new Expense(new Name("Transporte"), new Description("Combustible y mantenimiento de vehículos de la empresa")),
                new Expense(new Name("Marketing"), new Description("Publicidad y materiales promocionales")),
                new Expense(new Name("Capacitación"), new Description("Cursos y talleres para empleados"))
            };

            _context.Expenses.AddRange(expenses);
            _context.SaveChanges();
        }

        private void CreatePayments()
        {
            var expenses = _context.Expenses.ToList();
            var users = _context.Users.ToList();

            var uniquePayments = new List<UniquePayment>
        {
            new UniquePayment(

                new PaymentMethod("Credito"),
                expenses[0],
                users[0],
                new Description("Electricidad - Marzo"),
                new Amount(150.00),
                new PayDate(DateTime.Now.AddDays(-10)),
                new BillNumber("12328291")
            ),

            new UniquePayment(
                
                new PaymentMethod("Efectivo"),
                expenses[1],
                users[1],
                new Description("Internet - Marzo"),
                new Amount(80.50),
                new PayDate(DateTime.Now.AddDays(-9)),
                new BillNumber("12328292")
            ),

            new UniquePayment(
                
                new PaymentMethod("Efectivo"),
                expenses[2],
                users[2],
                new Description("Agua - Marzo"),
                new Amount(65.20),
                new PayDate(DateTime.Now.AddDays(-8)),
                new BillNumber("12328293")
            ),

            new UniquePayment(
                
                new PaymentMethod("Credito"),
                expenses[3],
                users[3],
                new Description("Gastos de oficina"),
                new Amount(220.75),
                new PayDate(DateTime.Now.AddDays(-7)),
                new BillNumber("12328294")
            ),

            new UniquePayment(
                
                new PaymentMethod("Efectivo"),
                expenses[4],
                users[4],
                new Description("Compra de software"),
                new Amount(300.00),
                new PayDate(DateTime.Now.AddDays(-6)),
                new BillNumber("12328295")
            )
        };

            _context.Payments.AddRange(uniquePayments);
            _context.SaveChanges();


            var recurringPayments = new List<RecurringPayment>
        {
            new RecurringPayment(
                
                new PaymentMethod("Credito"),
                expenses[0],
                users[5],
                new Description("Electricidad recurrente"),
                new Amount(130.00),
                new DateFrom(DateTime.Now.AddMonths(-3)),
                new DateTill(DateTime.Now.AddMonths(3))
            ),

            new RecurringPayment(
                
                new PaymentMethod("Efectivo"),
                expenses[1],
                users[6],
                new Description("Internet"),
                new Amount(75.00),
                new DateFrom(DateTime.Now.AddMonths(-6)),
                new DateTill(DateTime.Now.AddMonths(6))
            ),

            new RecurringPayment(
                
                new PaymentMethod("Efectivo"),
                expenses[4],
                users[7],
                new Description("Software"),
                new Amount(50.00),
                new DateFrom(DateTime.Now.AddMonths(-2)),
                new DateTill(DateTime.Now.AddMonths(10))
            ),

            new RecurringPayment(
                
                new PaymentMethod("Credito"),
                expenses[2],
                users[8],
                new Description("Plan de agua"),
                new Amount(40.00),
                new DateFrom(DateTime.Now.AddMonths(-1)),
                new DateTill(DateTime.Now.AddMonths(5))
            ),

            new RecurringPayment(
                
                new PaymentMethod("Efectivo"),
                expenses[3],
                users[9],
                new Description("Restock de suministros"),
                new Amount(90.00),
                new DateFrom(DateTime.Now.AddMonths(-4)),
                new DateTill(DateTime.Now.AddMonths(8))
            )
        };

            _context.Payments.AddRange(recurringPayments);
            _context.SaveChanges();

        }
        private void CreateLogs()
        {
            // Traemos todos los expenses realmente creados en DB
            var expenses = _context.Expenses.OrderBy(e => e.Id).ToList();

            // Validamos que haya al menos 10 (porque tu ejemplo usa 10)
            if (expenses.Count < 10)
                throw new Exception("No hay suficientes expenses en la base de datos para crear logs.");

            var logs = new List<Log>
    {
            // ==== CREACIÓN DE EXPENSES ====
            new Log("Se creó el gasto 'Electricidad'", "create", expenses[0].Id, 1),
            new Log("Se creó el gasto 'Internet'", "create", expenses[1].Id, 2),
            new Log("Se creó el gasto 'Agua'", "create", expenses[2].Id, 3),
            new Log("Se creó el gasto 'Suministros'", "create", expenses[3].Id, 4),
            new Log("Se creó el gasto 'Software'", "create", expenses[4].Id, 5),

            // ==== ACTUALIZACIONES ====
            new Log("Se actualizó descripción de 'Electricidad'", "update", expenses[0].Id, 1),
            new Log("Se actualizó nombre de 'Internet'", "update", expenses[1].Id, 2),
            new Log("Se actualizó descripción de 'Software'", "update", expenses[4].Id, 5),
            new Log("Se actualizó nombre de 'Marketing'", "update", expenses[8].Id, 9),

            // ==== ELIMINACIONES ====
            new Log("Se eliminó el gasto 'Limpieza'", "delete", expenses[6].Id, 1),
            new Log("Se eliminó el gasto 'Transporte'", "delete", expenses[7].Id, 1),

            // ==== LECTURAS (READ) ====
            new Log("Se visualizó el gasto 'Electricidad'", "read", expenses[0].Id, 6),
            new Log("Se visualizó el gasto 'Agua'", "read", expenses[2].Id, 7),
            new Log("Se visualizó el gasto 'Marketing'", "read", expenses[8].Id, 9),
            new Log("Se visualizó el gasto 'Capacitación'", "read", expenses[9].Id, 8),

            // ==== CONSULTAS MASIVAS ====
            new Log("Se listaron todos los gastos del sistema", "read-all", expenses[0].Id, 1),
            new Log("Se listaron todos los gastos del sistema", "read-all", expenses[1].Id, 2),
    };

            _context.Logs.AddRange(logs);
            _context.SaveChanges();
        }



    }

}
