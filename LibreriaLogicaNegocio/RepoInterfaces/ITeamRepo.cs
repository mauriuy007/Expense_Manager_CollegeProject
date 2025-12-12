using LibreriaLogicaNegocio.Entities;

namespace LibreriaLogicaNegocio.RepoInterfaces
{
    public interface ITeamRepo : 
        IGetAllRepo<Team>,
        IGetTeamsWithUniquePaymentsHigherThan<Team>
    {
    }
}
