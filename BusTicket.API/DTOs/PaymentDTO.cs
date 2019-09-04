using System;

namespace BusTicket.API.DTOs
{
    public class PaymentDTO
    {
        public int PaymentID { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionID { get; set; }
        public string VendorName { get; set; }
        public int TicketResrvID { get; set; }
        public bool Status { get; set; }
    }
}