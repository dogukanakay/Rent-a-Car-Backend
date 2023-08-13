using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalLocationsController : ControllerBase
    {
        IRentalLocationService _rentalLocationService;
        public RentalLocationsController(IRentalLocationService rentalLocationService)
        {
            _rentalLocationService = rentalLocationService;
        }

        [HttpPost("add")]

        public IActionResult Add(RentalLocation rentalLocation)
        {
            var result = _rentalLocationService.Add(rentalLocation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete(RentalLocation rentalLocation)
        {
            var result = _rentalLocationService.Delete(rentalLocation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult Update(RentalLocation rentalLocation)
        {
            var result = _rentalLocationService.Update(rentalLocation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _rentalLocationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetByRentalLocationId(int rentalLocationId)
        {
            var result = _rentalLocationService.GetById(rentalLocationId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
