using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.API.DTOs
{
    public class RouteDTO
    {
        public int RouteID { get; set; }
        public string BoardPoint { get; set; }


        public TimeSpan BoardTime { get; set; }
        public string DropPoint { get; set; }


        public TimeSpan DropTime { get; set; }
        public int BusDetailID { get; set; }

        public decimal Fare { get; set; }
    }
}
