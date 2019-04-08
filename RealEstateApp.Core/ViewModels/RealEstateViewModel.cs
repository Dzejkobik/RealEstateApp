using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateApp.Core.ViewModels
{
    public class RealEstateViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool IsForRent { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFloors { get; set; }
        public string Heating { get; set; }
        public DateTime ConstructionYear { get; set; }
        public int Floor { get; set; }
        public bool IsReadyToMoveIn { get; set; }
    }
}
