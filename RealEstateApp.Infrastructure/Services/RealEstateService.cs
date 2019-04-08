using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RealEstateApp.Core.Model;
using RealEstateApp.Core.Repositories;
using RealEstateApp.Core.ViewModels;

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
            var realEstate = new RealEstate
            {
                Category = realEstateViewModel.Category,
                ConstructionYear = realEstateViewModel.ConstructionYear,
                Description = realEstateViewModel.Description,
                Floor = realEstateViewModel.Floor,
                Heating = realEstateViewModel.Heating,
                IsForRent = realEstateViewModel.IsForRent,
                IsReadyToMoveIn = realEstateViewModel.IsReadyToMoveIn,
                Location = realEstateViewModel.Location,
                Name = realEstateViewModel.Name,
                NumberOfFloors = realEstateViewModel.NumberOfFloors,
                NumberOfRooms = realEstateViewModel.NumberOfRooms,
                Price = realEstateViewModel.Price
            };
            realEstate.WhenPublished = DateTime.Now;
            realEstate.User = user;
            await _realEstateRepository.AddAsync(realEstate);
        }

        public async Task<IEnumerable<RealEstate>> GetRealEstatesWithPaginationAsync(int page, int numberOfRealEstatesPerPage)
        {
            var list = await _realEstateRepository.GetRealEstatesWithPaginationAsync(page, numberOfRealEstatesPerPage);
            return list;
        }
    }
}
