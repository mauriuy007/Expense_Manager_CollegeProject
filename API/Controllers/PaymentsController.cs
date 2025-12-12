using LibreriaLogicaAplicacion.Dtos.Payment;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaNegocio.Exceptions;
using LibreriaLogicaNegocio.RepoInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly ICuAddPaymentAPI<AddPaymentDto> _addPayment;
        private readonly ICuGetById<GetAllPaymentsDto> _getPaymentById;

        public PaymentsController(
            ICuAddPaymentAPI<AddPaymentDto> addPayment,
            ICuGetById<GetAllPaymentsDto> getPaymentById)
        {
            _addPayment = addPayment;
            _getPaymentById = getPaymentById;
        }



        [Authorize] 
        [HttpPost]
        public IActionResult Add(AddPaymentDto dto)
        {
            try
            {
                var id = _addPayment.Execute(dto);
                return CreatedAtAction("GetById", new { id = id }, _getPaymentById.Execute(id));
            }
            catch (InvalidPaymentBillException)
            {
                return StatusCode(400, "not accepted bill");
            }
            catch (InvalidPaymentDatesException)
            {
                return StatusCode(400, "invalid dates");
            }
            catch (NegativeAmountException)
            {
                return StatusCode(400, "invalid amount");
            }
            catch (Exception)
            {
                return StatusCode(500, "unexpected error");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                _getPaymentById.Execute(id);
                return Ok(_getPaymentById.Execute(id));
            }
            catch(Exception)
            {
                return NotFound();
            }
        }
    }

}
