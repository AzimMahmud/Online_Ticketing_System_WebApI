using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BusTicket.WebAPI.Core;
using BusTicket.WebAPI.Core.Domain;

namespace BusTicket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BrandController : ApiController
    {
         private readonly IUnitOfWork _unitOfWork;

        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<IHttpActionResult> GetBrands()
        {
            var busBrands = await _unitOfWork.Brand.Find(i => i.IsActive == true);
            return Ok(busBrands);
        }


        [HttpGet, Route("GetArchive")]
        public async Task<IHttpActionResult> GetAchiveBrands()
        {
            var busBrands = await _unitOfWork.Brand.Find(i => i.IsActive == false);
            return Ok(busBrands);
        }

        // GET: api/Brand/5
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetBrand(int id)
        {
            var busBrand = await _unitOfWork.Brand.Get(id);

            if (busBrand == null)
            {
                return NotFound();
            }

            return Ok(busBrand);
        }

        // GET: api/Brand/UniqueBrand
        [HttpPost, Route("BrandByName")]
        public async Task<IHttpActionResult> GetBrandByName(Brand brand)
        {
            var busBrand = await _unitOfWork.Brand.Find(n => n.Name.ToLower() == brand.Name.ToLower());
            if (busBrand == null)
            {
                return null;
            }
            else
            {
                return Ok(busBrand);
            }
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
        [HttpPut]
        public async Task<IHttpActionResult> PutBrand(Brand brand)
        {
            if (brand == null)
            {
                return BadRequest();
            }
            _unitOfWork.Brand.Update(brand);
            await _unitOfWork.Complete();
            return Ok(brand);
        }

        // DELETE: api/ApiWithActions/5
        [HttpPut, Route("BrandDelete/{id}")]
        public async Task<IHttpActionResult> BrandSoftDelete(int id)
        {
            var busBrand = await _unitOfWork.Brand.Get(id);
            if (busBrand == null) return BadRequest();
            busBrand.IsActive = false;
            _unitOfWork.Brand.Update(busBrand);
            await _unitOfWork.Complete();
            return Ok(busBrand);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete, Route("{id}")]
        public async Task<IHttpActionResult> DeleteBrand(int id)
        {
            var busBrand = await _unitOfWork.Brand.Get(id);
            if (busBrand == null) return BadRequest();
            _unitOfWork.Brand.Remove(busBrand);
            await _unitOfWork.Complete();
            return Ok(busBrand);
        }
    }
}
