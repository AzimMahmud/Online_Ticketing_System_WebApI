﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BusReservationCancel
    {
        [Key]
        public int BusRsrvCnclID { get; set; }
        public int InvoiceID { get; set; }
        public string Comment { get; set; }
        public string NoOfBus { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}