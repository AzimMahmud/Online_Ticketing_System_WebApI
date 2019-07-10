using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Models;


namespace BusTicket.API.Data
{
    public class BusDetailRepository : IBusDetailsRepository
    {
        private readonly DataContext _dbCtx;
        private IBusDetailsRepository _busDetailsRepository;
        public BusDetailRepository(DataContext dbCtx, IBusDetailsRepository busDetailsRepository)
        {
            this._dbCtx = dbCtx;
            this._busDetailsRepository = busDetailsRepository;
        }

        public async Task<BusDetail> GetBusDetails()
        {
            throw new NotImplementedException();
        }

        public async Task<BusDetail> GetBusDetail(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BusDetail> PostBusDetail(BusDetail busDetail)
        {
            throw new NotImplementedException();
        }

        public async Task<BusDetail> PutBusDetail(int id, BusDetail busDetail)
        {
            throw new NotImplementedException();
        }

        public async Task<BusDetail> DeleteBusDetail(int id)
        {
            throw new NotImplementedException();
        }
    }
}
