using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var busBrands = await _unitOfWork.Brand.GetAll();
            return Ok(busBrands);
        }

        // GET: api/Brand/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var busBrand = await _unitOfWork.Brand.Get(id);

            if (busBrand == null)
            {
                return NotFound();
            }

            return Ok(busBrand);
        }

        // POST: api/Brand
        [HttpPost]
        public async Task<IActionResult> PostBrand(Brand brand)
        {
            if (brand == null) return BadRequest();
            _unitOfWork.Brand.Add(brand);
            await _unitOfWork.Complete();
            return Ok(brand);
        }
        // PUT: api/Brand/5
        [HttpPut]
        public async Task<IActionResult> PutBrand(Brand brand)
        {
            if (brand == null) return BadRequest();
            _unitOfWork.Brand.Update(brand);
            await _unitOfWork.Complete();
            return Ok(brand);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Brand>> DeleteBrand(int id)
        {
            var busBrand = await _unitOfWork.Brand.Get(id);
            if (busBrand == null) return BadRequest();
            _unitOfWork.Brand.Remove(busBrand);
            await _unitOfWork.Complete();
            return Ok(busBrand);
        }
    }
}
