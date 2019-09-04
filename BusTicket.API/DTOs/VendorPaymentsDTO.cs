using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.API.DTOs
{
    public class VendorPaymentsDTO
    {
        public int VendorPaymentID { get; set; }
        public int VendorID { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentDescription { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }

        public bool IsActive { get; set; }
    }
}
