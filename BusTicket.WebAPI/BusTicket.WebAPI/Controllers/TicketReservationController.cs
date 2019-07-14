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
    public class TicketReservationController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketReservationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/TicketReservation
        [HttpGet]
        public async Task<IHttpActionResult> GetTicketReservations()
        {
            var ticketReservations = await _unitOfWork.TicketReservation.GetAll();
            return Ok(ticketReservations);
        }

        // GET: api/TicketReservation/5
        [HttpGet]
        public async Task<IHttpActionResult> GetTicketReservation(int id)
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
        public async Task<IHttpActionResult> PostTicketReservation(TicketReservation ticketReservation)
        {
            if (ticketReservation == null) return BadRequest();
            _unitOfWork.TicketReservation.Add(ticketReservation);
            await _unitOfWork.Complete();
            return Ok(ticketReservation);
        }

        // PUT: api/TicketReservation/5
        [HttpPut]
        public async Task<IHttpActionResult> PutTicketReservation(TicketReservation ticketReservation)
        {
            if (ticketReservation == null) return BadRequest();
            _unitOfWork.TicketReservation.Update(ticketReservation);
            await _unitOfWork.Complete();
            return Ok(ticketReservation);
        }

        // DELETE: api/TicketReservation/5
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteTicketReservation(int id)
        {
            var ticketReservation = await _unitOfWork.TicketReservation.Get(id);
            if (ticketReservation == null) return BadRequest();
            _unitOfWork.TicketReservation.Remove(ticketReservation);
            await _unitOfWork.Complete();
            return Ok(ticketReservation);
        }
    }
}
