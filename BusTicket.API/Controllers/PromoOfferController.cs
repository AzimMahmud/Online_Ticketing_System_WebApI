using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicket.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PromoOfferController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public PromoOfferController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        // GET: api/PromoOffer
        [HttpGet]
        public async Task<IActionResult> GetPromoOffers()
        {
            var promoOffers = await _unitOfWork.PromoOffer.Find(i => i.IsActive == true);
            return Ok(promoOffers);
        }

        // GET: api/PromoOffer
        [HttpGet("GetArchive")]
        public async Task<IActionResult> GetArchiveBrands()
        {
            var promoOffers = await _unitOfWork.PromoOffer.Find(i => i.IsActive == false);
            return Ok(promoOffers);
        }


        // GET: api/PromoOffer/5
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

        // POST: api/PromoOffer
        [HttpPost]
        public async Task<IActionResult> PostPromoOffer(PromoOffer promoOffer)
        {
            if (promoOffer == null) return BadRequest();
            _unitOfWork.PromoOffer.Add(promoOffer);
            await _unitOfWork.Complete();
            return Ok(promoOffer);
        }

        // PUT: api/PromoOffer/5
        [HttpPut]
        public async Task<IActionResult> PutPromoOffer(PromoOffer promoOffer)
        {
            if (promoOffer == null) return BadRequest();
            _unitOfWork.PromoOffer.Update(promoOffer);
            await _unitOfWork.Complete();
            return Ok(promoOffer);
        }


        //Soft Delete
        [HttpPut("PromoDelete/{id}")]
        public async Task<ActionResult<PromoOffer>> PromoSoftDelete(int id)
        {
            var promoOffer = await _unitOfWork.PromoOffer.Get(id);
            if (promoOffer == null) return BadRequest();
            promoOffer.IsActive = false;
            _unitOfWork.PromoOffer.Update(promoOffer);
            await _unitOfWork.Complete();
            return Ok(promoOffer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PromoOffer>> DeletePromoOffer(int id)
        {
            var promoOffer = await _unitOfWork.PromoOffer.Get(id);
            if (promoOffer == null) return BadRequest();
            _unitOfWork.PromoOffer.Remove(promoOffer);
            await _unitOfWork.Complete();
            return Ok(promoOffer);
        }
    }
}
