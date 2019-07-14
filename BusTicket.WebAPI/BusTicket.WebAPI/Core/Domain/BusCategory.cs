﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.WebAPI.Core.Domain
{
    public class BusCategory
    {
        [Key]
        public int BusCategoryID { get; set; }
        public string Name { get; set; }


        public ICollection<BusDetail> BusDetails { get; set; }
    }
}