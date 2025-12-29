using Infraestructura.EF;
using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.Exceptions;
using LibreriaLogicaNegocio.RepoInterfaces;

public class UsersRepo : IUserRepo
{
    private LibreriaContext _context;
    public UsersRepo(LibreriaContext context)
    {
        _context = context;
    }
    public User GetByEmail(string mail)
    {
        return _context.Users.FirstOrDefault(u => u.Email.Value == mail);
    }
    public IEnumerable<User> GetUsersByHigherAmount(double amount)
    {
        return _context.Users
            .Join(
                _context.Payments,
                u => u.Id,
                p => p.User.Id,
                (u, p) => new { u, p })
            .Where(x => x.p.Amount.Value > amount)
            .Select(x => x.u)
            .Distinct()
            .ToList();
    }
    public IEnumerable<User> GetAll()
    {
        return _context.Users.ToList();
    }
    public void Add(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
    }

    public string Update(User entity)
    {
        var selectedUser = _context.Users.FirstOrDefault(x => x.Id == entity.Id);
        if (selectedUser != null)
        {
            selectedUser.Password = entity.Password;
            _context.SaveChanges();
            return selectedUser.Password.Value;
        }
        else
        {
            throw new NotFoundUserException();
        }
    }

    public IEnumerable<User> GetByTeamId(int teamId)
{
    return _context.Users
        .Where(u => u.TeamId == teamId)
        .ToList();
}

}
