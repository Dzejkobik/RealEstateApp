using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateApp.Core.ViewModels
{
    public class RealEstateSearchModel
    {
        public string Name { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public bool IsForRent { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFloors { get; set; }
        public string Heating { get; set; }
        public int Floor { get; set; }
        public bool IsReadyToMoveIn { get; set; }
    }
}
