using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RealEstateApp.Core.Model;
using RealEstateApp.Core.Repositories;
using RealEstateApp.Core.ViewModels;
using RealEstateApp.Infrastructure.Mapper;

namespace RealEstateApp.Infrastructure.Services
{
    public class RealEstateService : IRealEstateService
    {
        private readonly IRealEstateRepository _realEstateRepository;
        private readonly UserManager<User> _userManager;

        public RealEstateService(IRealEstateRepository realEstateRepository,UserManager<User> userManager)
        {
            _realEstateRepository = realEstateRepository;
            _userManager = userManager;
        }
        public async Task AddAsync(RealEstateViewModel realEstateViewModel,string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var realEstate = RealEstateMapper.ToModel(realEstateViewModel);
            realEstate.WhenPublished = DateTime.Now;
            realEstate.User = user;
            await _realEstateRepository.AddAsync(realEstate);
        }

        public async Task<IEnumerable<RealEstateViewModel>> GetRealEstatesWithPaginationAsync(RealEstateSearchModel realEstateSearchModel,int page, int numberOfRealEstatesPerPage,string userName)
        {
            var listOfRealEstateViewModels = new List<RealEstateViewModel>();
            var user = await _userManager.FindByNameAsync(userName);
            var list = await _realEstateRepository.GetRealEstatesByConditionWithPaginationAsync(realEstateSearchModel,page, numberOfRealEstatesPerPage,user);
            foreach(var realEstate in list)
            {
                var realEstateViewModel = RealEstateMapper.ToViewModel(realEstate);
                listOfRealEstateViewModels.Add(realEstateViewModel);
            }
            return listOfRealEstateViewModels;
        }
    }
}
