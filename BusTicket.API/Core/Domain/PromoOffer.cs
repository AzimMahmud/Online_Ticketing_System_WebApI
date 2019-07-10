using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BusTicket.API.Core.Domain
{
    public class PromoOffer
    {
        [Key]
        public int PromoID { get; set; }
        public string PromoCode { get; set; }
        public string PromoDetails { get; set; }
    }
}