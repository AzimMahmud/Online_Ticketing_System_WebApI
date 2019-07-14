using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusTicket.API.Core;
using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.Core.Repositories;
using BusTicket.WebAPI.Models;
using BusTicket.WebAPI.Persistence.Repositories;

namespace BusTicket.API.Persistence.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrand
    {
        public BrandRepository(BusTicketContext context) : base(context)
        {
        }
        public BusTicketContext BusTicketContext
        {
            get { return Context as BusTicketContext; }
        }
    }
}
