﻿using RealEstateApp.Core.Model;
using RealEstateApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Infrastructure.Services
{
    public interface IRealEstateService
    {
        Task<IEnumerable<RealEstate>> GetRealEstatesWithPaginationAsync(int page, int numberOfRealEstatesPerPage);
        Task AddAsync(RealEstateViewModel realEstateViewModel,string userName);
    }
}