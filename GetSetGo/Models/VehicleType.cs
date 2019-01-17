using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GetSetGo.Models
{
    public class VehicleType
    {
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Id should be greater than or equal to 1" )]
        [VehicleTypeIdIdentity]
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        public static readonly byte Bicycle = 1;

    }
}