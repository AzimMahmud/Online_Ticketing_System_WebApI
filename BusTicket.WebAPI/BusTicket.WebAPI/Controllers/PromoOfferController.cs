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
    public class PromoOfferController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PromoOfferController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/PromoOffer
        [HttpGet]
        public async Task<IHttpActionResult> GetPromoOffers()
        {
            var promoOffers = await _unitOfWork.PromoOffer.GetAll();
            return Ok(promoOffers);
        }

        // GET: api/PromoOffer/5
        [HttpGet]
        public async Task<IHttpActionResult> GetPromoOffer(int id)
        {
            var PromoOffer = await _unitOfWork.PromoOffer.Get(id);

            if (PromoOffer == null)
            {
                return NotFound();
            }

            return Ok(PromoOffer);
        }

        // POST: api/PromoOffer
        [HttpPost]
        public async Task<IHttpActionResult> PostPromoOffer(PromoOffer promoOffer)
        {
            if (promoOffer == null) return BadRequest();
            _unitOfWork.PromoOffer.Add(promoOffer);
            await _unitOfWork.Complete();
            return Ok(promoOffer);
        }

        // PUT: api/PromoOffer/5
        [HttpPut]
        public async Task<IHttpActionResult> PutPromoOffer(PromoOffer promoOffer)
        {
            if (promoOffer == null) return BadRequest();
            _unitOfWork.PromoOffer.Update(promoOffer);
            await _unitOfWork.Complete();
            return Ok(promoOffer);
        }

        // DELETE: api/PromoOffer/5
        [HttpDelete]
        public async Task<IHttpActionResult> DeletePromoOffer(int id)
        {
            var promoOffer = await _unitOfWork.PromoOffer.Get(id);
            if (promoOffer == null) return BadRequest();
            _unitOfWork.PromoOffer.Remove(promoOffer);
            await _unitOfWork.Complete();
            return Ok(promoOffer);
        }
    }
}
