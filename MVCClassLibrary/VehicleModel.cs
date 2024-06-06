using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_MVC.Models
{

    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleNumber { get; set; }
        public string OwnerName { get; set; }
        public string DriverName { get; set; }
        public long ContactNumber { get; set; }
        public string Location { get; set; }

    }
}
