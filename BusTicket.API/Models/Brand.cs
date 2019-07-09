﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }

        [Required]
        public string Name { get; set; }


        public ICollection<BusDetail> BusDetails { get; set; }
    }
}