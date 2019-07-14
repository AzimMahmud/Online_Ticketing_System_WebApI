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
        public static void Initialize()
        {

            Mapper.Initialize((config) =>
            {
                config.CreateMap<BusCategory, BusCategoryDTO>().ReverseMap();
                config.CreateMap<BusCategoryDTO, BusCategory>().ReverseMap();
            });

            //CreateMap<BusDetail, BusDetailDTO>();
            //CreateMap<BusDetailDTO, BusDetail>();

            //CreateMap<BusCategory, BusCategoryDTO>();
            //CreateMap<BusCategoryDTO, BusCategory>();

            //CreateMap<Vendor, VendorDTO>();
            //CreateMap<VendorDTO, Vendor>();

            //CreateMap<Route, RouteDTO>();
            //CreateMap<RouteDTO, Route>();





            //CreateMap<User, UserForListDto>();
            //CreateMap<UserForListDto, User>();

            //CreateMap<User, UserForDetailedDto>();
            //CreateMap<UserForDetailedDto, User>();

            //CreateMap<User, UserForLoginDto>();
            //CreateMap<UserForLoginDto, User>();

            //CreateMap<User, UserForRegisterDto>();
            //CreateMap<UserForRegisterDto, User>();

        }
    }
}
