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
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/Rentals
        public IHttpActionResult GetRentals()
        {
            var rentals = _context.Rentals
                .Include(c => c.Customer)
                .Include(v => v.Vehicle);

            var rentalsDto = rentals.ToList();
            return Ok(rentalsDto);
        }

        // GET: api/Rentals/5
        [ResponseType(typeof(Rental))]
        public IHttpActionResult GetRental(int id)
        {
            var rentals = _context.Rentals
                .Include(c => c.Customer)
                .Include(v => v.Vehicle).ToList().Select(Mapper.Map<Rental,RentalDto>);

            var rental = rentals.SingleOrDefault(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        // PUT: api/Rentals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRental(int id, RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != rentalDto.Id)
            //{
            //    return BadRequest();
            //}

            var rental = _context.Rentals.Single(r => r.Id == id);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == rental.CustomerId);
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == rental.VehicleId);

            rental.ReturnedDateTime = DateTime.Now;
            customer.RentedVehicle = null;
            vehicle.Availability = true;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Rentals
        [ResponseType(typeof(Rental))]
        public IHttpActionResult PostRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);

            if (customer == null)
                return BadRequest("Customer not found.");

            var vehicle = _context.Vehicles.Single(v => v.Id == rentalDto.VehicleId);

            if (vehicle == null)
                return BadRequest("Vehicle not found.");

            if (customer.RentedVehicleId > 0)
                return BadRequest("Customer has already rented a vehicle.");

            if (vehicle.Availability == false)
                return BadRequest("This vehicle is already rented.");

            customer.RentedVehicleId = rentalDto.VehicleId;
            vehicle.Availability = false;

            var rental = Mapper.Map<RentalDto, Rental>(rentalDto);
            rental.RentedDateTime = DateTime.Now;

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rental.Id }, rental);
        }

        // DELETE: api/Rentals/5
        [ResponseType(typeof(Rental))]
        public IHttpActionResult DeleteRental(int id)
        {
            Rental rental = _context.Rentals.Find(id);
            if (rental == null)
            {
                return NotFound();
            }

            _context.Rentals.Remove(rental);
            _context.SaveChanges();

            return Ok(rental);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentalExists(int id)
        {
            return _context.Rentals.Count(e => e.Id == id) > 0;
        }
    }
}