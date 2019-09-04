using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core.Domain;


namespace BusTicket.API.Core.Repositories
{
    public interface IBusDetails : IRepository<BusDetail>
    {

        Task<IEnumerable<object>> GetBusInfo();
        Task<IEnumerable<object>> GetArchiveBusInfo();
        Task<IEnumerable<object>> GetALLDetailsWithVendorCategoryBrand(int busDetailsid);
        Task<IEnumerable<object>> GetBusDetailWithVendor();
        Task<IEnumerable<object>> GetBusDetailWithCategory();
        Task<IEnumerable<object>> GetBusDetailWithBrand();

    }
}
