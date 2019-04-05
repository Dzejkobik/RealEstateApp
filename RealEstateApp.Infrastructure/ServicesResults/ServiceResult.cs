using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateApp.Infrastructure.ServicesResults
{
    public class ServiceResult<T>
    {
        public T Object { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
