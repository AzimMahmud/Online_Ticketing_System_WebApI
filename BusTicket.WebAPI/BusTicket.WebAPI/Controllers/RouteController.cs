using BusTicket.WebAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;

namespace BusTicket.WebAPI.Controllers
{
    public class RouteController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public RouteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/Route
        [HttpGet]
        public async Task<IHttpActionResult> GetRoutes()
        {
            var routes = await _unitOfWork.Route.GetAll();
            return Ok(routes);
        }

        // GET: api/Route/5
        [HttpGet]
        public async Task<IHttpActionResult> GetRoute(int id)
        {
            var route = await _unitOfWork.Route.Get(id);

            if (route == null)
            {
                return NotFound();
            }

            return Ok(route);
        }

        // POST: api/Route
        [HttpPost]
        public async Task<IHttpActionResult> PostRoute(Route route)
        {
            if (route == null) return BadRequest();
            _unitOfWork.Route.Add(route);
            await _unitOfWork.Complete();
            return Ok(route);
        }

        // PUT: api/Route/5
        [HttpPut]
        public async Task<IHttpActionResult> PutRoute(Route route)
        {
            if (route == null) return BadRequest();
            _unitOfWork.Route.Update(route);
            await _unitOfWork.Complete();
            return Ok(route);
        }

        // DELETE: api/Route/5
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRoute(int id)
        {
            var route = await _unitOfWork.Route.Get(id);
            if (route == null) return BadRequest();
            _unitOfWork.Route.Remove(route);
            await _unitOfWork.Complete();
            return Ok(route);
        }
    }
}
