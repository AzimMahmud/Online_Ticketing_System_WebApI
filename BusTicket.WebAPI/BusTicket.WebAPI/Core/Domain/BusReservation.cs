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
        [EmailAddress]
        public string PassengerEmail { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string NoOfBus { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
    }
}