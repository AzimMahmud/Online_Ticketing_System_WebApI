using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core.Domain;


namespace BusTicket.API.Core.Repositories
{
    public interface IVendor : IRepository<Vendor>
    {
        object GetTotalVendor();
    }
}
