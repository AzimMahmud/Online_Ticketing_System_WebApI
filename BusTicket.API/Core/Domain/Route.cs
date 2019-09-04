using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.API.Core.Domain
{
    public class RouteDetail
    {
        [Key]
        public int RouteDetailID { get; set; }
        public string BoardPoint { get; set; }

     
        public string BoardTime { get; set; }
        public string DropPoint { get; set; }

     
        public string DropTime { get; set; }
        public int BusDetailID { get; set; }

        public decimal Fare { get; set; }
        public bool IsActive { get; set; }

        public BusDetail BusDetails { get; set; }
        public ICollection<TicketReservation> TicketReservations { get; set; }
    }
}