using Microsoft.AspNetCore.Identity;
using RealEstateApp.Core.Model;
using RealEstateApp.Core.ViewModels;
using RealEstateApp.Infrastructure.Database;
using RealEstateApp.Infrastructure.ServicesResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public UserService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(UserViewModel userViewModel)
        {
            var user = new User();
            user.Email = userViewModel.Email;
            user.UserName = userViewModel.UserName;
            var identityResult = await _userManager.CreateAsync(user, userViewModel.Password);
            return identityResult;
        }

        public bool SingIn()
        {
            throw new NotImplementedException();
        }
    }
}
