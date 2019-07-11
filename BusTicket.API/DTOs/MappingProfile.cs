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
        }
    }
}
