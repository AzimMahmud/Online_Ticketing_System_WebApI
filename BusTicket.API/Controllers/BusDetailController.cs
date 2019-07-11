using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using BusTicket.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BusTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BusDetailController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public void PutBusDetail(BusDetailDTO busDetail)
        {

            var model = _mapper.Map<BusDetail>(busDetail);

            _unitOfWork.BusDetail.Update(model);
            _unitOfWork.Complete();
        }

        // POST: api/BusDetail
        [HttpPost]
        public void PostBusDetail(BusDetailDTO busDetail)
        {
            var model = _mapper.Map<BusDetail>(busDetail);

            _unitOfWork.BusDetail.Add(model);
            _unitOfWork.Complete();
        }

       

        // DELETE: api/BusDetail/5
        [HttpDelete("{id}")]
        public ActionResult<BusDetailDTO> DeleteBusDetail(int id)
        {
            var busDetail = _unitOfWork.BusDetail.Get(id);

            if (busDetail == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<BusDetail>(busDetail);
            _unitOfWork.BusDetail.Remove(model);
            _unitOfWork.Complete();
            return Ok(busDetail);
        }


    }
}
