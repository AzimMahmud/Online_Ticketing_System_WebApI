using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using BusTicket.API.DTOs;
using BusTicket.API.Helper;
using BusTicket.API.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BusTicket.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Brand
        [HttpGet("GetTotalVendor")]
        public IActionResult GetTotalNoOFVendor()
        {
            var busBrands = _unitOfWork.Vendor.GetTotalVendor();
            return Ok(busBrands);
        }

        // GET: api/Brand
        [HttpGet("GetTotalSales")]
        public IActionResult GetTotalNoOFSales()
        {
            var totalsales = _unitOfWork.TicketReservation.GetTotalSales();
            return Ok(totalsales);
        }



    }
}