using RealEstateApp.Core.Model;
using RealEstateApp.Core.Repositories;
using RealEstateApp.Core.ViewModels;
using RealEstateApp.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Infrastructure.Repositories
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private readonly ApplicationDbContext _context;
        public RealEstateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(RealEstate realEstate)
        {
            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<RealEstate>> GetRealEstatesByConditionWithPaginationAsync(RealEstateSearchModel realEstateSearchModel,int page,int numberOfRealEstatesPerPage)
        {
            var list = _context.RealEstates.AsQueryable();
            list = list.Where(x => x.IsForRent == realEstateSearchModel.IsForRent);
            list = list.Where(x => x.IsReadyToMoveIn == realEstateSearchModel.IsReadyToMoveIn);
            if(realEstateSearchModel.Floor != -1)
            {
                list = list.Where(x => x.Floor == realEstateSearchModel.Floor);
            }
            if(realEstateSearchModel.NumberOfFloors != -1)
            {
                list = list.Where(x => x.NumberOfFloors == realEstateSearchModel.NumberOfFloors);
            }
            if(realEstateSearchModel.NumberOfRooms != -1)
            {
                list = list.Where(x => x.NumberOfRooms == realEstateSearchModel.NumberOfRooms);
            }
            if (realEstateSearchModel.PriceFrom != -1)
            {
                list = list.Where(x => x.Price >= realEstateSearchModel.PriceFrom);
            }
            if (realEstateSearchModel.PriceTo != -1)
            {
                list = list.Where(x => x.Price <= realEstateSearchModel.PriceTo);
            }
            if (!string.IsNullOrEmpty(realEstateSearchModel.Heating))
            {
                list = list.Where(x => x.Heating == realEstateSearchModel.Heating);
            }
            if(!string.IsNullOrEmpty(realEstateSearchModel.Location))
            {
                list = list.Where(x => x.Location == realEstateSearchModel.Location);
            }
            if(!string.IsNullOrEmpty(realEstateSearchModel.Name))
            {
                list = list.Where(x => x.Name == realEstateSearchModel.Name);
            }
            if(!string.IsNullOrEmpty(realEstateSearchModel.Category))
            {
                list = list.Where(x => x.Category == realEstateSearchModel.Category);
            }
            var numberOfRealEstatesToSkip = (page - 1) * numberOfRealEstatesPerPage;
            list = list.Skip(numberOfRealEstatesToSkip).Take(numberOfRealEstatesPerPage);
            return list;
        }
    }
}
