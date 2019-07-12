using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core;
using BusTicket.API.Core.Repositories;
using BusTicket.API.Persistence.Repositories;
using BusTicket.WebAPI.Persistence.Repositories;



namespace BusTicket.WebAPI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BusTicketContext _context;

        public UnitOfWork(BusTicketContext context)
        {
            _context = context;
            BusDetail = new BusDetailRepository(_context);
            Vendor = new VendorRepository(_context);
            
        }

        public IBusDetails BusDetail { get; set; }
        public IVendor Vendor { get; set; }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
