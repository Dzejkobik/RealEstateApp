using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.ViewModels;
using RealEstateApp.Infrastructure.Database;
using RealEstateApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody]UserViewModel userViewModel)
        {
            var result = await _userService.CreateUserAsync(userViewModel);
            if(result.Succeeded)
            {
                return new OkObjectResult("User created");
            }
            return new BadRequestObjectResult("Failed to create user");
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody]UserViewModel userViewModel)
        {
            var result = await _userService.SingIn(userViewModel);
            if(result.IsSuccessful)
            {
                return Ok(result.Object);
            }
            return BadRequest(result.Message);
        }
    }
}
