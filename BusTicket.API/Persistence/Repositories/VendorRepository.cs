using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BusTicket.API.Persistence.Repositories
{
    public class VendorRepository : Repository<Vendor>, IVendor
    {
        public VendorRepository(BusTicketContext context)
            : base(context)
        {
        }
        public BusTicketContext BusTicketContext => Context as BusTicketContext;
    }
}
