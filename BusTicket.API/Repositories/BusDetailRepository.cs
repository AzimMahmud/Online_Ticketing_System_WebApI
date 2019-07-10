using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Data;
using BusTicket.API.Models;
using BusTicket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BusTicket.API.Repositories
{
    public class BusDetailRepository : IDataRepository<BusDetail>
    {
        private readonly DataContext _dbCtx;

        public BusDetailRepository(DataContext dbCtx)
        {
            this._dbCtx = dbCtx;
           
        }

        public async Task<IEnumerable<BusDetail>> Get()
        {
            return await _dbCtx.BusDetails
                //.Include(b => b.Vendor)
                //.Include(b => b.BusCategory)
                //.Include(b => b.Brand)
                .ToListAsync();

        }

        public async Task<BusDetail> GetByID(int id)
        {
            return await _dbCtx.BusDetails.FindAsync(id);     
        }

        public async Task<BusDetail> Post(BusDetail entity)
        {
           await _dbCtx.BusDetails.AddAsync(entity);
           return entity;
        }

        public async Task<IActionResult> Put(int id, BusDetail busDetail)
        {
            if (id != busDetail.BusDetailID)
            {
                return new BadRequestResult();
            }

            _dbCtx.Entry(busDetail).State = EntityState.Modified;

            try
            {
                await _dbCtx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusDetailExists(id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }

            return new NoContentResult();
        }

        public async Task<ActionResult<BusDetail>> Delete(int id)
        {
            var busDetail = await _dbCtx.BusDetails.FindAsync(id);
            if (busDetail == null)
            {
                return new BadRequestResult();
            }

            _dbCtx.BusDetails.Remove(busDetail);
            await _dbCtx.SaveChangesAsync();

            return busDetail;
        }

        private bool BusDetailExists(int id)
        {
            return _dbCtx.BusDetails.Any(e => e.BusDetailID == id);
        }
    }
}
