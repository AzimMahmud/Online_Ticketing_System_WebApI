using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.API.DTOs
{
    public class VendorDTO
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorPhone { get; set; }
        public string VendorEmail { get; set; }
        public string VendorAddress { get; set; }
        public bool IsActive { get; set; }
    }
}
