using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaAplicacion.Dtos.Team;

namespace LibreriaLogicaAplicacion.Mapper
{
    public class TeamMapper
    {
        public static TeamDto ToDto(Team team)
        {
            if (team == null)
                return null;

            return new TeamDto(team.Id, team.Name.Value);
        }
    }
}
