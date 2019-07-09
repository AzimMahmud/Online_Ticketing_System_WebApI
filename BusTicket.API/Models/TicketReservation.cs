using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TicketReservation
    {
        public TicketReservation(int ticketResrvID, string passengerName, string passengerPhoneNo, string passengerEmail, string gender, string noOfTicket, decimal unitPrice, string seatNo, int routeDetailsID, DateTime reservationDate, RouteDetails routeDetails)
        {
            this.TicketResrvID = ticketResrvID;
            this.PassengerName = passengerName;
            this.PassengerPhoneNo = passengerPhoneNo;
            this.PassengerEmail = passengerEmail;
            this.Gender = gender;
            this.NoOfTicket = noOfTicket;
            this.UnitPrice = unitPrice;
            this.SeatNo = seatNo;
            this.RouteDetailsID = routeDetailsID;
            this.ReservationDate = reservationDate;
            this.RouteDetails = routeDetails;
        }

        [Key]
        public int TicketResrvID { get; set; }
        public string PassengerName { get; set; }
        public string PassengerPhoneNo { get; set; }
        public string PassengerEmail { get; set; }
        public string Gender { get; set; }
        public string NoOfTicket { get; set; }
        public decimal UnitPrice { get; set; }
        public string SeatNo { get; set; }
        public int RouteDetailsID { get; set; }
        public DateTime ReservationDate { get; set; }

        public RouteDetails RouteDetails { get; set; }
    }
}