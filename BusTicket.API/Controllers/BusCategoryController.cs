using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using BusTicket.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicket.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BusCategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BusCategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/BusCategory
        [HttpGet]
        public async Task<IActionResult> GetBusCategories()
        {
            var busCategories = await _unitOfWork.BusCategory.Find(i => i.IsActive == true);
            return Ok(busCategories);
        }

        // GET: api/BusCategory
        [HttpGet("GetArchive")]
        public async Task<IActionResult> GetArchiveBusCategories()
        {
            var busCategories = await _unitOfWork.BusCategory.Find(i => i.IsActive == false);
            return Ok(busCategories);
        }


        // GET: api/BusCategory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusCategory(int id)
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
        public async Task<IActionResult> PostBusCategory(BusCategoryDTO busCategory)
        {
            var model = _mapper.Map<BusCategory>(busCategory);

            _unitOfWork.BusCategory.Add(model);
            await _unitOfWork.Complete();
            return Ok(busCategory);
        }

        // PUT: api/BusCategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusCategory(BusCategoryDTO busCategory)
        {

            var model = _mapper.Map<BusCategory>(busCategory);

            _unitOfWork.BusCategory.Update(model);
            await _unitOfWork.Complete();
            return Ok(busCategory);
        }

        //Soft Delete
        [HttpPut("BusCategoryDelete/{id}")]
        public async Task<ActionResult<Brand>> BusCategorySoftDelete(int id)
        {
            var busCategory = await _unitOfWork.BusCategory.Get(id);
            if (busCategory == null) return BadRequest();
            busCategory.IsActive = false;
            _unitOfWork.BusCategory.Update(busCategory);
            await _unitOfWork.Complete();
            return Ok(busCategory);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusCategoryDTO>> DeleteBusCategory(int id)
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
