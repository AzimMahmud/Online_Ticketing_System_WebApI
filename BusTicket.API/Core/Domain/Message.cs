using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusTicket.API.Core.Domain
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public int UserID { get; set; }
        public string MessageBody { get; set; }
        public int RecipientID { get; set; }
        public DateTime MessageDeliveryTime { get; set; }
        public DateTime MessageDeliveryDate { get; set; }

        public User User { get; set; }
    }
}