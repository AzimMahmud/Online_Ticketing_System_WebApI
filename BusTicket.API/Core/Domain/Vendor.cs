using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BusTicket.API.Core.Domain
{
    public class Vendor
    {
        [Key]
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorPhone { get; set; }
        public string VendorEmail { get; set; }
        public string VendorAddress { get; set; }
        public bool IsActive { get; set; }



        public ICollection<BusDetail> BusDetails { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<VendorPayment> VendorPayments { get; set; }
    }
}