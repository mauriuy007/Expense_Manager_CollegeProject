using LibreriaLogicaAplicacion.Dtos.User;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.RepoInterfaces;
using LibreriaLogicaNegocio.Entities;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICULogin<UserLoginDto> _cuLogin;
        private readonly IJwtGenerator<AuthenticatedUserDto> _jwtGenerator;
        private readonly IUserRepo _userRepo;

        public AuthController(
            ICULogin<UserLoginDto> cuLogin,
            IJwtGenerator<AuthenticatedUserDto> jwtGenerator,
            IUserRepo userRepo)
                {
                _cuLogin = cuLogin;
                _jwtGenerator = jwtGenerator;
                _userRepo = userRepo;
                }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto usuarioLogin)
        {
            try
            {
                var (valid, userType) = _cuLogin.Execute(usuarioLogin);

                if (!valid)
                {
                    return BadRequest("Credenciales incorrectas");
                }

                var user = _userRepo.GetByEmail(usuarioLogin.Email);

                if (user == null)
                {
                    return BadRequest("Usuario no encontrado");
                }

                var authUser = new AuthenticatedUserDto(
                    user.Id,
                    user.Email.Value,
                    userType,                
                    user.Name.Value        
                );

                var token = _jwtGenerator.GenerateToken(authUser);

                var response = new UserLoginDtoResponse(
                    authUser.Id,
                    authUser.Email,
                    authUser.Role,
                    token
                );

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error inesperado");
                    
            }
        }
    }
}
