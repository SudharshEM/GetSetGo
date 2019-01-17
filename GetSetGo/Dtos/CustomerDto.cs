using GetSetGo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GetSetGo.Dtos
{
    public class CustomerDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string DrivingLicence { get; set; }

        public bool HasProvidedPassport { get; set; }

        public Vehicle RentedVehicle { get; set; }

        public int? RentedVehicleId { get; set; }

    }
}