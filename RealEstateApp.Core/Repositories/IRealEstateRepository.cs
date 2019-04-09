using RealEstateApp.Core.Model;
using RealEstateApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Repositories
{
    public interface IRealEstateRepository
    {
        Task<IQueryable<RealEstate>> GetRealEstatesByConditionWithPaginationAsync(RealEstateSearchModel realEstateSearchModel, int page, int numberOfRealEstatesPerPage,User user);
        Task AddAsync(RealEstate realEstate);
    }
}
