using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentCardsController : ControllerBase
    {
        IPaymentCardService _paymentCardService;
        public PaymentCardsController(IPaymentCardService paymentCardService)
        {
            _paymentCardService = paymentCardService;
        }

        [HttpPost("add")]

        public IActionResult Add(PaymentCard paymentCard)
        {
            var result = _paymentCardService.Add(paymentCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete(PaymentCard paymentCard)
        {
            var result = _paymentCardService.Delete(paymentCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult Update(PaymentCard paymentCard)
        {
            var result = _paymentCardService.Update(paymentCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _paymentCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetByPaymentCardId(int paymentCardId)
        {
            var result = _paymentCardService.GetById(paymentCardId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]

        public IActionResult GetByCustomerId(int customerId) 
        {
            var result = _paymentCardService.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
