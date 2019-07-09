using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Gender { get; set; }
        public string BoardPoint { get; set; }
        public DateTime BoardTime { get; set; }
        public string DropPoint { get; set; }
        public DateTime DropTime { get; set; }
        public string BusDetails { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime ReservationDate { get; set; }
        public string NoOfTicket { get; set; }
        public decimal UnitPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionType { get; set; }
    }
}