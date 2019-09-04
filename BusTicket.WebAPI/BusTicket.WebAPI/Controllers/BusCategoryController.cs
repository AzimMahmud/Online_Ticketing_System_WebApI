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
    [Route("api/[controller]")]
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
            var busCategories = await _unitOfWork.BusCategory.Find(i => i.IsActive == true);
            return Ok(busCategories);
        }

        // GET: api/BusCategory
        [HttpGet, Route("GetArchive")]
        public async Task<IHttpActionResult> GetArchiveBusCategories()
        {
            var busCategories = await _unitOfWork.BusCategory.Find(i => i.IsActive == false);
            return Ok(busCategories);
        }


        // GET: api/BusCategory/5
        [HttpGet, Route("{id}")]
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
        public async Task<IHttpActionResult> PostBusCategory(BusCategory busCategory)
        {
            //var model = _mapper.Map<BusCategory>(busCategory);

            _unitOfWork.BusCategory.Add(busCategory);
            await _unitOfWork.Complete();
            return Ok(busCategory);
        }

        // PUT: api/BusCategory/5
        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> PutBusCategory(BusCategory busCategory)
        {

            //var model = _mapper.Map<BusCategory>(busCategory);

            _unitOfWork.BusCategory.Update(busCategory);
            await _unitOfWork.Complete();
            return Ok(busCategory);
        }

        //Soft Delete
        [HttpPut, Route("BusCategoryDelete/{id}")]
        public async Task<IHttpActionResult> BusCategorySoftDelete(int id)
        {
            var busCategory = await _unitOfWork.BusCategory.Get(id);
            if (busCategory == null) return BadRequest();
            busCategory.IsActive = false;
            _unitOfWork.BusCategory.Update(busCategory);
            await _unitOfWork.Complete();
            return Ok(busCategory);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete, Route("{id}")]
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
