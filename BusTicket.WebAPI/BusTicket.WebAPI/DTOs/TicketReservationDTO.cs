using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTicket.WebAPI.DTOs
{
    public class TicketReservationDTO
    {
        public int TicketResrvID { get; set; }
        public string TicketNo { get; set; }
        public string PassengerName { get; set; }
        public string PassengerPhoneNo { get; set; }
        public string PassengerEmail { get; set; }
        public string Gender { get; set; }
        public int NoOfTicket { get; set; }
        public decimal UnitPrice { get; set; }
        public string SeatNo { get; set; }
        public DateTime ReservationDate { get; set; }
        public int RouteDetailID { get; set; }


        public int PaymentID { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionID { get; set; }
        public string VendorName { get; set; }
    }
}