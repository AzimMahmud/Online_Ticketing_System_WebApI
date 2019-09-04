using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Routing;
using BusTicket.API.Core.Repositories;
using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.Core.Repositories;
using BusTicket.WebAPI.Models;
using BusTicket.WebAPI.Persistence.Repositories;

namespace BusTicket.API.Persistence.Repositories
{
    public class RouteRepository : Repository<RouteDetail>, IRoute
    {
        public RouteRepository(BusTicketContext context) : base(context)
        {
        }

        public BusTicketContext BusTicketContext
        {
            get { return Context as BusTicketContext; }
        }

        public async Task<object> GetAllRoutesForTicketReservation(string boardPoint, string dropPoint, string journeyDate)
        {
            var details = await BusTicketContext.RouteDetails.Join(BusTicketContext.BusDetails, r => r.BusDetailID, b => b.BusDetailID, (Routes, Busdetail) => new
            {
                Routes.RouteDetailID,
                Routes.BoardTime,
                Routes.BoardPoint,
                Routes.DropTime,
                Routes.DropPoint,
                Routes.Fare,
                Brand = Busdetail.Brand.Name,
                Category = Busdetail.BusCategory.Name,
                Busdetail.Vendor.VendorName
            }).Where(r => r.BoardPoint == boardPoint & r.DropPoint == dropPoint).ToListAsync();

            var availableSeat = await BusTicketContext.TicketReservations.Where(tr => tr.ReservationDate == DateTime.Parse(journeyDate)).GroupBy(tr => tr.RouteDetailID)
                                        .Select(c => new
                                        {
                                            RouteDetailID = c.Key,
                                            AvailabaleSeat = 45 - c.Sum(x => x.NoOfTicket),
                                            SeatNumbers = string.Join(",", c.Select(s => s.SeatNo).ToArray()),
                                        }).ToListAsync();

            var RouteDetails = new { details, availableSeat };
            return RouteDetails;
        }
    }
}
