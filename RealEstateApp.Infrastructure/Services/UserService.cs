using Microsoft.AspNetCore.Identity;
using RealEstateApp.Core.Model;
using RealEstateApp.Core.ViewModels;
using RealEstateApp.Infrastructure.Jwt;
using RealEstateApp.Infrastructure.ServicesResults;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
namespace RealEstateApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ITokenGenerator _tokenGenerator;
        public UserService(SignInManager<User> signInManager, UserManager<User> userManager,ITokenGenerator tokenGenerator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<IdentityResult> CreateUserAsync(UserViewModel userViewModel)
        {
            var user = new User();
            user.Email = userViewModel.Email;
            user.UserName = userViewModel.UserName;
            var identityResult = await _userManager.CreateAsync(user, userViewModel.Password);
            return identityResult;
        }

        public async Task<ServiceResult<string>> SingIn(UserViewModel userViewModel)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(userViewModel.UserName, userViewModel.Password, true, false);
            var result = new ServiceResult<string>();
            if(signInResult.Succeeded)
            {
                var token = _tokenGenerator.GenerateToken(userViewModel.UserName);
                result.Object = token;
                result.IsSuccessful = true;
                return result;
            }
            result.IsSuccessful = false;
            result.Message = "Authentication failed";
            return result;
        }
    }
}
