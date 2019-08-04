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
    public class PromoOfferController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public PromoOfferController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        // GET: api/PaymentType
        [HttpGet]
        public async Task<IActionResult> GetPromoOffer()
        {
            var promoOffer = await _unitOfWork.PromoOffer.GetAll();
            return Ok(promoOffer);
        }


        // GET: api/PaymentType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromoOffer(int id)
        {
            var promoOffer = await _unitOfWork.PromoOffer.Get(id);

            if (promoOffer == null)
            {
                return NotFound();
            }

            return Ok(promoOffer);
        }

        // POST: api/PaymentType
        [HttpPost]
        public async Task<IActionResult> PostPromoOffer(PromoOffer promoOffer)
        {

            _unitOfWork.PromoOffer.Add(promoOffer);
            await _unitOfWork.Complete();
            return Ok(promoOffer);
        }

        // PUT: api/BusCategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromoOffer(PromoOffer promoOffer)
        {
            _unitOfWork.PromoOffer.Update(promoOffer);
            await _unitOfWork.Complete();
            return Ok(promoOffer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PromoOffer>> DeletePromoOffer(int id)
        {
            var promoOffer = await _unitOfWork.PromoOffer.Get(id);

            if (promoOffer == null)
            {
                return BadRequest();
            }
            _unitOfWork.PromoOffer.Remove(promoOffer);
            await _unitOfWork.Complete();
            return Ok(promoOffer);
        }
    }
}
