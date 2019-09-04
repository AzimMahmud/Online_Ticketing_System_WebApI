using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using Microsoft.EntityFrameworkCore;

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
                Routes.IsActive,
                Routes.Fare,
                Brand = Busdetail.Brand.Name,
                Category = Busdetail.BusCategory.Name,
                Busdetail.Vendor.VendorName
            }).Where(r => r.BoardPoint == boardPoint && r.DropPoint == dropPoint && r.IsActive == true).ToListAsync();

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






        // public async Task<object> GetAllRoutesDetails(string boardPoint, string dropPoint, string journeyDate)
        // {
        //     object RouteDetails;
        //     var details = await BusTicketContext.Routes.Join(BusTicketContext.BusDetails, r => r.BusDetailID, b => b.BusDetailID, (Routes, Busdetail) => new
        //     {
        //         Routes.RouteID,
        //         Routes.BoardTime,
        //         Routes.BoardPoint,
        //         Routes.DropTime,
        //         Routes.DropPoint,
        //         Routes.Fare,
        //         Brand = Busdetail.Brand.Name,
        //         Category = Busdetail.BusCategory.Name,
        //         Busdetail.Vendor.VendorName
        //     })
        //     .Join(BusTicketContext.TicketReservations, r => r.RouteID, tr => tr.RouteID, (r, tr) => new
        //     {
        //         r.RouteID,
        //         r.BoardTime,
        //         r.BoardPoint,
        //         r.DropTime,
        //         r.DropPoint,
        //         r.Fare,
        //         r.Brand,
        //         r.Category,
        //         r.VendorName,
        //         tr.SeatNo,
        //         tr.NoOfTicket,
        //         tr.ReservationDate
        //     })
        //     .Where(r => r.BoardPoint == boardPoint & r.DropPoint == dropPoint).ToListAsync();

        //     if (details.Where(tr => tr.ReservationDate == DateTime.Parse(journeyDate)) == null)
        //     {
        //         RouteDetails = details;
        //     }
        //     else
        //     {
        //         RouteDetails = details.GroupBy(tr => tr.RouteID)
        //                         .Select(c => new
        //                         {
        //                             routes = c.Select(r => new
        //                             {
        //                                 r.RouteID,
        //                                 r.BoardTime,
        //                                 r.BoardPoint,
        //                                 r.DropTime,
        //                                 r.DropPoint,
        //                                 r.Fare,
        //                                 r.Brand,
        //                                 r.Category,
        //                                 r.VendorName,
        //                                 SeatNumbers = c.Select(s => s.SeatNo),
        //                                 r.NoOfTicket,
        //                                 r.ReservationDate,
        //                                 AvailabaleSeat = 45 - c.Sum(x => x.NoOfTicket)
        //                             }).OrderBy(r => r.RouteID)

        //                         }).Select(r => r.routes.First()).ToArray();
        //     }
        //     // var availableSeat = await BusTicketContext.TicketReservations.Where(tr => tr.ReservationDate == DateTime.Parse(journeyDate)).GroupBy(tr => tr.RouteID)
        //     //                             .Select(c => new
        //     //                             {
        //     //                                 RouteID = c.Key,
        //     //                                 AvailabaleSeat = 45 - c.Sum(x => x.NoOfTicket),
        //     //                                 SeatNumbers = c.Select(s => s.SeatNo),
        //     //                             }).ToListAsync();
        //     // var RouteDetails = new { details, availableSeat };
        //     return RouteDetails;
        // }


    }
}
