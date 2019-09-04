using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.API.DTOs
{
    public class PromoDTO
    {
        public int PromoID { get; set; }
        public string PromoCode { get; set; }
        public string PromoDetails { get; set; }
        public bool IsActive { get; set; }
    }
}
