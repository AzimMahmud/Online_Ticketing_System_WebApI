using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;
using BusTicket.WebAPI.Core;
using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.Persistence;

namespace BusTicket.WebAPI.Controllers
{
    
    public class BrandController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

       

        public BrandController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Brand
        [HttpGet]
        public IHttpActionResult GetBrands()
        {
            var busBrands = _unitOfWork.Brand.GetAll();
            return Ok(busBrands);
            //return Ok();
        }

        // GET: api/Brand/5
        [HttpGet, Route("GeBrand/{id}")]
        public IHttpActionResult GetBrand(int id)
        {
            var busBrand = _unitOfWork.Brand.Get(id);

            if (busBrand == null)
            {
                return NotFound();
            }

            return Ok(busBrand);
        }

        // POST: api/Brand
        [HttpPost]
        public async Task<IHttpActionResult> PostBrand(Brand brand)
        {
            if (brand == null) return BadRequest();
            _unitOfWork.Brand.Add(brand);
            await _unitOfWork.Complete();
            return Ok(brand);
        }
        // PUT: api/Brand/5
        //[HttpPut]
        //public async Task<IHttpActionResult> PutBrand(Brand brand)
        //{
        //    if (brand == null) return BadRequest();
        //    _unitOfWork.Brand.Update(brand);
        //    await _unitOfWork.Complete();
        //    return Ok(brand);
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete, Route("{id}")]
        public IHttpActionResult DeleteBrand(int id)
        {
            var busBrand = _unitOfWork.Brand.Get(id);
            if (busBrand == null) return BadRequest();
            _unitOfWork.Brand.Remove(busBrand);
            _unitOfWork.Complete();
            return Ok(busBrand);
        }
    }
}
