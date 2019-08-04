using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusTicket.API.Core.Domain;

namespace BusTicket.API.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BusDetail, BusDetailDTO>();
            CreateMap<BusDetailDTO, BusDetail>();

            CreateMap<BusCategory, BusCategoryDTO>();
            CreateMap<BusCategoryDTO, BusCategory>();

            CreateMap<Vendor, VendorDTO>();
            CreateMap<VendorDTO, Vendor>();

            CreateMap<Route, RouteDTO>();
            CreateMap<RouteDTO, Route>();

            CreateMap<Brand, BrandDTO>();
            CreateMap<BrandDTO, Brand>();





        }
    }
}
