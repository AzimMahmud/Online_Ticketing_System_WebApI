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
        public async Task<IActionResult> GetBusDetails()
        {
            var busDetails = await _unitOfWork.BusDetail.GetAll();
            return Ok(busDetails);
        }

        // GET: api/BusDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusDetail(int id)
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
        public async Task<IActionResult> PostBusDetail(BusDetailDTO busDetail)
        {
            var model = _mapper.Map<BusDetail>(busDetail);

            _unitOfWork.BusDetail.Add(model);
            await _unitOfWork.Complete();
            return Ok(busDetail);
        }

        // PUT: api/BusDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusDetail(BusDetailDTO busDetail)
        {

            var model = _mapper.Map<BusDetail>(busDetail);

            _unitOfWork.BusDetail.Update(model);
           await _unitOfWork.Complete();
           return Ok(busDetail);
        }

        // DELETE: api/BusDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusDetailDTO>> DeleteBusDetail(int id)
        {
            var busDetail = await _unitOfWork.BusDetail.Get(id);

            if (busDetail == null)
            {
                return NotFound();
            }


            _unitOfWork.BusDetail.Remove(busDetail);
           await _unitOfWork.Complete();
           return Ok(busDetail);
        }


    }
}
