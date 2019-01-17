using GetSetGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetSetGo.ViewModels;

namespace GetSetGo.Controllers
{
    [Authorize(Roles = RoleName.CanManageVehicles)]
    public class VehicleTypesController : Controller
    {

        ApplicationDbContext _context;

        public VehicleTypesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {

            return View();
            //return View("VehicleTypeForm",ViewModel(new VehicleType()));
        }

        public ActionResult Edit(int id)
        {
            var vehicleType = _context.VehicleTypes.SingleOrDefault(vt => vt.Id == id);
            return View("VehicleTypeForm", ViewModel(vehicleType));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VehicleTypeFormViewModel
                {
                    VehicleType = vehicleType
                };
                
                return View("VehicleTypeForm",viewModel);
            }

            var vehicleTypeInDb = _context.VehicleTypes.SingleOrDefault(vt => vt.Id == vehicleType.Id);

            if (vehicleTypeInDb == null)
            {
                _context.VehicleTypes.Add(vehicleType);
            }
            else
            {
                vehicleTypeInDb.Name = vehicleType.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        private VehicleTypeFormViewModel ViewModel(VehicleType vehicleType)
        {
            var viewModel = new VehicleTypeFormViewModel
            {
                 VehicleType = vehicleType
            };

            return viewModel;
        }
    }
}