using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace BusTicket.API.Models
{
    public class SeatLayout
    {
        public SeatLayout(int seatLayoutID, int busDetailsID, int totalSeat, int lastSeat, string layout, string layoutType)
        {
            this.SeatLayoutID = seatLayoutID;
            this.BusDetailsID = busDetailsID;
            this.TotalSeat = totalSeat;
            this.LastSeat = lastSeat;
            this.Layout = layout;
            this.LayoutType = layoutType;

        }
        
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