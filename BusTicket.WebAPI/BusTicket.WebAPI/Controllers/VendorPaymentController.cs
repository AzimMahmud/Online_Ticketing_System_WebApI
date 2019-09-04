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
    public class VendorPaymentController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public VendorPaymentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/VendorPayment
        [HttpGet]
        public async Task<IHttpActionResult> GetVendorPayments()
        {
            var vendorPayments = await _unitOfWork.VendorPayment.GetAll();
            return Ok(vendorPayments);
            return Ok();
        }

        // GET: api/VendorPayment/5
        [HttpGet,Route("{id}")]
        public async Task<IHttpActionResult> GetVendorPayment(int id)
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
        public async Task<IHttpActionResult> PostVendorPayment(VendorPayment vendorPayment)
        {
            if (vendorPayment == null) return BadRequest();
            _unitOfWork.VendorPayment.Add(vendorPayment);
            await _unitOfWork.Complete();
            return Ok(vendorPayment);
        }


        // PUT: api/VendorPayment/5
        [HttpPut]
        public async Task<IHttpActionResult> PutVendorPayment(VendorPayment vendorPayment)
        {
            if (vendorPayment == null) return BadRequest();
            _unitOfWork.VendorPayment.Update(vendorPayment);
            await _unitOfWork.Complete();
            return Ok(vendorPayment);
        }

        // DELETE: api/VendorPayment/5
        [HttpDelete,Route("{id}")]
        public async Task<IHttpActionResult> DeleteVendorPayment(int id)
        {
            var vendorPayment = await _unitOfWork.VendorPayment.Get(id);
            if (vendorPayment == null) return BadRequest();
            _unitOfWork.VendorPayment.Remove(vendorPayment);
            await _unitOfWork.Complete();
            return Ok(vendorPayment);
        }
    }
}
