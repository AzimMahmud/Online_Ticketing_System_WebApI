using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TicketReturn
    {
        public int TicktReturnID { get; set; }
        public int InvoiceID { get; set; }
        public string Comment { get; set; }
        public string NoOfTicket { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}