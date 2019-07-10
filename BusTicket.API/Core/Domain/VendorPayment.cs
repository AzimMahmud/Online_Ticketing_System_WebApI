using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.API.Core.Domain
{
    public class VendorPayment
    {
        [Key]
        public int VendorPaymentID { get; set; }
        public int VendorID { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentDescription { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }

        public Vendor Vendor { get; set; }
    }
}