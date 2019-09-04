using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.WebAPI.Core.Domain
{
    public class BusReservationCancel
    {
        [Key]
        public int BusRsrvCnclID { get; set; }
        public int InvoiceID { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public string NoOfBus { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}