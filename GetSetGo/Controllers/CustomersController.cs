using AutoMapper;
using GetSetGo.Models;
using GetSetGo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetSetGo.Controllers
{

    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel();
            
            return View("CustomerForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var viewModel = new CustomerFormViewModel(customer);

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var viewModel = new CustomerFormViewModel(customer);

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(customer);

                return View("CustomerForm",viewModel);
            }

            if(customer.Id == 0)
            {
                customer.DateAdded = DateTime.Now;
                customer.DateUpdated = customer.DateAdded;
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context
                    .Customers
                    .Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.Phone = customer.Phone;
                customerInDb.DrivingLicence = customer.DrivingLicence;
                customerInDb.HasProvidedPassport = customer.HasProvidedPassport;
                customerInDb.DateUpdated = DateTime.Now;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Delete(byte id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}