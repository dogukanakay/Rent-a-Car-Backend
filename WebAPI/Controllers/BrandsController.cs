using Business.Abstract;
using Entities.Requests.Create;
using Entities.Requests.Update;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;   
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CreateBrand createBrand)
        {
            var result = _brandService.Add(createBrand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _brandService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UpdateBrand updateBrand)
        {
            var result = _brandService.Update(updateBrand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




    }
}
