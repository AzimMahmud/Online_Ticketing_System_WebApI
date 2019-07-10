using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BusTicket.API.Models;

namespace BusTicket.API.Models
{
    public class BusDetail
    {
        [Key]
        public int BusDetailID { get; set; }
        public int BrandID { get; set; }
        public int BusCategoryID { get; set; }
        public int VendorID { get; set; }

        public Vendor Vendor { get; set; }
        public Brand Brand { get; set; }
        public BusCategory BusCategory { get; set; }

        public ICollection<RouteDetails> RouteDetails { get; set; }
        public ICollection<SeatLayout> SeatLayout { get; set; }

    }
}