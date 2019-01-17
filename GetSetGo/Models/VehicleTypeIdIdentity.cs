using GetSetGo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GetSetGo.Models
{
    public class VehicleTypeIdIdentity : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var context = new ApplicationDbContext();

            var vehicleType = (VehicleType)validationContext.ObjectInstance;

            var vehicleTypeIdDb = context.VehicleTypes.SingleOrDefault(vt => vt.Id == vehicleType.Id);

            if (vehicleTypeIdDb != null)
            {
                context.Dispose();
                return new ValidationResult("Vehicle type with the id already exist.");
            }

            context.Dispose();

            return ValidationResult.Success;

        }
    }
}