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
    [Route("api/[controller]")]
    public class SeatLayoutController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeatLayoutController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/SeatLayout
        [HttpGet]
        public async Task<IHttpActionResult> GetSeatLayouts()
        {
            var seatLayouts = await _unitOfWork.SeatLayout.GetAll();
            return Ok(seatLayouts);

        }

        // GET: api/SeatLayout/5
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetSeatLayout(int id)
        {
            var seatLayout = await _unitOfWork.SeatLayout.Get(id);

            if (seatLayout == null)
            {
                return NotFound();
            }

            return Ok(seatLayout);
        }


        // POST: api/SeatLayout
        [HttpPost]
        public async Task<IHttpActionResult> PostSeatLayout(SeatLayout seatLayout)
        {
            if (seatLayout == null) return BadRequest();
            _unitOfWork.SeatLayout.Add(seatLayout);
            await _unitOfWork.Complete();
            return Ok(seatLayout);
        }



        // PUT: api/SeatLayout/5
        [HttpPut]
        public async Task<IHttpActionResult> PutSeatLayout(SeatLayout seatLayout)
        {
            if (seatLayout == null) return BadRequest();
            _unitOfWork.SeatLayout.Update(seatLayout);
            await _unitOfWork.Complete();
            return Ok(seatLayout);
        }

        // DELETE: api/SeatLayout/5
        [HttpDelete,Route("{id}")]
        public async Task<IHttpActionResult> DeleteSeatLayout(int id)
        {
            var seatLayout = await _unitOfWork.SeatLayout.Get(id);
            if (seatLayout == null) return BadRequest();
            _unitOfWork.SeatLayout.Remove(seatLayout);
            await _unitOfWork.Complete();
            return Ok(seatLayout);
        }
    }
}
