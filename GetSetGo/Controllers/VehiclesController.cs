using GetSetGo.Models;
using GetSetGo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GetSetGo.Controllers
{
    [Authorize]
    public class VehiclesController : Controller
    {
        ApplicationDbContext _context;

        public VehiclesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            if(User.IsInRole(RoleName.CanManageVehicles))
                return View("List");
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageVehicles)]
        public ActionResult New()
        {
            var vehicleTypes = _context.VehicleTypes.ToList();
            var viewModel = new VehicleFormViewModel
            {
                Vehicle = new Vehicle(),
                VehicleTypes = vehicleTypes
            };

            return View("VehicleForm",viewModel);
        }

        [Authorize(Roles = RoleName.CanManageVehicles)]
        public ActionResult Edit(int id)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == id);
            var vehicleTypes = _context.VehicleTypes.ToList();

            var viewModel = new VehicleFormViewModel
            {
                Vehicle = vehicle,
                VehicleTypes = vehicleTypes
            };

            return View("VehicleForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public ActionResult Save(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                var vehicleTypes = _context.VehicleTypes.ToList();
                var viewModel = new VehicleFormViewModel
                {
                     Vehicle = vehicle,
                     VehicleTypes = vehicleTypes
                };

                return View("VehicleForm", viewModel);
            }

            if(vehicle.Id == 0)
            {
                vehicle.Availability = true;
                vehicle.DateAdded = DateTime.Now;
                vehicle.DateUpdated = vehicle.DateAdded;
                _context.Vehicles.Add(vehicle);
            }
            else
            {
                var vehicleInDb = _context.Vehicles.Single(v => v.Id == vehicle.Id);

                vehicleInDb.Name = vehicle.Name;
                vehicleInDb.VehicleTypeId = vehicle.VehicleTypeId;
                vehicleInDb.PlateNumber = vehicle.PlateNumber;
                vehicleInDb.Color = vehicle.Color;
                vehicleInDb.DateUpdated = DateTime.Now;

            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}