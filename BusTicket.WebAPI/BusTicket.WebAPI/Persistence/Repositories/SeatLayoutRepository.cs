using BusTicket.API.Core.Repositories;
using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.Models;
using BusTicket.WebAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.API.Persistence.Repositories
{
    public class SeatLayoutRepository:Repository<SeatLayout>,ISeatLayout
    {
        public SeatLayoutRepository(BusTicketContext context) : base(context)
        {

        }
        public BusTicketContext BusTicketContext
        {
            get { return Context as BusTicketContext; }
        }
    }
}
