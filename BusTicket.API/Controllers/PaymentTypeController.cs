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
    public class PaymentTypeController : ControllerBase
    {
      
        private readonly IUnitOfWork _unitOfWork;
     

        public PaymentTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }

        // GET: api/PaymentType
        [HttpGet]
        public async Task<IActionResult> GetPaymentTypes()
        {
            var paymentType = await _unitOfWork.PaymentType.GetAll();
            return Ok(paymentType);
        }


        // GET: api/PaymentType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentType(int id)
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
        public async Task<IActionResult> PostPaymentType(PaymentType paymentType)
        {

            _unitOfWork.PaymentType.Add(paymentType);
            await _unitOfWork.Complete();
            return Ok(paymentType);
        }

        // PUT: api/BusCategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentType(PaymentType paymentType)
        {
            _unitOfWork.PaymentType.Update(paymentType);
            await _unitOfWork.Complete();
            return Ok(paymentType);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentType>> DeletePaymentType(int id)
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
