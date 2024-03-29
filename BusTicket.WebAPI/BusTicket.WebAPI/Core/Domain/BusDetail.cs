﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BusTicket.WebAPI.Core.Domain
{
    public class BusDetail
    {
        [Key]
        public int BusDetailID { get; set; }
        public int BrandID { get; set; }
        public int BusCategoryID { get; set; }
        public int VendorID { get; set; }
        public bool IsActive { get; set; }

        public Vendor Vendor { get; set; }
        public Brand Brand { get; set; }
        public BusCategory BusCategory { get; set; }

        public virtual ICollection<RouteDetail> RouteDetails { get; set; }
        public virtual ICollection<SeatLayout> SeatLayout { get; set; }

    }
}