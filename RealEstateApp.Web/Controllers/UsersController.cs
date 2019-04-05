using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.ViewModels;
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

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody]UserViewModel userViewModel)
        {
            var result = await _userService.CreateUserAsync(userViewModel);
            if(result.Succeeded)
            {
                return new OkObjectResult("User created");
            }
            return new BadRequestObjectResult("Failed to create user");
        }
    }
}
