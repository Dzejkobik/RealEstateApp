using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateApp.Infrastructure.Jwt
{
    public interface ITokenGenerator
    {
        string GenerateToken(string userName);
    }
}
