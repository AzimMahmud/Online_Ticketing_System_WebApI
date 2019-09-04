using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Identity;

namespace BusTicket.API.Core.Domain
{
    public class User : IdentityUser<int>
    {
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}