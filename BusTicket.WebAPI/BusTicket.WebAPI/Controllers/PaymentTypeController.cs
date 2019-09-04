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
    public class PaymentTypeController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/PaymentType
        [HttpGet]
        public async Task<IHttpActionResult> GetPaymentTypes()
        {
            var paymentType = await _unitOfWork.PaymentType.GetAll();
            return Ok(paymentType);
           
        }


        // GET: api/PaymentType/5
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetPaymentType(int id)
        {
            var paymentType = await _unitOfWork.PaymentType.Get(id);

            if (paymentType == null)
            {
                return NotFound();
            }

            return Ok(paymentType);
        }

        // POST: api/PaymentType
        [HttpPost]
        public async Task<IHttpActionResult> PostPaymentType(PaymentType paymentType)
        {

            _unitOfWork.PaymentType.Add(paymentType);
            await _unitOfWork.Complete();
            return Ok(paymentType);
        }

        // PUT: api/BusCategory/5
        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> PutPaymentType(PaymentType paymentType)
        {
            _unitOfWork.PaymentType.Update(paymentType);
            await _unitOfWork.Complete();
            return Ok(paymentType);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete,Route("{id}")]
        public async Task<IHttpActionResult> DeletePaymentType(int id)
        {
            var paymentType = await _unitOfWork.PaymentType.Get(id);

            if (paymentType == null)
            {
                return BadRequest();
            }
            _unitOfWork.PaymentType.Remove(paymentType);
            await _unitOfWork.Complete();
            return Ok(paymentType);
        }
    }
}
