using GetSetGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetSetGo.ViewModels
{
    public class VehicleFormViewModel
    {
        public Vehicle Vehicle { get; set; }

        public IEnumerable<VehicleType> VehicleTypes { get; set; }

        public string Title
        {
            get
            {
                return Vehicle.Id == 0 ? "New Vehicle" : "Edit Vehicle";
            }
        }
    }
}