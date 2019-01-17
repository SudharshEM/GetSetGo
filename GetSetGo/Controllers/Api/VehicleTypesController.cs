using AutoMapper;
using GetSetGo.Dtos;
using GetSetGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GetSetGo.Controllers.Api
{
    public class VehicleTypesController : ApiController
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

        [HttpGet]
        public IEnumerable<VehicleTypeDto> GetVehicleTypes()
        {
            return _context.VehicleTypes.ToList().Select(Mapper.Map<VehicleType, VehicleTypeDto>);
        }

        [HttpGet]
        public IHttpActionResult GetVehicleType(int id)
        {
            var vehicleType = _context.VehicleTypes.SingleOrDefault(vt => vt.Id == id);

            return Ok(vehicleType);
        }

        [HttpDelete]
        public void DeleteVehicleTypes(int id)
        {
            var vehicleType = _context.VehicleTypes.SingleOrDefault(vt => vt.Id == id);

            if (vehicleType == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.VehicleTypes.Remove(vehicleType);
            _context.SaveChanges();

        }
    }
}
