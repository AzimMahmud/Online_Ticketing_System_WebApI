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
    public class RouteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RouteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Route
        [HttpGet]
        public async Task<IActionResult> GetRouteDetails()
        {
            var routeDetails = await _unitOfWork.Route.GetAll();
            if (routeDetails == null)
            {
                return NotFound();
            }
            return Ok(routeDetails);
        }

        // GET: api/Route/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRouteDetail(int id)
        {
            var routeDetail = await _unitOfWork.Route.Get(id);

            if (routeDetail == null)
            {
                return NotFound();
            }

            return Ok(routeDetail);
        }

        // PUT: api/Route/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouteDetail(RouteDTO routeDetail)
        {

            var model = _mapper.Map<Route>(routeDetail);

            _unitOfWork.Route.Update(model);
            await _unitOfWork.Complete();
            return Ok(routeDetail);
        }

        // POST: api/Route
        [HttpPost]
        public async Task<IActionResult> PostRouteDetail(RouteDTO routeDetail)
        {
            var model = _mapper.Map<Route>(routeDetail);

            _unitOfWork.Route.Add(model);
            await _unitOfWork.Complete();
            return Ok(routeDetail);
        }



        // DELETE: api/Route/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RouteDTO>> DeleteRouteDetail(int id)
        {
            var routeDetail = await _unitOfWork.Route.Get(id);

            if (routeDetail == null)
            {
                return NotFound();
            }


            _unitOfWork.Route.Remove(routeDetail);
            await _unitOfWork.Complete();
            return Ok(routeDetail);
        }
    }
}
