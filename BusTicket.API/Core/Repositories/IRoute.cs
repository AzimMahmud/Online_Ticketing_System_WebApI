using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core.Domain;

namespace BusTicket.API.Core.Repositories
{
    public interface IRoute : IRepository<RouteDetail>
    {
        Task<object> GetAllRoutesForTicketReservation(string boardPoint, string dropPoint, string journeyDate);

    }
}
