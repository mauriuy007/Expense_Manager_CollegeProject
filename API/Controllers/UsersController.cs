using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibreriaLogicaAplicacion.CU.UserCu;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaAplicacion.Dtos.Payment;
using LibreriaLogicaNegocio.Exceptions;
using LibreriaLogicaAplicacion.Dtos.User;
using LibreriaLogicaAplicacion.CU.ExpenseCu;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICuGetPaymentsByUserId<GetAllPaymentsDto> _getPaymentsByUserId;
        private readonly ICuUpdatePassword<UserResetDto> _updatePassword;
        private readonly ICuGetAll<UserSelectDto> _getAllUsers;

        public UsersController(ICuGetPaymentsByUserId<GetAllPaymentsDto> getPaymentsByUserId, ICuUpdatePassword<UserResetDto> updatePassword, ICuGetAll<UserSelectDto> getAllUsers)
        {
            _getPaymentsByUserId = getPaymentsByUserId;
            _updatePassword = updatePassword;
            _getAllUsers = getAllUsers;
        }

        [Authorize(Roles = "Employee,Manager")]
        [HttpGet("payments")]
        public ActionResult<IEnumerable<GetAllPaymentsDto>> GetMyPayments()
        {
            int userId = int.Parse(User.FindFirst("id")!.Value);

            var payments = _getPaymentsByUserId.Execute(userId);
            Console.WriteLine("USER ID DEL TOKEN: " + userId);

            if (payments == null || !payments.Any())
                return StatusCode(204,"No hay pagos para este usuario");

            return Ok(payments);
        }


        [Authorize(Roles = "Administrator")]
        [HttpPut("reset")]
        public IActionResult ResetPassword([FromBody] UserResetDto dto)
        {
            try
            {
                var newPassword = _updatePassword.Execute(dto);

                return Ok(new
                {
                    message = "Password reset successfully",
                    newPassword = newPassword
                });
            }
            catch (NotFoundUserException)
            {
                return NotFound("User not found");
            }
        }

        [Authorize]
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_getAllUsers.Execute());
        }
    }
}
