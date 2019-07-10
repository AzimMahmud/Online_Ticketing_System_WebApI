using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTicket.API.Models;
using BusTicket.API.Repositories;

namespace BusTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusDetailController : ControllerBase
    {
        private readonly IDataRepository<BusDetail> _repo;

        public BusDetailController(IDataRepository<BusDetail> repository)
        {
            _repo = repository;
        }

        // GET: api/BusDetail
        [HttpGet]
        public async Task<IActionResult> GetBusDetails()
        {
            var users = await _repo.Get();
            return Ok(users);
        }

        // GET: api/BusDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusDetail(int id)
        {
            var busDetail = await _repo.GetByID(id);

            if (busDetail == null)
            {
                return NotFound();
            }

            return Ok(busDetail);
        }

        // PUT: api/BusDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusDetail(int id, BusDetail busDetail)
        {
            return await _repo.Put(id, busDetail);
        }

        // POST: api/BusDetail
        [HttpPost]
        public async Task<IActionResult> PostBusDetail([FromBody] BusDetail busDetail)
        {
           var data = await _repo.Post(busDetail);
    

            return Ok(data);
        }

        // DELETE: api/BusDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusDetail>> DeleteBusDetail(int id)
        {
            var busDetail = await _repo.Delete(id);
            return Ok(busDetail);
        }


    }
}
