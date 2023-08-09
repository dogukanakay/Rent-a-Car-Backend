using Business.Abstract;
using Entites.Concrete;
using Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        IUserService _userService;
        public CarsController(ICarService carService,IUserService userService)
        {
            _carService = carService;
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        
        [HttpPost("add")]

        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]

        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



       

        [HttpGet("getcardetailsbycarid")]

        public IActionResult GetByCarId(int carId)
        {
            var result = _carService.GetCarDetailsByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getcardetails")]

        public IActionResult GetCarDetails(CarDetailFilter carDetailFilter)
        {
            var result = _carService.GetCarDetails(carDetailFilter);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       

        [HttpGet("getcarbycarid")]

        public IActionResult GetCarByCarId(int carId)
        {
            var result = _carService.GetByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
