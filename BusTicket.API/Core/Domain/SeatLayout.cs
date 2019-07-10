using System.ComponentModel.DataAnnotations;

namespace BusTicket.API.Core.Domain
{
    public class SeatLayout
    { 
        [Key]
        public int SeatLayoutID { get; set; }
        public int BusDetailsID { get; set; }
        public int TotalSeat { get; set; }
        public int LastSeat { get; set; }
        public string Layout { get; set; }
        public string LayoutType { get; set; }

        public BusDetail BusDetail { get; set; }
    }
}