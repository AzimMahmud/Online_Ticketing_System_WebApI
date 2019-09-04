using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.API.Persistence.Repositories
{
    public class TicketReservationRepository : Repository<TicketReservation>, ITicketReservation
    {
        public TicketReservationRepository(BusTicketContext context) : base(context)
        {

        }
        public BusTicketContext BusTicketContext => Context as BusTicketContext;

        public object GetTotalSales()
        {
            var data = BusTicketContext.TicketReservations.Join(BusTicketContext.Payments, t => t.TicketResrvID, p => p.TicketResrvID, (t, p) => new
            {
                p.PaymentID,
                p.PaymentAmount,
                p.Status
            }).Where(p => p.Status == true).GroupBy(p => p.PaymentAmount).Select(p => new { totalSales = p.Sum(i => i.PaymentAmount) });
            return data;
        }
    }
}
