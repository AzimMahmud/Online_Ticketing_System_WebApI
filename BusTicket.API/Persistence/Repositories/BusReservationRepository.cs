using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.API.Persistence.Repositories
{
    public class BusReservationRepository:Repository<BusReservation>,IBusReservation
    {
        public BusReservationRepository(BusTicketContext context) : base(context)
        {

        }
        public BusTicketContext BusTicketContext => Context as BusTicketContext;

    }
}
