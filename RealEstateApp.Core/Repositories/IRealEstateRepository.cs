using RealEstateApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Repositories
{
    public interface IRealEstateRepository
    {
        Task<IEnumerable<RealEstate>> GetRealEstatesWithPaginationAsync(int page, int numberOfRealEstatesPerPage);
        Task AddAsync(RealEstate realEstate);
    }
}
