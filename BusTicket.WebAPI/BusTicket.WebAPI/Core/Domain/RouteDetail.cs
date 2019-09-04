using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.WebAPI.Core.Domain
{
    public class RouteDetail
    {
        [Key]
        public int RouteDetailID { get; set; }

        [Required]
        public string BoardPoint { get; set; }

        [Required]
        public string BoardTime { get; set; }

        [Required]
        public string DropPoint { get; set; }

        [Required]
        public string DropTime { get; set; }
        public int BusDetailID { get; set; }

        [Required]
        public decimal Fare { get; set; }

        public bool IsActive { get; set; }

        public BusDetail BusDetails { get; set; }
        public ICollection<TicketReservation> TicketReservations { get; set; }
    }
}