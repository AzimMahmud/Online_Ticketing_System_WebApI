using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.API.Core.Domain
{
    public class Route
    {
        public int RouteID { get; set; }
        public string BoardPoint { get; set; }

        [DataType(dataType: DataType.Time)]
        public DateTime BoardTime { get; set; }
        public string DropPoint { get; set; }

        [DataType(dataType: DataType.Time)]
        public DateTime DropTime { get; set; }
        public int BusDetailID { get; set; }

        public decimal Fare { get; set; }

        public BusDetail BusDetails { get; set; }
        public ICollection<TicketReservation> TicketReservations { get; set; }
    }
}