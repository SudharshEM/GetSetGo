using GetSetGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetSetGo.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime RentedDateTime { get; set; }
        public DateTime? ReturnedDateTime { get; set; }
    }
}