using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using BusTicket.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VendorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        // GET: api/BusDetail
        [HttpGet]
        public async Task<IActionResult> GetVendorDetails()
        {
            var vendors = await _unitOfWork.Vendor.GetAll();
           
            return Ok(vendors);
        }

        // GET: api/BusDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendorDetail(int id)
        {
            var vendorDetail = await _unitOfWork.Vendor.Get(id);

            if (vendorDetail == null)
            {
                return NotFound();
            }

            return Ok(vendorDetail);
        }

        // PUT: api/BusDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendorDetail(VendorDTO vendorDetail)
        {

            var model = _mapper.Map<Vendor>(vendorDetail);

            _unitOfWork.Vendor.Update(model);
            await _unitOfWork.Complete();
            return Ok(vendorDetail);
        }

        // POST: api/BusDetail
        [HttpPost]
        public async Task<IActionResult> PostBusDetail(VendorDTO vendorDetail)
        {
            var model = _mapper.Map<Vendor>(vendorDetail);

            _unitOfWork.Vendor.Add(model);
            await _unitOfWork.Complete();
            return Ok(vendorDetail);
        }



        // DELETE: api/BusDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusDetailDTO>> DeleteVendorDetail(int id)
        {
            var vendorDetail = await _unitOfWork.Vendor.Get(id);

            if (vendorDetail == null)
            {
                return NotFound();
            }


            _unitOfWork.Vendor.Remove(vendorDetail);
            await _unitOfWork.Complete();
            return Ok(vendorDetail);
        }
    }
}
