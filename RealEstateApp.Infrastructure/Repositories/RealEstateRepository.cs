using RealEstateApp.Core.Model;
using RealEstateApp.Core.Repositories;
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

        public async Task<IEnumerable<RealEstate>> GetRealEstatesWithPaginationAsync(int page,int numberOfRealEstatesPerPage)
        {
            var numberOfObjectsToSkip = (page - 1) * numberOfRealEstatesPerPage;
            var list = _context.RealEstates.Skip(numberOfObjectsToSkip).Take(numberOfRealEstatesPerPage); ;
            return list;
        }
    }
}
