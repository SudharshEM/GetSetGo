using GetSetGo.Models;
using GetSetGo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetSetGo.Controllers
{
    public class RentalsController : Controller
    {
        ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {

            var rentals = _context.Rentals.ToList();
            var customers = _context.Customers.ToList();
            var vehicles = _context.Vehicles.ToList();
            
            var viewModel = new RentalFormViewModel
            {
                Rentals = rentals,
                Customers = customers,
                Vehicles = vehicles
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new RentalFormViewModel
            {
                Vehicles = _context.Vehicles.ToList()
            };

            return View(viewModel);
        }
    }
}