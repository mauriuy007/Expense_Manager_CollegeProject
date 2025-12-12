using LibreriaLogicaNegocio.RepoInterfaces;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.Entities;

public class UserLogin : ICULogin<UserLoginDto>
{
    private readonly IUserRepo _userRepo;

    public UserLogin(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public (bool, string) Execute(UserLoginDto userLoginDto)
    {
        User user = _userRepo.GetByEmail(userLoginDto.Email);
        string userType;
        if (user is Administrator a)
        {
            userType = "Administrator";
        }
        else if (user is Employee e)
        {
            userType = "Employee";
        }
        else
        {
            userType = "Manager";
        }
        return (user != null && user.Password.Value == userLoginDto.Password, userType);
    }
}
