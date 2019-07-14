using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusTicket.API.Persistence.Repositories
{
    public class PromoOfferRepository : Repository<PromoOffer>, IPromoOffer
    {
        public PromoOfferRepository(BusTicketContext context) : base(context)
        {
        }

        public BusTicketContext BusTicketContext { get => Context as BusTicketContext; } 
    }
}
