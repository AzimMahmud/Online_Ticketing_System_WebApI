using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.Core.Repositories;


namespace BusTicket.API.Core.Repositories
{
    public interface IBusDetails : IRepository<BusDetail>
    {

        IEnumerable<BusDetail> GetBusDetailWithVendor();
        IEnumerable<BusDetail> GetBusDetailWithCategory();
        IEnumerable<BusDetail> GetBusDetailWithBrand();

    }
}
