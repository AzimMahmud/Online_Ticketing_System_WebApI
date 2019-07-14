using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusTicket.API.Core.Domain;
using BusTicket.API.Persistence;
using BusTicket.API.Core;

namespace BusTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatLayoutController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeatLayoutController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/SeatLayout
        [HttpGet]
        public async Task<ActionResult> GetSeatLayouts()
        {
            var seatLayouts = await _unitOfWork.SeatLayout.GetAll();
            return Ok(seatLayouts);
        }

        // GET: api/SeatLayout/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSeatLayout(int id)
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
        public async Task<ActionResult> PostSeatLayout(SeatLayout seatLayout)
        {
            if (seatLayout == null) return BadRequest();
            _unitOfWork.SeatLayout.Add(seatLayout);
            await _unitOfWork.Complete();
            return Ok(seatLayout);
        }



        // PUT: api/SeatLayout/5
        [HttpPut]
        public async Task<IActionResult> PutSeatLayout(SeatLayout seatLayout)
        {
            if (seatLayout == null) return BadRequest();
            _unitOfWork.SeatLayout.Update(seatLayout);
            await _unitOfWork.Complete();
            return Ok(seatLayout);
        }

        // DELETE: api/SeatLayout/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SeatLayout>> DeleteSeatLayout(int id)
        {
            var seatLayout = await _unitOfWork.SeatLayout.Get(id);
            if (seatLayout == null) return BadRequest();
            _unitOfWork.SeatLayout.Remove(seatLayout);
            await _unitOfWork.Complete();
            return Ok(seatLayout);
        }
    }
}
