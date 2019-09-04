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
using Microsoft.AspNetCore.Authorization;

namespace BusTicket.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BusReservationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusReservationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/BusReservation
        [HttpGet]
        public async Task<ActionResult> GetBusReservations()
        {
            var busReservations = await _unitOfWork.BusReservation.GetAll();
            return Ok(busReservations);

        }

        // GET: api/BusReservation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusReservation>> GetBusReservation(int id)
        {
            var busReservation = await _unitOfWork.BusReservation.Get(id);

            if (busReservation == null)
            {
                return NotFound();
            }

            return busReservation;
        }

        // POST: api/BusReservation
        [HttpPost]
        public async Task<ActionResult> PostBusReservation(BusReservation busReservation)
        {
            if (busReservation == null) return BadRequest();
            _unitOfWork.BusReservation.Add(busReservation);
            await _unitOfWork.Complete();
            return Ok(busReservation);
        }

        // PUT: api/BusReservation/5
        [HttpPut]
        public async Task<IActionResult> PutBusReservation(BusReservation busReservation)
        {
            if (busReservation == null) return BadRequest();
            _unitOfWork.BusReservation.Update(busReservation);
            await _unitOfWork.Complete();
            return Ok(busReservation);
        }


        // DELETE: api/BusReservation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusReservation>> DeleteBusReservation(int id)
        {
            var busReservation = await _unitOfWork.BusReservation.Get(id);
            if (busReservation == null) return BadRequest();
            _unitOfWork.BusReservation.Remove(busReservation);
            await _unitOfWork.Complete();
            return Ok(busReservation);
        }
    }
}
