using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        ICustomerService _customerService;
        public UsersController(IUserService userService, ICustomerService customerService)
        {
            _userService = userService;
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyemail")]
        [Authorize]
        public IActionResult GetByEmail() 
        {
            string userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var result = _userService.GetUserDetailsByEmail(userEmail);
            if (result.Success)
            {
                return Ok(result);
            }
            return Unauthorized(result);
        }

        [HttpPost("updatebyuserdetaildto")]
        [Authorize]
        public IActionResult UpdateByUserDetailDto(UserDetailDto userDetailDto)
        {
            //GEÇİCİ OLARAK EKLENDİ REFACTOR EDİLİP BUSINESS İÇİNE ÇEKİLECEK
            var user = _userService.GetByUserId(userDetailDto.Id).Data;
            user.FirstName = userDetailDto.FirstName;
            user.LastName = userDetailDto.LastName;
            var userResult = _userService.Update(user);

            var customer = _customerService.GetByCustomerId(userDetailDto.CustomerId).Data;
            customer.CompanyName = userDetailDto.CompanyName;
            
            var customerResult = _customerService.Update(customer);
            
            if((userResult.Success && customerResult.Success) || (userResult.Success && userDetailDto.CompanyName==null)) 
            {
                return Ok(userResult);
            }
            return BadRequest(userResult);
            
        }


    }
}
