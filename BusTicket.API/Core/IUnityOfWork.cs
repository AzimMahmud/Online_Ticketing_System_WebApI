using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core.Repositories;


namespace BusTicket.API.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBusDetails BusDetail { get; set; }
        IVendor Vendor { get; set; }
        int Complete();
    }
}
