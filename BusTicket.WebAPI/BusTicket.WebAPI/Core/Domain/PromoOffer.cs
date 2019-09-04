using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BusTicket.WebAPI.Core.Domain
{
    public class PromoOffer
    {
        [Key]
        public int PromoID { get; set; }

        [Required]
        public string PromoCode { get; set; }

        [Required]
        public string PromoDetails { get; set; }

        public bool IsActive { get; set; }
    }
}