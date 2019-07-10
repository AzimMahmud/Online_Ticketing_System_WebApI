using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Models;


namespace BusTicket.API.Data
{
    public interface IBusDetailsRepository
    {
        Task<BusDetail> GetBusDetails();
        Task<BusDetail> GetBusDetail(int id);
        Task<BusDetail> PostBusDetail(BusDetail busDetail);
        Task<BusDetail> PutBusDetail(int id, BusDetail busDetail);
        Task<BusDetail> DeleteBusDetail(int id);
    }
}
