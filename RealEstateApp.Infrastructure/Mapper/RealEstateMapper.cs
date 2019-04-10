using RealEstateApp.Core.Model;
using RealEstateApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateApp.Infrastructure.Mapper
{
    public static class RealEstateMapper
    {
        public static RealEstateViewModel ToViewModel(RealEstate realEstate)
        {
            var realEstateViewModel = new RealEstateViewModel
            {
                Description = realEstate.Description,
                Category = realEstate.Category,
                ConstructionYear = realEstate.ConstructionYear,
                Floor = realEstate.Floor,
                Heating = realEstate.Heating,
                IsForRent = realEstate.IsForRent,
                IsReadyToMoveIn = realEstate.IsReadyToMoveIn,
                Location = realEstate.Location,
                Name = realEstate.Name,
                NumberOfFloors = realEstate.NumberOfFloors,
                NumberOfRooms = realEstate.NumberOfRooms,
                Price = realEstate.Price
            };
            return realEstateViewModel;
        }

        public static RealEstate ToModel(RealEstateViewModel realEstateViewModel)
        {
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
            return realEstate;
        }
    }
}
