using LibreriaLogicaAplicacion.Dtos.User;
using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaNegocio.Vo;

namespace LibreriaLogicaAplicacion.Mapper
{
    public static class UserMapper
    {
        public static User FromDto(UserLoginDto userDto)
        {
            return new User
            {
                Email = new Email(userDto.Email),
                Password = new Password(userDto.Password)
            };
        }
        public static UserIndexDto ToDto(User user)
        {
            return new UserIndexDto
            (
                user.Name.Value,
                user.LastName.Value,
                user.Email.Value
            );
        }
        public static User FromDto(UserCreateDto dto, string email, Team team)
        {
            if (dto.role == "Employee")
            {
                return new Employee(
                    new Name(dto.name),
                    new LastName(dto.lastName),
                    new Email(email),
                    new Password(dto.password),
                    team
                );
            }
            else if (dto.role == "Manager")
            {
                return new Manager(
                    new Name(dto.name),
                    new LastName(dto.lastName),
                    new Email(email),
                    new Password(dto.password),
                    team
                );
            }

            throw new Exception($"El tipo de usuario '{dto.role}' no es válido.");
        }

    }
}
