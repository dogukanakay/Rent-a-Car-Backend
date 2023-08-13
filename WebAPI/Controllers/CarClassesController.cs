using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarClassesController : ControllerBase
    {
        ICarClassService _carClassService;
        public CarClassesController(ICarClassService carClassService)
        {
            _carClassService = carClassService;
        }


        [HttpPost("add")]

        public IActionResult Add(CarClass carClass)
        {
            var result = _carClassService.Add(carClass);

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult Update(CarClass carClass)
        {
            var result = _carClassService.Update(carClass);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete(CarClass carClass)
        {
            var result = _carClassService.Delete(carClass);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getall")]

        public IActionResult GetAll() 
        {
            var result = _carClassService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int carClassId)
        {
            var result = _carClassService.GetById(carClassId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
