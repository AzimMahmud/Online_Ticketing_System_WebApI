﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Routing;
using BusTicket.API.Core.Repositories;
using BusTicket.WebAPI.Core.Repositories;
using BusTicket.WebAPI.Models;
using BusTicket.WebAPI.Persistence.Repositories;

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
    }
}
