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
    public class VendorPaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VendorPaymentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/VendorPayment
        [HttpGet]
        public async Task<ActionResult> GetVendorPayments()
        {
            var vendorPayments = await _unitOfWork.VendorPayment.GetAll();
            return Ok(vendorPayments);

        }

        // GET: api/VendorPayment/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetVendorPayment(int id)
        {
            var vendorPayment = await _unitOfWork.VendorPayment.Get(id);

            if (vendorPayment == null)
            {
                return NotFound();
            }

            return Ok(vendorPayment);
        }

        // POST: api/VendorPayment
        [HttpPost]
        public async Task<ActionResult> PostVendorPayment(VendorPayment vendorPayment)
        {
            if (vendorPayment == null) return BadRequest();
            _unitOfWork.VendorPayment.Add(vendorPayment);
            await _unitOfWork.Complete();
            return Ok(vendorPayment);
        }


        // PUT: api/VendorPayment/5
        [HttpPut]
        public async Task<IActionResult> PutVendorPayment(VendorPayment vendorPayment)
        {
            if (vendorPayment == null) return BadRequest();
            _unitOfWork.VendorPayment.Update(vendorPayment);
            await _unitOfWork.Complete();
            return Ok(vendorPayment);
        }

        // DELETE: api/VendorPayment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VendorPayment>> DeleteVendorPayment(int id)
        {
            var vendorPayment = await _unitOfWork.VendorPayment.Get(id);
            if (vendorPayment == null) return BadRequest();
            _unitOfWork.VendorPayment.Remove(vendorPayment);
            await _unitOfWork.Complete();
            return Ok(vendorPayment);
        }
    }
}
