using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.API.Models
{
    public class BusCategory
    {
        [Key]
        public int BusCategoryID { get; set; }

        [Required]
        public string Name { get; set; }


        public ICollection<BusDetail> BusDetails { get; set; }
    }
}