using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTicket.WebAPI.Core.Domain
{
    public class RouteDetails
    {
        public int RouteDetailsID { get; set; }
        public string BoardPoint { get; set; }
        public DateTime BoardTime { get; set; }
        public string DropPoint { get; set; }
        public DateTime DropTime { get; set; }
        public int BusDetailsID { get; set; }

        public decimal Fare { get; set; }

        public BusDetail BusDetails { get; set; }
        public ICollection<TicketReservation> TicketReservations { get; set; }
    }
}