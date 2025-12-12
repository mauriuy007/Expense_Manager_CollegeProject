using LibreriaLogicaAplicacion.Dtos.User;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.RepoInterfaces;
using LibreriaLogicaAplicacion.Mapper;

namespace LibreriaLogicaAplicacion.CU.UserCu
{
    public class GetAllUsers : ICuGetAll<UserIndexDto>
    {
        private readonly IUserRepo _userRepo;
        public GetAllUsers(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public IEnumerable<UserIndexDto> Execute()
        {
            var users = _userRepo.GetAll();
            return users.Select(UserMapper.ToDto);
        }
    }
}
