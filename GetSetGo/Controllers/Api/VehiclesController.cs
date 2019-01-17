using GetSetGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using GetSetGo.Dtos;
using AutoMapper;
using System.Data.Entity.Infrastructure;

namespace GetSetGo.Controllers.Api
{
    [Authorize]
    public class VehiclesController : ApiController
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

        // GET: api/vehicles
        public IHttpActionResult GetVehicles(string query = null)
        {

            var vehiclesQuery = _context.Vehicles.Include(v => v.VehicleType);

            if (!String.IsNullOrEmpty(query))
                vehiclesQuery = vehiclesQuery.Where(v => v.Name.ToLower().Contains(query.ToLower()));

            var vehicleDto = vehiclesQuery.ToList().Select(Mapper.Map<Vehicle, VehicleDto>);

            return Ok(vehicleDto);
        }

        // GET: api/customer/1
        [HttpGet]
        public IHttpActionResult GetVehicle(int id)
        {
            var vehicle = _context.Vehicles.Single(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            return Ok(Mapper.Map<Vehicle,VehicleDto>(vehicle));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageVehicles )]
        public IHttpActionResult CreateVehicle(VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = Mapper.Map<VehicleDto, Vehicle>(vehicleDto);

            vehicle.DateAdded = DateTime.Now;
            vehicle.DateUpdated = vehicle.DateAdded;
            
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicle.Id }, vehicle);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public IHttpActionResult UpdateVehicle(int id, VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleInDb = _context.Vehicles.SingleOrDefault(v => v.Id == id);

            if(id != vehicleInDb.Id)
            {
                return BadRequest();
            }

            vehicleInDb.DateUpdated = DateTime.Now;

            Mapper.Map(vehicleDto, vehicleInDb);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(vehicleDto);

        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public IHttpActionResult DeleteVehicle(int id)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == id);

            if (vehicle == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();

            return Ok();

        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Count(v => v.Id == id) > 0;
        }
    }
}
