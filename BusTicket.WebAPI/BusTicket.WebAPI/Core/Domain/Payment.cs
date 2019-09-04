using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.WebAPI.Core.Domain
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public decimal PaymentAmount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string TransactionID { get; set; }

        [Required]
        public string VendorName { get; set; }
        public int TicketResrvID { get; set; }

        public TicketReservation TicketReservation { get; set; }
    }
}