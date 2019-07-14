using BusTicket.API.Core.Repositories;
using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.Core.Repositories;
using BusTicket.WebAPI.Models;
using BusTicket.WebAPI.Persistence.Repositories;
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
        public BusTicketContext BusTicketContext
        {
            get { return Context as BusTicketContext; }
        }

    }
}
