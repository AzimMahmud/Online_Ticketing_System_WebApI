using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.WebAPI.Core.Domain
{
    public class VendorPayment
    {
        [Key]
        public int VendorPaymentID { get; set; }
        public int VendorID { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public string PaymentDescription { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        public Vendor Vendor { get; set; }
    }
}