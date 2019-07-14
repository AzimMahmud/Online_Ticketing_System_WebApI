using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.API.Persistence.Repositories
{
    public class VendorPaymentRepository:Repository<VendorPayment>,IVendorPayment
    {
        public VendorPaymentRepository(BusTicketContext context) : base(context)
        {

        }

        public BusTicketContext BusTicketContext => Context as BusTicketContext;
    }
}
