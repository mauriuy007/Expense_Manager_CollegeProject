using LibreriaLogicaAplicacion.Dtos.User;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.RepoInterfaces;

namespace LibreriaLogicaAplicacion.CU.UserCu
{
    public class GetAllUsersForSelect : ICuGetAll<UserSelectDto>
    {
        private readonly IUserRepo _repo;

        public GetAllUsersForSelect(IUserRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<UserSelectDto> Execute()
        {
            return _repo.GetAll()
                .Select(u => new UserSelectDto(u.Id, u.Email.Value))
                .ToList();
        }
    }
}
