using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.API.Core.Domain
{
    public class TicketReservation
    {

        [Key]
        public int TicketResrvID { get; set; }
        public string PassengerName { get; set; }
        public string PassengerPhoneNo { get; set; }
        public string PassengerEmail { get; set; }
        public string Gender { get; set; }
        public int NoOfTicket { get; set; }
        public decimal UnitPrice { get; set; }
        public string SeatNo { get; set; }
        public int RouteID { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        public Route Route { get; set; }
    }
}