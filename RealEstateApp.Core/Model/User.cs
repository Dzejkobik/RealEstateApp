using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RealEstateApp.Core.Model
{
    public class User : IdentityUser
    {
        public ICollection<RealEstate> RealEstates {get;set;}
    }
}
