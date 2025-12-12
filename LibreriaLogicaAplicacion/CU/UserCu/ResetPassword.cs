using LibreriaLogicaAplicacion.Dtos.User;
using LibreriaLogicaAplicacion.Mapper;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.Exceptions;
using LibreriaLogicaNegocio.RepoInterfaces;

namespace LibreriaLogicaAplicacion.CU.UserCu
{
    public class ResetPassword : ICuUpdatePassword<UserResetDto>
    {
        private readonly IUserRepo _userRepo;

        public ResetPassword(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public string Execute(UserResetDto dto)
        {
            var user = _userRepo.GetByEmail(dto.email);

            if (user == null)
                throw new NotFoundUserException();

            var newPassword = GenerateRandomPassword();

            user.Password.Value = newPassword;

            _userRepo.Update(user);

            return newPassword;
        }
        private string GenerateRandomPassword()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }
    }
}
    
