using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BusTicket.WebAPI.Core.Domain
{
    public class Vendor
    {
        [Key]
        public int VendorID { get; set; }

        [Required]
        public string VendorName { get; set; }

        [Required]
        public string VendorPhone { get; set; }

        [Required]
        [EmailAddress]
        public string VendorEmail { get; set; }

        [Required]
        public string VendorAddress { get; set; }
        public bool IsActive { get; set; }


        public ICollection<BusDetail> BusDetails { get; set; }
        public ICollection<VendorPayment> VendorPayments { get; set; }
    }
}