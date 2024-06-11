using System;
using System.Collections.Generic;

namespace VehicleLibrary
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleNumber { get; set; }
        public string OwnerName { get; set; }
        public string DriverName { get; set; }
        public long ContactNumber { get; set; }
        
        public long LocationId { get; set; }

        public IEnumerable<LocationModel> Locations { get; set; }       
    }
}
