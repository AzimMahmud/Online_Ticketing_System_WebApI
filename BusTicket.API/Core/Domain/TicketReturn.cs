using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.API.Core.Domain
{
    public class TicketReturn
    {
        [Key]
        public int TicktReturnID { get; set; }
        public int InvoiceID { get; set; }
        public string Comment { get; set; }
        public string NoOfTicket { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}