using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.WebAPI.Core.Domain
{
    public class TicketReservation
    {

        [Key]
        public int TicketResrvID { get; set; }

        [Required]
        public string TicketNo { get; set; }

        [Required]
        public string PassengerName { get; set; }

        [Required]
        public string PassengerPhoneNo { get; set; }

        [Required]
        [EmailAddress]
        public string PassengerEmail { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int NoOfTicket { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public string SeatNo { get; set; }
        public int RouteDetailID { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        public RouteDetail RouteDetails { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}