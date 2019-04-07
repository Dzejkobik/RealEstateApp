using Microsoft.AspNetCore.Identity;
using RealEstateApp.Core.ViewModels;
using RealEstateApp.Infrastructure.ServicesResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Infrastructure.Services
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserViewModel userViewModel);
        Task<ServiceResult<string>> SingIn(UserViewModel userViewModel);
    }
}
