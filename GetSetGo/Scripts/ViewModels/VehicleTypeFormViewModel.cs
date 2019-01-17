using GetSetGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetSetGo.ViewModels
{
    public class VehicleTypeFormViewModel
    {
        public VehicleType VehicleType { get; set; }

        public string Title { get { return VehicleType.Id == 0 ? "New" : "Edit"; } }

    }
}