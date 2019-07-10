using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public VendorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Vendor
        [HttpGet]
        public IActionResult GetVendors()
        {
            var vendors = _unitOfWork.Vendor.GetAll();
            return Ok(vendors);
        }

        // GET: api/Vendor/5
        [HttpGet("{id}")]
        public IActionResult GetVendor(int id)
        {
            var Vendor = _unitOfWork.Vendor.Get(id);

            if (Vendor == null)
            {
                return NotFound();
            }

            return Ok(Vendor);
        }

        // PUT: api/Vendor/5
        [HttpPut("{id}")]
        public void PutVendor(Vendor Vendor)
        {
            _unitOfWork.Vendor.Update(Vendor);
            _unitOfWork.Complete();
        }

        // POST: api/Vendor
        [HttpPost]
        public void PostVendor([FromBody] Vendor Vendor)
        {
            _unitOfWork.Vendor.Add(Vendor);
            _unitOfWork.Complete();
        }

        // DELETE: api/Vendor/5
        [HttpDelete("{id}")]
        public ActionResult<Vendor> DeleteVendor(int id)
        {
            var Vendor = _unitOfWork.Vendor.Get(id);

            if (Vendor == null)
            {
                return NotFound();
            }
            _unitOfWork.Vendor.Remove(Vendor);
            return Ok(Vendor);
        }
    }
}
