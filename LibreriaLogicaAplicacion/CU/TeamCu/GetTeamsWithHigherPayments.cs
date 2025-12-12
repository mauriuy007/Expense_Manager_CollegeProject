using LibreriaLogicaAplicacion.Dtos.Team;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.RepoInterfaces;
using LibreriaLogicaNegocio.Exceptions;
using LibreriaLogicaAplicacion.Mapper;

public class GetTeamsWithHigherPayments : ICuGetTeamsWithHigherPayments<TeamDto>
{
    private readonly IUserRepo _userRepo;
    private readonly ITeamRepo _teamRepo;
    private readonly IPaymentRepo _paymentRepo;

    public GetTeamsWithHigherPayments(IUserRepo userRepo, ITeamRepo teamRepo, IPaymentRepo paymentRepo)
    {
        _userRepo = userRepo;
        _teamRepo = teamRepo;
        _paymentRepo = paymentRepo;
    }

    public IEnumerable<TeamDto> Execute(double amount)
    {
        if (amount <= 0)
            throw new NegativeAmountException();

        var teams = _teamRepo.GetTeamsWithUniquePaymentsHigherThan(amount);

        return teams
            .Select(TeamMapper.ToDto)
            .OrderByDescending(t => t.Name)
            .ToList();
    }

}