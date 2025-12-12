using LibreriaLogicaAplicacion.Dtos.Team;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.RepoInterfaces;

namespace LibreriaLogicaAplicacion.CU.Team
{
    public class GetAllTeamsForSelect : ICuGetAll<TeamForSelectDto>
    {
        private readonly ITeamRepo _repo;

        public GetAllTeamsForSelect(ITeamRepo repo)
        {
            _repo = repo;
        }
        public IEnumerable<TeamForSelectDto> Execute()
        {
            return _repo.GetAll()
                .Select(t => new TeamForSelectDto(t.Id, t.Name.Value))
                .ToList();
        }
    }
}
