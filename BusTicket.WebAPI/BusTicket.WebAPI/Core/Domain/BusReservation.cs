using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.WebAPI.Core.Domain
{
    public class BusReservation
    {
        [Key]
        public int BusReservationID { get; set; }

        [Required]
        public string PassengerName { get; set; }

        [Required]
        public string PassengerPhoneNo { get; set; }

        [Required]
        public string PassengerEmail { get; set; }

        [Required]
        public string Gender { get; set; }
        public string NoOfBus { get; set; }
        public DateTime ReservationDate { get; set; }
        public decimal Total { get; set; }
    }
}