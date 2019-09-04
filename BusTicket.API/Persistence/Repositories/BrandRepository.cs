using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusTicket.API.Persistence.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrand
    {
        public BrandRepository(BusTicketContext context) : base(context)
        {
        }
        public BusTicketContext BusTicketContext => Context as BusTicketContext;

       
    }
}
