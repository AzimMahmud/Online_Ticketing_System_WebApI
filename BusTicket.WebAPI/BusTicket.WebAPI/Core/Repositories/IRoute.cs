using BusTicket.WebAPI.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Routing;

namespace BusTicket.WebAPI.Core.Repositories
{
    public interface IRoute : IRepository<RouteDetail>
    {
        Task<object> GetAllRoutesForTicketReservation(string boardPoint, string dropPoint, string journeyDate);
    }
}
