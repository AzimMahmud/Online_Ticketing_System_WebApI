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
    public class TicketReservationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketReservationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/TicketReservation
        [HttpGet]
        public async Task<ActionResult> GetTicketReservations()
        {
            var ticketReservations = await _unitOfWork.TicketReservation.GetAll();
            return Ok(ticketReservations);
        }

        // GET: api/TicketReservation/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTicketReservation(int id)
        {
            var ticketReservation = await _unitOfWork.TicketReservation.Get(id);

            if (ticketReservation == null)
            {
                return NotFound();
            }

            return Ok(ticketReservation);
        }


        // POST: api/TicketReservation
        [HttpPost]
        public async Task<ActionResult> PostTicketReservation(TicketReservation ticketReservation)
        {
            if (ticketReservation == null) return BadRequest();
            _unitOfWork.TicketReservation.Add(ticketReservation);
            await _unitOfWork.Complete();
            return Ok(ticketReservation);
        }

        // PUT: api/TicketReservation/5
        [HttpPut]
        public async Task<IActionResult> PutTicketReservation(TicketReservation ticketReservation)
        {
            if (ticketReservation == null) return BadRequest();
            _unitOfWork.TicketReservation.Update(ticketReservation);
            await _unitOfWork.Complete();
            return Ok(ticketReservation);
        }       

        // DELETE: api/TicketReservation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TicketReservation>> DeleteTicketReservation(int id)
        {
            var ticketReservation = await _unitOfWork.TicketReservation.Get(id);
            if (ticketReservation == null) return BadRequest();
            _unitOfWork.TicketReservation.Remove(ticketReservation);
            await _unitOfWork.Complete();
            return Ok(ticketReservation);
        }
    }
}
