using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.Core.Repositories;
using BusTicket.WebAPI.Models;


namespace BusTicket.WebAPI.Persistence.Repositories
{
    public class VendorRepository : Repository<Vendor>, IVendor
    {
        public VendorRepository(BusTicketContext context)
            : base(context)
        {
        }

       
        public BusTicketContext BusTicketContext
        {
            get { return Context as BusTicketContext; }
        }
    }
}
