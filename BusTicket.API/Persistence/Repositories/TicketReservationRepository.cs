using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.API.Persistence.Repositories
{
    public class TicketReservationRepository:Repository<TicketReservation>,ITicketReservation
    {
        public TicketReservationRepository(BusTicketContext context) : base(context)
        {

        }
        public BusTicketContext BusTicketContext => Context as BusTicketContext;
    }
}
