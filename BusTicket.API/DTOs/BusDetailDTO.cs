using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core.Domain;

namespace BusTicket.API.DTOs
{
    public class BusDetailDTO
    {
        public int BusDetailID { get; set; }
        public int BrandID { get; set; }
        public int BusCategoryID { get; set; }
        public int VendorID { get; set; }
    }
}
