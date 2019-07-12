using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.API.Core.Domain
{
    public class BusReservation
    {
        [Key]
        public int BusReservationID { get; set; }
        public string PassengerName { get; set; }
        public string PassengerPhoneNo { get; set; }
        public string PassengerEmail { get; set; }
        public string Gender { get; set; }
        public string NoOfBus { get; set; }
        public DateTime ReservationDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}