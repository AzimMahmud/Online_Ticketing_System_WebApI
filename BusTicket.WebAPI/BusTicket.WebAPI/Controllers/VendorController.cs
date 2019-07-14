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
    public class VendorController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public VendorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Vendor
        [HttpGet]
        public async Task<IHttpActionResult> GetVendors()
        {
            var vendors = await _unitOfWork.Brand.GetAll();
            return Ok(vendors);
        }

        // GET: api/Vendor/5
        [HttpGet]
        public async Task<IHttpActionResult> GetVendor(int id)
        {
            var vendor = await _unitOfWork.Vendor.Get(id);

            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor);
        }

        // POST: api/Vendor
        [HttpPost]
        public async Task<IHttpActionResult> PostVendor(Vendor vendor)
        {
            if (vendor == null) return BadRequest();
            _unitOfWork.Vendor.Add(vendor);
            await _unitOfWork.Complete();
            return Ok(vendor);
        }

        // PUT: api/Vendor/5
        [HttpPut]
        public async Task<IHttpActionResult> PutVendor(Vendor vendor)
        {
            if (vendor == null) return BadRequest();
            _unitOfWork.Vendor.Update(vendor);
            await _unitOfWork.Complete();
            return Ok(vendor);
        }

        // DELETE: api/Vendor/5
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteVendor(int id)
        {
            var vendor = await _unitOfWork.Vendor.Get(id);
            if (vendor == null) return BadRequest();
            _unitOfWork.Vendor.Remove(vendor);
            await _unitOfWork.Complete();
            return Ok(vendor);
        }
    }
}
