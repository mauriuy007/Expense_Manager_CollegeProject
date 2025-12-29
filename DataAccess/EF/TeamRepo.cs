using Infraestructura.EF;
using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
public class TeamRepo : ITeamRepo
{
    private readonly LibreriaContext _context;
    public TeamRepo(LibreriaContext context)
    {
        _context = context;
    }
    public IEnumerable<Team> GetAll()
    {
        return _context.Teams.ToList();
    }
    public IEnumerable<Team> GetTeamsWithUniquePaymentsHigherThan(double amount)
    {
        var teams = _context.Teams.ToList();

        return teams
            .Where(team =>
            {
                var users = _context.Users
                    .Where(u => u.TeamId == team.Id)
                    .ToList();

                if (!users.Any())
                    return false;

                return users.Any(user =>
                {
                    var totalUnique = _context.Payments
                        .OfType<UniquePayment>()
                        .Where(p => p.UserId == user.Id)
                        .Sum(p => p.Amount.Value);

                    return totalUnique > amount;
                });
            })
            .ToList();
    }




}
