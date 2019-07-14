using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.Core.Repositories;
using BusTicket.WebAPI.Models;
using BusTicket.WebAPI.Persistence.Repositories;

namespace BusTicket.API.Persistence.Repositories
{
    public class PaymentTypeRepository : Repository<PaymentType>, IPaymentType
    {
        public PaymentTypeRepository(BusTicketContext context) : base(context)
        {
        }

        public BusTicketContext BusTicketContext
        {
            get { return Context as BusTicketContext; }
        }
    }
}
