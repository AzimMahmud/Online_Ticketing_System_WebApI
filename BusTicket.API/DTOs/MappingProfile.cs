using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusTicket.API.Core.Domain;
using BusTicket.API.Helper;

namespace BusTicket.API.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();

            CreateMap<User, UserForRegisterDto>();
           

            CreateMap<BusDetail, BusDetailDTO>();
            CreateMap<BusDetailDTO, BusDetail>();

            CreateMap<BusCategory, BusCategoryDTO>();
            CreateMap<BusCategoryDTO, BusCategory>();

            CreateMap<Vendor, VendorDTO>();
            CreateMap<VendorDTO, Vendor>();

            CreateMap<RouteDetail, RouteDTO>();
            CreateMap<RouteDTO, RouteDetail>();

            CreateMap<Brand, BrandDTO>();
            CreateMap<BrandDTO, Brand>();

            CreateMap<Payment, PaymentDTO>();
            CreateMap<PaymentDTO, Payment>();



        }
    }
}
