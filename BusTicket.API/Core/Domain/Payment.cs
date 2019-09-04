using System;
using System.ComponentModel.DataAnnotations;

namespace BusTicket.API.Core.Domain
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionID { get; set; }
        public string VendorName { get; set; }
        public int TicketResrvID { get; set; }
        public bool Status {get; set;}

        public TicketReservation TicketReservation { get; set; }

    }
}