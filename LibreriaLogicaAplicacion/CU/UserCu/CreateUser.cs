using LibreriaLogicaAplicacion.Dtos.User;
using LibreriaLogicaAplicacion.Mapper;
using System.Globalization;
using System.Text;
using LibreriaLogicaNegocio.RepoInterfaces;
using LibreriaLogicaNegocio.ApplicationInterfaces;

namespace LibreriaLogicaNegocio.CasosDeUso
{
    public class CreateUser : ICuAdd<UserCreateDto>
    {
        private readonly IUserRepo _userRepo;
        private readonly ITeamRepo _teamRepo;

        public CreateUser(IUserRepo userRepo, ITeamRepo teamRepo)
        {
            _userRepo = userRepo;
            _teamRepo = teamRepo;
        }

        public void Execute(UserCreateDto dto)
        {
            if (dto.password.Length < 8)
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");

            string cleanName = RemoveAccents(dto.name.ToLower());
            string cleanLast = RemoveAccents(dto.lastName.ToLower());
            string prefix = cleanName.Length >= 3 ? cleanName[..3] : cleanName;
            string suffix = cleanLast.Length >= 3 ? cleanLast[..3] : cleanLast;
            string email = $"{prefix}{suffix}@laempresa.com";

            int counter = 1;
            var existingUsers = _userRepo.GetAll();
            while (existingUsers.Any(u => u.Email.Value == email))
            {
                email = $"{prefix}{suffix}{counter}@laempresa.com";
                counter++;
            }
            var team = _teamRepo.GetAll().FirstOrDefault(t => t.Id == dto.teamId);
            if (team == null)
                throw new Exception($"No existe un equipo con el ID '{dto.teamId}'.");

            var newUser = UserMapper.FromDto(dto, email, team);

            _userRepo.Add(newUser);
        }
        private string RemoveAccents(string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in normalized)
            {
                var category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
