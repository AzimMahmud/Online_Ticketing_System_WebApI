using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BusTicket.WebAPI.Core.Repositories;
using BusTicket.WebAPI.Models;
using Microsoft.AspNet.Identity;

namespace BusTicket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ApiController
    {
        private UserManager<ApplicationUser> _userManager;
        //UserManager<ApplicationUser> userManager
        public ValuesController()
        {
            //_userManager = userManager;
        }

        //[HttpGet]
        //[Authorize]
        //// GET api/values
        //public async Task<Object> GetUserProfile()
        //{
        //    string userId = User.Claims.First(c => c.Type == "UserID").Value;
        //    var user = await _userManager.FindByIdAsync(userId);
        //    return new
        //    {
        //        user.Email,
        //        user.UserName,
        //        user.IsActive
        //    };
        //}

        [HttpGet]
       
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "Web method for Admin";
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("ForCustomer")]
        public string GetCustomer()
        {
            return "Web method for Customer";
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Customer")]
        [Route("ForAdminOrCustomer")]
        public string GetForAdminOrCustomer()
        {
            return "Web method for Admin or Customer";
        }
    }
}
