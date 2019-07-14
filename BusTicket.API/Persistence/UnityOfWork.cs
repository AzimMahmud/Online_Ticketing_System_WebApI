using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using BusTicket.API.Persistence.Repositories;


namespace BusTicket.API.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BusTicketContext _context;

        public UnitOfWork(BusTicketContext context)
        {
            _context = context;
            BusDetail = new BusDetailRepository(_context);
            Vendor = new VendorRepository(_context);
            Route = new RouteRepository(_context);
            BusCategory = new BusCategoryRepository(_context);
            Brand = new BrandRepository(_context);
            PaymentType = new PaymentTypeRepository(_context);
            PromoOffer = new PromoOfferRepository(_context);

        }

        public IBusDetails BusDetail { get; set; }
        public IVendor Vendor { get; set; }
        public IRoute Route { get; set; }
        public IBusCategory BusCategory { get; set; }
        public IBrand Brand { get; set; }
        public IPaymentType PaymentType { get; set; }
        public IPromoOffer PromoOffer { get; set; }
 

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
