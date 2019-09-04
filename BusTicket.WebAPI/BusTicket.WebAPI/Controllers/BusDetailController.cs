using AutoMapper;
using BusTicket.WebAPI.Core;
using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.DTOs;
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
    public class BusDetailController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BusDetailController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        // GET: api/BusDetail
        [HttpGet, Route("GetBusInfo")]
        public async Task<IEnumerable<object>> GetBusDetails()
        {
            var busDetails = await _unitOfWork.BusDetail.GetBusInfo();
            return busDetails;
        }

        // GET: api/BusDetail
        [HttpGet, Route("GetArchive")]
        public async Task<IHttpActionResult> GetAchiveBusDetails()
        {
            var busBrands = await _unitOfWork.BusDetail.GetArchiveBusInfo();
            return Ok(busBrands);
        }

        // GET: api/BusDetail
        [HttpGet, Route("BusDetailbyId/{busDetailsid}")]
        public async Task<IEnumerable<Object>> GetVendorDetails(int busDetailsid)
        {
            var vendorDetails = await _unitOfWork.BusDetail.GetALLDetailsWithVendorCategoryBrand(busDetailsid);
            return vendorDetails;
        }

        // GET: api/BusDetail
        [HttpGet, Route("GetVendorDetails")]
        public async Task<IEnumerable<Object>> GetVendorDetails()
        {
            var categoryDetails = await _unitOfWork.BusDetail.GetBusDetailWithVendor();
            return categoryDetails;
        }


        // GET: api/BusDetail
        [HttpGet, Route("GetCategoryDetails")]
        public async Task<IEnumerable<Object>> GetCategoryDetails()
        {
            var categoryDetails = await _unitOfWork.BusDetail.GetBusDetailWithCategory();
            return categoryDetails;
        }
        // GET: api/BusDetail
        [HttpGet, Route("GetBrandDetails")]
        public async Task<IEnumerable<Object>> GetBrandDetails()
        {
            var brandDetails = await _unitOfWork.BusDetail.GetBusDetailWithBrand();
            return brandDetails;
        }

        // GET: api/BusDetail/5
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetBusDetail(int id)
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
        public async Task<IHttpActionResult> PostBusDetail(BusDetailDTO busDetail)
        {
            var model = _mapper.Map<BusDetail>(busDetail);

            _unitOfWork.BusDetail.Add(model);
            await _unitOfWork.Complete();
            return Ok(busDetail);
        }

        // PUT: api/BusDetail/5
        [HttpPut]
        public async Task<IHttpActionResult> PutBusDetail(BusDetailDTO busDetail)
        {

            var model = _mapper.Map<BusDetail>(busDetail);

            _unitOfWork.BusDetail.Update(model);
            await _unitOfWork.Complete();
            return Ok(busDetail);
        }


        // DELETE: api/ApiWithActions/5
        [HttpPut, Route("BusDetailDelete/{id}")]
        public async Task<IHttpActionResult> BrandSoftDelete(int id)
        {
            var busDetail = await _unitOfWork.BusDetail.Get(id);
            if (busDetail == null) return BadRequest();
            busDetail.IsActive = false;
            _unitOfWork.BusDetail.Update(busDetail);
            await _unitOfWork.Complete();
            return Ok(busDetail);
        }
        // DELETE: api/BusDetail/5
        [HttpDelete, Route("{id}")]
        public async Task<IHttpActionResult> DeleteBusDetail(int id)
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
