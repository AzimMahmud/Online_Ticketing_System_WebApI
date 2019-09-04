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
    public class BusReservationController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusReservationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/BusReservation
        [HttpGet]
        public async Task<IHttpActionResult> GetBusReservations()
        {
            var busReservations = await _unitOfWork.BusReservation.GetAll();
            return Ok(busReservations);
        }

        // GET: api/BusReservation/5
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetBusReservation(int id)
        {
            var busReservation = await _unitOfWork.BusReservation.Get(id);

            if (busReservation == null)
            {
                return NotFound();
            }

            return Ok(busReservation);
        }

        // POST: api/BusReservation
        [HttpPost]
        public async Task<IHttpActionResult> PostBusReservation(BusReservation busReservation)
        {
            if (busReservation == null) return BadRequest();
            _unitOfWork.BusReservation.Add(busReservation);
            await _unitOfWork.Complete();
            return Ok(busReservation);
        }

        // PUT: api/BusReservation/5
        [HttpPut]
        public async Task<IHttpActionResult> PutBusReservation(BusReservation busReservation)
        {
            if (busReservation == null) return BadRequest();
            _unitOfWork.BusReservation.Update(busReservation);
            await _unitOfWork.Complete();
            return Ok(busReservation);
        }


        // DELETE: api/BusReservation/5
        [HttpDelete, Route("{id}")]
        public async Task<IHttpActionResult> DeleteBusReservation(int id)
        {
            var busReservation = await _unitOfWork.BusReservation.Get(id);
            if (busReservation == null) return BadRequest();
            _unitOfWork.BusReservation.Remove(busReservation);
            await _unitOfWork.Complete();
            return Ok(busReservation);
        }
    }
}
