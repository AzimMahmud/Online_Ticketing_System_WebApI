using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using BusTicket.API.Core.Repositories;


using BusTicket.API.Persistence;
using BusTicket.API.Persistence.Repositories;
using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.Persistence;
using BusTicket.WebAPI.Persistence.Repositories;


namespace BusTicket.API.Persistence.Repositories
{
    public class BusDetailRepository : Repository<BusDetail>, IBusDetails
    {
        
        public BusDetailRepository(BusTicketContext context)
            : base(context)
        {
        }

        public IEnumerable<BusDetail> GetBusDetailWithVendor()
        {
            return BusTicketContext.BusDetails.Include(b => b.Vendor).ToList();
        }

 
        public IEnumerable<BusDetail> GetBusDetailWithBrand()
        {
            return BusTicketContext.BusDetails
                .Include(b => b.Brand)
                .ToList();
        }

        public IEnumerable<BusDetail> GetBusDetailWithCategory()
        {
            return BusTicketContext.BusDetails
                .Include(b => b.BusCategory)
                .ToList();
        }

        public BusTicketContext  BusTicketContext 
        {
            get { return Context as BusTicketContext; }
        }
    }
}
