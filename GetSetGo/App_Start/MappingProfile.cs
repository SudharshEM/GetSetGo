using AutoMapper;
using GetSetGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GetSetGo.Dtos;

namespace GetSetGo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<VehicleDto, Vehicle>();
            CreateMap<VehicleType, VehicleTypeDto>();
            CreateMap<Rental, RentalDto>();
            CreateMap<RentalDto, Rental>();
        }
    }
}