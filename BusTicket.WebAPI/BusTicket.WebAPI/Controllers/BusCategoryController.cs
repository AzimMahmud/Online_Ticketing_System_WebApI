using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusTicket.API.DTOs;
using BusTicket.WebAPI.Core;
using BusTicket.WebAPI.Core.Domain;

namespace BusTicket.WebAPI.Controllers
{
    public class BusCategoryController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public BusCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        
        }

        // GET: api/BusCategory
        [HttpGet]
        public async Task<IHttpActionResult> GetBusCategories()
        {
            var busCategories = await _unitOfWork.BusCategory.GetAll();
            return Ok(busCategories);
        }


        // GET: api/BusCategory/5
        [HttpGet]
        public async Task<IHttpActionResult> GetBusCategory(int id)
        {
            var busCategory = await _unitOfWork.BusCategory.Get(id);

            if (busCategory == null)
            {
                return NotFound();
            }

            return Ok(busCategory);
        }

        // POST: api/BusCategory
        [HttpPost]
        public async Task<IHttpActionResult> PostBusCategory(BusCategoryDTO busCategory)
        {
            var model = Mapper.Map<BusCategory>(busCategory);

            _unitOfWork.BusCategory.Add(model);
            await _unitOfWork.Complete();
            return Ok(busCategory);
        }

        // PUT: api/BusCategory/5
        [HttpPut]
        public async Task<IHttpActionResult> PutBusCategory(BusCategoryDTO busCategory)
        {

            var model = Mapper.Map<BusCategory>(busCategory);

            _unitOfWork.BusCategory.Update(model);
            await _unitOfWork.Complete();
            return Ok(busCategory);
        }

        // DELETE: api/BusCategory/5
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBusCategory(int id)
        {
            var busCategory = await _unitOfWork.BusCategory.Get(id);

            if (busCategory == null)
            {
                return BadRequest();
            }


            _unitOfWork.BusCategory.Remove(busCategory);
            await _unitOfWork.Complete();
            return Ok(busCategory);
        }
    }
}
