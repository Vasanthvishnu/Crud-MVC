using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleLibrary
{
    public class VehicleModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name="UserName")]
        public string Name { get; set; }
        [Required]
        public string VehicleNumber { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string DriverName { get; set; }
        [Required]
        [Display (Name= "phone Number")]
        [Range(1,9999999999,ErrorMessage ="please enter correct number")]
        public long ContactNumber { get; set; }
        [Required]
        
        public long LocationId { get; set; }

        public IEnumerable<LocationModel> Locations { get; set; }       
    }
}
