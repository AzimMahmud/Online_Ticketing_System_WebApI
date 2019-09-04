using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;

namespace BusTicket.API.Persistence.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPayment
    {
        public PaymentRepository(BusTicketContext context) : base(context)
        {

        }

    }
}