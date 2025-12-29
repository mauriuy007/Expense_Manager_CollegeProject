using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.RepoInterfaces;
using UserEntity = LibreriaLogicaNegocio.Entities.User; 

namespace LibreriaLogicaAplicacion.CU.UserCu
{
    public class GetUserByEmail : ICuGetByEmail<UserEntity, string>
    {
        private readonly IUserRepo _userRepo;

        public GetUserByEmail(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public UserEntity Execute(string email)
        {
            return _userRepo.GetByEmail(email);
        }
    }
}

