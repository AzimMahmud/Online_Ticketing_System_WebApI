using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BusTicket.API.Models;

namespace WebApplication1.Models
{
    public class BusDetail
    {
        public BusDetail(int busDetailID, int brandID, int busCategoryID, int vendorID, Vendor vendor, Brand brand, BusCategory busCategory)
        {
            this.BusDetailID = busDetailID;
            this.BrandID = brandID;
            this.BusCategoryID = busCategoryID;
            this.VendorID = vendorID;
            this.Vendor = vendor;
            this.Brand = brand;
            this.BusCategory = busCategory;
        }

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