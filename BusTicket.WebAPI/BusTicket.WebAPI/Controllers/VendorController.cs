using AutoMapper;
using BusTicket.API.DTOs;
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
    public class VendorController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VendorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Vendor
        [HttpGet]
        public async Task<IHttpActionResult> GetVendorDetails()
        {
            var vendors = await _unitOfWork.Vendor.Find(i => i.IsActive == true);

            return Ok(vendors);
        }


        // GET: api/BusDetail
        [HttpGet,Route("GetArchive")]
        public async Task<IHttpActionResult> GetArchiveVendorDetails()
        {
            var vendors = await _unitOfWork.Vendor.Find(i => i.IsActive == false);
            return Ok(vendors);
        }

        // GET: api/BusDetail/5
        [HttpGet,Route("{id}")]
        public async Task<IHttpActionResult> GetVendorDetail(int id)
        {
            var vendorDetail = await _unitOfWork.Vendor.Get(id);

            if (vendorDetail == null)
            {
                return NotFound();
            }

            return Ok(vendorDetail);
        }

        // PUT: api/BusDetail/5
        [HttpPut]
        public async Task<IHttpActionResult> PutVendorDetail(VendorDTO vendorDetail)
        {

            var model = _mapper.Map<Vendor>(vendorDetail);

            _unitOfWork.Vendor.Update(model);
            await _unitOfWork.Complete();
            return Ok(vendorDetail);
        }

        // POST: api/BusDetail
        [HttpPost]
        public async Task<IHttpActionResult> PostBusDetail(VendorDTO vendorDetail)
        {
            var model = _mapper.Map<Vendor>(vendorDetail);

            _unitOfWork.Vendor.Add(model);
            await _unitOfWork.Complete();
            return Ok(vendorDetail);
        }


        //Soft Delete
        [HttpPut,Route("VendorDelete/{id}")]
        public async Task<IHttpActionResult> VendorSoftDelete(int id)
        {
            var vendorDetail = await _unitOfWork.Vendor.Get(id);
            if (vendorDetail == null) return BadRequest();
            vendorDetail.IsActive = false;
            _unitOfWork.Vendor.Update(vendorDetail);
            await _unitOfWork.Complete();
            return Ok(vendorDetail);
        }

        // DELETE: api/BusDetail/5
        [HttpDelete,Route("{id}")]
        public async Task<IHttpActionResult> DeleteVendorDetail(int id)
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
