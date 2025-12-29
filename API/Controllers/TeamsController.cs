using LibreriaLogicaAplicacion.Dtos.Payment;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
        private readonly ICuGetTeamsWithHigherPayments<TeamDto> _getTeamsByHigherAmount;

        public TeamsController(ICuGetTeamsWithHigherPayments<TeamDto> getTeamsByHigherAmount)
        {
            _getTeamsByHigherAmount = getTeamsByHigherAmount;
        }

        [Authorize(Roles = "Manager")]
        [HttpGet("TeamsByAmount")]
        public IActionResult GetTeamsByHigherAmount(double amount)
        {
            if (amount <= 0)
                return BadRequest("El monto debe ser mayor a cero.");

            try
            {
                var result = _getTeamsByHigherAmount.Execute(amount);

                if (!result.Any())
                    return NoContent();   

                return Ok(result);
            }
            catch (NegativeAmountException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }
    }

}
