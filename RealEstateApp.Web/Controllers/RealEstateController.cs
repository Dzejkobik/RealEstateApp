﻿using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.ViewModels;
using RealEstateApp.Infrastructure.Jwt;
using RealEstateApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IRealEstateService _realEstateService;
        public RealEstateController(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }
        [AuthorizeToken]
        [HttpPost("AddRealEstate")]
        public async Task<IActionResult> Add([FromBody]RealEstateViewModel realEstateViewModel)
        {
            var user = HttpContext.User;
            var userName = user.Identity.Name;
            try
            {
                await _realEstateService.AddAsync(realEstateViewModel,userName);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
            
            return Ok();
        }

        [HttpGet("GetRealEstates")]
        public async Task<IActionResult> GetRealEstatesByConditionWithPaginationAsync([FromBody]RealEstateSearchModel realEstateSearchModel,int page,int numberOfRealEstatesPerPage)
        {
            var list = await _realEstateService.GetRealEstatesWithPaginationAsync(realEstateSearchModel,page, numberOfRealEstatesPerPage,null);
            return Ok(list);
        }

        [AuthorizeToken]
        [HttpGet("GetUserEstates")]
        public async Task<IActionResult> GetCurrentUserRealEstates([FromBody]RealEstateSearchModel realEstateSearchModel,int page,int numberOfRealEstatesPerPage)
        {
            var user = HttpContext.User;
            var userName = user.Identity.Name;
            var list = await _realEstateService.GetRealEstatesWithPaginationAsync(realEstateSearchModel, page, numberOfRealEstatesPerPage,userName);
            return Ok(list);
        }
    }
}
