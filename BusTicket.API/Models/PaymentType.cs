﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.API.Models
{
    public class PaymentType
    {
        [Key]
        public int PayTypID { get; set; }
        public string PaymentMethod { get; set; }
    }
}