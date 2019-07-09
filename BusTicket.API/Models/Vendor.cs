using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Vendor
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorPhone { get; set; }
        public string VendorEmail { get; set; }
        public string VendorAddress { get; set; }



        public ICollection<BusDetail> BusDetails { get; set; }
        public ICollection<VendorPayment> VendorPayments { get; set; }
    }
}