using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;

namespace BusTicket.API.Persistence.Repositories
{
    public class PaymentTypeRepository : Repository<PaymentType>, IPaymentType
    {
        public PaymentTypeRepository(BusTicketContext context) : base(context)
        {
        }

        public BusTicketContext BusTicketContext => Context as BusTicketContext;
    }
}
