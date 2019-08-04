using System.Collections.Generic;

namespace BusTicket.API.DTOs
{
    public class SeatAvailabilityDTO
    {
        public int RouteID { get; set; }
        public int AvailableSeat { get; set; }
        public List<string> SeatNo { get; set; }
    }
}