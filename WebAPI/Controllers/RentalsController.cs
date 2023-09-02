using Business.Abstract;
using Entities.Concrete;
using Entities.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(RentalPaymentModel rentalPaymentModel)
        {
            var result = _rentalService.Add(rentalPaymentModel.Rental, rentalPaymentModel.Payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getdetails")]

        public IActionResult GetRentalDetails(RentalDetailFilter rentalDetailFilter) 
        {
            var result = _rentalService.GetRentalDetails(rentalDetailFilter);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        
        }

        [HttpPost("isrentable")]

        public IActionResult IsRentable(Rental rental) 
        {
            if(_rentalService.IsRentable(rental).Success)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
            
        }
    }
}
