using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BusTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public BusDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/BusDetail
        [HttpGet]
        public IActionResult GetBusDetails()
        {
            var users = _unitOfWork.BusDetail.GetAll();
            return Ok(users);
        }

        // GET: api/BusDetail/5
        [HttpGet("{id}")]
        public IActionResult GetBusDetail(int id)
        {
            var busDetail = _unitOfWork.BusDetail.Get(id);

            if (busDetail == null)
            {
                return NotFound();
            }

            return Ok(busDetail);
        }

        // PUT: api/BusDetail/5
        [HttpPut("{id}")]
        public void PutBusDetail(BusDetail busDetail)
        {
            _unitOfWork.BusDetail.Update(busDetail);
            _unitOfWork.Complete();
        }

        // POST: api/BusDetail
        [HttpPost]
        public void PostBusDetail([FromBody] BusDetail busDetail)
        {
            _unitOfWork.BusDetail.Add(busDetail);
            _unitOfWork.Complete();
        }

        // DELETE: api/BusDetail/5
        [HttpDelete("{id}")]
        public ActionResult<BusDetail> DeleteBusDetail(int id)
        {
            var busDetail = _unitOfWork.BusDetail.Get(id);

            if (busDetail == null)
            {
                return NotFound();
            }
            _unitOfWork.BusDetail.Remove(busDetail);
            return Ok(busDetail);
        }


    }
}
