using GetSetGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetSetGo.ViewModels
{
    public class RentalFormViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<Rental> Rentals { get; set; }
    }
}