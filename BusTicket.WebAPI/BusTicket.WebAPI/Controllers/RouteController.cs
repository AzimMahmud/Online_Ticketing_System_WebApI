using AutoMapper;
using BusTicket.API.DTOs;
using BusTicket.WebAPI.Core;
using BusTicket.WebAPI.Core.Domain;
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
    [Route("api/[controller]")]
    public class RouteController : ApiController
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
        public async Task<IHttpActionResult> GetRouteDetails()
        {
            var routeDetails = await _unitOfWork.Route.GetAll();
            if (routeDetails == null)
            {
                return NotFound();
            }
            return Ok(routeDetails);
        }

        // GET: api/Route/5
        [HttpGet,Route("{id}")]
        public async Task<IHttpActionResult> GetRouteDetail(int id)
        {
            var routeDetail = await _unitOfWork.Route.Get(id);

            if (routeDetail == null)
            {
                return NotFound();
            }

            return Ok(routeDetail);
        }

        // PUT: api/Route/5
        [HttpPut,Route("{id}")]
        public async Task<IHttpActionResult> PutRouteDetail(RouteDetailDTO routeDetail)
        {
            var model = _mapper.Map<RouteDetail>(routeDetail);

            _unitOfWork.Route.Update(model);
            await _unitOfWork.Complete();
            return Ok(routeDetail);
        }

        // POST: api/Route
        [HttpPost]
        public async Task<IHttpActionResult> PostRouteDetail(RouteDetailDTO routeDetail)
        {
            // routeDetail.BoardTime = routeDetail.BoardTime;
            // routeDetail.DropTime = (DateTime.ParseExact(routeDetail.DropTime, "HH.mm", CultureInfo.InvariantCulture).TimeOfDay).ToString();
            var model = _mapper.Map<RouteDetail>(routeDetail);

            _unitOfWork.Route.Add(model);
            await _unitOfWork.Complete();
            return Ok(routeDetail);
        }



        // DELETE: api/Route/5
        [HttpDelete,Route("{id}")]
        public async Task<IHttpActionResult> DeleteRouteDetail(int id)
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

        // Get RoutesDetails
        [HttpGet,Route("RouteDetails")]
        public async Task<IHttpActionResult> GetRoutesDetails(string bPoint, string dPoint, string jDate)
        {
            var routeDetail = await _unitOfWork.Route.GetAllRoutesForTicketReservation(bPoint, dPoint, jDate);
            return Ok(routeDetail);
        }
    }
}
