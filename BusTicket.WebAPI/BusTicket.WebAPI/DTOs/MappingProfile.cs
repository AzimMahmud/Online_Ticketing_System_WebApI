using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Routing;
using AutoMapper;
using BusTicket.API.DTOs;
using BusTicket.WebAPI.Core.Domain;

namespace BusTicket.WebAPI.DTOs
{
    public static class MappingProfile 
    {
        public static IMapper Initialize()
        {

            var configuration = new MapperConfiguration((config) =>
            {
              

                config.CreateMap<BusDetail, BusDetailDTO>();
                config.CreateMap<BusDetailDTO, BusDetail>();

                config.CreateMap<BusCategory, BusCategoryDTO>();
                config.CreateMap<BusCategoryDTO, BusCategory>();

                config.CreateMap<Vendor, VendorDTO>();
                config.CreateMap<VendorDTO, Vendor>();

                //config.CreateMap<Route, RouteDTO>();
                //config.CreateMap<RouteDTO, Route>();

                config.CreateMap<User, UserForListDto>();
                config.CreateMap<UserForListDto, User>();

                config.CreateMap<User, UserForDetailedDto>();
                config.CreateMap<UserForDetailedDto, User>();

                config.CreateMap<User, UserForLoginDto>();
                config.CreateMap<UserForLoginDto, User>();

                config.CreateMap<User, UserForRegisterDto>();
                config.CreateMap<UserForRegisterDto, User>();

                config.CreateMap<Payment, PaymentDTO>();
                config.CreateMap<PaymentDTO, Payment>();
            });



            var mapper = configuration.CreateMapper();



            return mapper;

        }
    }
}
