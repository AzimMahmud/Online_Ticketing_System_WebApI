using BusTicket.WebAPI.Core;
using BusTicket.WebAPI.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BusTicket.WebAPI.Controllers
{
    public class BusDetailController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/BusDetail
        [HttpGet]
        public async Task<IHttpActionResult> GetBusDetails()
        {
            var busDetails = await _unitOfWork.BusDetail.GetAll();
            return Ok(busDetails);
        }

        // GET: api/BusDetail/5
        [HttpGet]
        public async Task<IHttpActionResult> GetBusDetail(int id)
        {
            var busDetail = await _unitOfWork.BusDetail.Get(id);

            if (busDetail == null)
            {
                return NotFound();
            }

            return Ok(busDetail);
        }

        // POST: api/BusDetail
        [HttpPost]
        public async Task<IHttpActionResult> PostBusDetail(BusDetail busDetail)
        {
            if (busDetail == null) return BadRequest();
            _unitOfWork.BusDetail.Add(busDetail);
            await _unitOfWork.Complete();
            return Ok(busDetail);
        }

        // PUT: api/BusDetail/5
        [HttpPut]
        public async Task<IHttpActionResult> PutBusDetail(BusDetail busDetail)
        {
            if (busDetail == null) return BadRequest();
            _unitOfWork.BusDetail.Update(busDetail);
            await _unitOfWork.Complete();
            return Ok(busDetail);
        }

        // DELETE: api/BusDetail/5
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBusDetail(int id)
        {
            var busDetail = await _unitOfWork.BusDetail.Get(id);
            if (busDetail == null) return BadRequest();
            _unitOfWork.BusDetail.Remove(busDetail);
            await _unitOfWork.Complete();
            return Ok(busDetail);
        }
    }
}
