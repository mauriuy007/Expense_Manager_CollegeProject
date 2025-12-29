using LibreriaLogicaAplicacion.Dtos.User;
using LibreriaLogicaAplicacion.Mapper;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.Exceptions;
using LibreriaLogicaNegocio.RepoInterfaces;

namespace LibreriaLogicaAplicacion.CU.UserCu
{
    public class GetUsersByHigherAmount: ICuGetByHigherAmount<UserIndexDto>
    {
        private readonly IUserRepo _repo;
        
        public GetUsersByHigherAmount(IUserRepo repo, PaymentMapper mapper)
        {
            _repo = repo;
        }
        public IEnumerable<UserIndexDto> Execute(double amount)
        {
            if (amount < 0)
            {
                throw new NegativeAmountException(); 
            }
            var users = _repo.GetUsersByHigherAmount(amount);
            return users
                .Select(u => UserMapper.ToDto(u)) 
                .Distinct()                           
                .ToList();
        }
    }
}
