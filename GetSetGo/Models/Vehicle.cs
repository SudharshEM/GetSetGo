using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GetSetGo.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public VehicleType VehicleType { get; set; }

        [Display(Name = "Vehicle Type")]
        public byte VehicleTypeId { get; set; }

        [Display(Name = "Plate Number")]
        [PlateNumberRequired]
        public string PlateNumber { get; set; }

        public string Color { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool Availability { get; set; }

    }
}