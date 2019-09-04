using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace BusTicket.API.Helper
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("mahamud@gmai.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = "Admin",
                    Email = "mahmud@gmail.com",
                    PhoneNumber = "01742793518"
                };

                IdentityResult result = userManager.CreateAsync(user, "Admin@123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
