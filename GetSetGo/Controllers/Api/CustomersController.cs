using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using GetSetGo.Dtos;
using GetSetGo.Models;

namespace GetSetGo.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        private CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/Customers
        public IHttpActionResult GetCustomers(string query = null)
        {
           var customersQuery = _context.Customers.Include(v => v.RentedVehicle).ToList();

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.ToLower().Contains(query.ToLower())).ToList();

            var customerDtos = customersQuery.Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        // PUT: api/Customers/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (id != customerInDb.Id)
            {
                return BadRequest();
            }

            Mapper.Map(customerDto, customerInDb);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(customerDto);
        }

        // POST: api/Customers
        [HttpPost]
        [ResponseType(typeof(CustomerDto))]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Count(e => e.Id == id) > 0;
        }
    }
}