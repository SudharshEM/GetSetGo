using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetSetGo.Models
{
    public class Summary
    {
        ApplicationDbContext _context;

        public Summary()
        {
            _context = new ApplicationDbContext();
        }

        public int TotalRentals
        {
            get { return _context.Rentals.Count(); }
        }

        public int TotalActiveRentals
        {
            get { return _context.Rentals.Where(r => r.ReturnedDateTime == null).Count(); }
        }

        public int TotalCustomers
        {
            get { return _context.Customers.Count(); }
        }

        public int TotalActiveCustomers
        {
            get { return _context.Customers.Where(c => c.RentedVehicleId != null).Count(); }
        }

        public int TotalInactiveCustomers
        {
            get { return _context.Customers.Where(c => c.RentedVehicleId == null).Count(); }
        }

        public int TotalVehicles
        {
            get { return _context.Vehicles.Count(); }
        }

        public int TotalActiveVehicles
        {
            get { return _context.Vehicles.Where(v => v.Availability == false).Count(); }
        }

        public int TotalAvailableVehicles
        {
            get { return _context.Vehicles.Where(v => v.Availability == true).Count(); }
        }
    }
}