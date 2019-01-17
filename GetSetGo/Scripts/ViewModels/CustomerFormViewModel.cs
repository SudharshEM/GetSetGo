using GetSetGo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GetSetGo.ViewModels
{
    public class CustomerFormViewModel
    {

        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<Rental> Rentals { get; set; }

        [Key]
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [Min18Years]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Driving Licence")]
        public string DrivingLicence { get; set; }

        public bool HasProvidedPassport { get; set; }

        public Vehicle RentedVehicle { get; set; }

        public int? RentedVehicleId { get; set; }

        public string Title
        {
            get
            {
                return this.Id == 0 ? "New Customer" : "Edit Customer";
            }
        }

        public CustomerFormViewModel()
        {
            this.Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            this.Id = customer.Id;
            this.Name = customer.Name;
            this.DateOfBirth = customer.DateOfBirth;
            this.Phone = customer.Phone;
            this.DrivingLicence = customer.DrivingLicence;
            this.HasProvidedPassport = customer.HasProvidedPassport;
            this.RentedVehicle = customer.RentedVehicle;
            this.RentedVehicleId = customer.RentedVehicleId;
        }
    }
}