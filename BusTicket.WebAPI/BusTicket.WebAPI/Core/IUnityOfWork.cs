using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core.Repositories;
using BusTicket.WebAPI.Core.Repositories;


namespace BusTicket.WebAPI.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBusDetails BusDetail { get; set; }
        IVendor Vendor { get; set; }
        IRoute Route { get; set; }
        IBusCategory BusCategory { get; set; }
        IBrand Brand { get; set; }
        IPaymentType PaymentType { get; set; }
        IPromoOffer PromoOffer { get; set; }
        IBusReservation BusReservation { get; set; }
        ISeatLayout SeatLayout { get; set; }
        ITicketReservation TicketReservation { get; set; }
        IVendorPayment VendorPayment { get; set; }
        Task<int> Complete();
    }
}
