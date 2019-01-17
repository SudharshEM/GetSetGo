using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GetSetGo.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; }

        public int VehicleId { get; set; }

        public DateTime RentedDateTime { get; set; }

        public DateTime? ReturnedDateTime { get; set; }
    }
}