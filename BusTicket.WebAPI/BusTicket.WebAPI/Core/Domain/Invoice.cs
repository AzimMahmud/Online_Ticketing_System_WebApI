using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.WebAPI.Core.Domain
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string BoardPoint { get; set; }

        [Required]
        public DateTime BoardTime { get; set; }

        [Required]
        public string DropPoint { get; set; }

        [Required]
        public DateTime DropTime { get; set; }

        [Required]
        public string BusDetails { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [Required]
        public string NoOfTicket { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public string TransactionType { get; set; }
    }
}