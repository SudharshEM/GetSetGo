using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GetSetGo.Models
{
    public class PlateNumberRequired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var vehicle = (Vehicle)validationContext.ObjectInstance;

            if (vehicle.VehicleTypeId == VehicleType.Bicycle)
                return ValidationResult.Success;

            if (!String.IsNullOrWhiteSpace(vehicle.PlateNumber))
                return ValidationResult.Success;

            return new ValidationResult("Plate number is required.");

        }
    }
}