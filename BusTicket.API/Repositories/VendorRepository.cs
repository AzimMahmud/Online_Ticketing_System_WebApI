using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusTicket.API.Repositories
{
    public class VendorRepository : IDataRepository<Vendor>
    {
        public Task<IEnumerable<Vendor>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Vendor> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Vendor> Post(Vendor entity)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Put(int id, Vendor entity)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Vendor>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
