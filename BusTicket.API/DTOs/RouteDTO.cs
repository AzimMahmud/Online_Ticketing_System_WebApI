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


        public string BoardTime { get; set; }
        public string DropPoint { get; set; }


        public string DropTime { get; set; }
        public int BusDetailID { get; set; }

        public decimal Fare { get; set; }
        public bool IsActive { get; set; }
    }
}
