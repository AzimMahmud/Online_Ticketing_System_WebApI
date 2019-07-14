using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BusTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public ValuesController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.Email,
                user.UserName,
                user.IsActive
            };
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
