using LibreriaLogicaNegocio.Entities;

namespace LibreriaLogicaNegocio.RepoInterfaces
{
    public interface IUserRepo : 
        IGetByEmail<User>,
        IGetUsersByHigherAmount<User>,
        IGetAllRepo<User>,
        IAddRepo<User>,
        IUpdatePasswordRepo<User>,
        IGetByTeamId<User>
    {

    }
}
