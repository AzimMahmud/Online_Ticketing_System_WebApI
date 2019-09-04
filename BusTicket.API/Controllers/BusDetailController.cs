using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using BusTicket.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BusTicket.API.Controllers
{
    [AllowAnonymous]
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
        [HttpGet("GetBusInfo")]
        public async Task<IEnumerable<object>> GetBusDetails()
        {
            var busDetails = await _unitOfWork.BusDetail.GetBusInfo();
            return busDetails;
        }

        // GET: api/BusDetail
        [HttpGet("GetArchive")]
        public async Task<IActionResult> GetAchiveBusDetails()
        {
            var busBrands = await _unitOfWork.BusDetail.GetArchiveBusInfo();
            return Ok(busBrands);
        }

        // GET: api/BusDetail
        [HttpGet("BusDetailbyId/{busDetailsid}")]
        public async Task<IEnumerable<Object>> GetVendorDetails(int busDetailsid)
        {
            var vendorDetails = await _unitOfWork.BusDetail.GetALLDetailsWithVendorCategoryBrand(busDetailsid);
            return vendorDetails;
        }

        // GET: api/BusDetail
        [HttpGet("GetVendorDetails")]
        public async Task<IEnumerable<Object>> GetVendorDetails()
        {
            var categoryDetails = await _unitOfWork.BusDetail.GetBusDetailWithVendor();
            return categoryDetails;
        }


        // GET: api/BusDetail
        [HttpGet("GetCategoryDetails")]
        public async Task<IEnumerable<Object>> GetCategoryDetails()
        {
            var categoryDetails = await _unitOfWork.BusDetail.GetBusDetailWithCategory();
            return categoryDetails;
        }
        // GET: api/BusDetail
        [HttpGet("GetBrandDetails")]
        public async Task<IEnumerable<Object>> GetBrandDetails()
        {
            var brandDetails = await _unitOfWork.BusDetail.GetBusDetailWithBrand();
            return brandDetails;
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
        [HttpPut]
        public async Task<IActionResult> PutBusDetail(BusDetailDTO busDetail)
        {

            var model = _mapper.Map<BusDetail>(busDetail);

            _unitOfWork.BusDetail.Update(model);
            await _unitOfWork.Complete();
            return Ok(busDetail);
        }


        // DELETE: api/ApiWithActions/5
        [HttpPut("BusDetailDelete/{id}")]
        public async Task<ActionResult<Brand>> BrandSoftDelete(int id)
        {
            var busDetail = await _unitOfWork.BusDetail.Get(id);
            if (busDetail == null) return BadRequest();
            busDetail.IsActive = false;
            _unitOfWork.BusDetail.Update(busDetail);
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
