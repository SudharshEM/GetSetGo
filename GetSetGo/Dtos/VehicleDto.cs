using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GetSetGo.Dtos
{
    public class VehicleDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public VehicleTypeDto VehicleType { get; set; }

        public byte VehicleTypeId { get; set; }

        public string PlateNumber { get; set; }

        public string Color { get; set; }

        public bool Availability { get; set; }

    }
}