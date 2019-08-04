using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusTicket.API.Persistence.Repositories
{
    public class RouteRepository : Repository<Route>, IRoute
    {
        public RouteRepository(BusTicketContext context) : base(context)
        {
        }

        public BusTicketContext BusTicketContext
        {
            get { return Context as BusTicketContext; }
        }

        public async Task<object> GetAllRoutesDetails(string boardPoint, string dropPoint, string journeyDate)
        {
            var details = await BusTicketContext.Routes.Join(BusTicketContext.BusDetails, r => r.BusDetailID, b => b.BusDetailID, (Routes, Busdetail) => new
            {
                Routes.RouteID,
                Routes.BoardTime,
                Routes.BoardPoint,
                Routes.DropTime,
                Routes.DropPoint,
                Routes.Fare,
                Brand = Busdetail.Brand.Name,
                Category = Busdetail.BusCategory.Name,
                Busdetail.Vendor.VendorName
            }).Where(r => r.BoardPoint == boardPoint & r.DropPoint == dropPoint).ToListAsync();

            var availableSeat = await BusTicketContext.TicketReservations.Where(tr => tr.ReservationDate == DateTime.Parse(journeyDate)).GroupBy(tr => tr.RouteID)
                                        .Select(c => new
                                        {
                                            RouteID = c.Key,
                                            AvailabaleSeat = 45 - c.Sum(x => x.NoOfTicket),
                                            SeatNumbers = c.Select(s => s.SeatNo),
                                        }).ToListAsync();
            var RouteDetails = new { details, availableSeat };
            return RouteDetails;
        }

    }
}
