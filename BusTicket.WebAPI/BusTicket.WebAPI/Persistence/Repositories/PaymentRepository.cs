using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.Core.Repositories;
using BusTicket.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTicket.WebAPI.Persistence.Repositories
{
    public class PaymentRepository:Repository<Payment>,IPayment
    {
        public PaymentRepository(BusTicketContext context): base(context)
        {

        }

    }
}