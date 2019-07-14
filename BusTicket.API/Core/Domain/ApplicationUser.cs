using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Identity;

namespace BusTicket.API.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        
        public string Gender { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime LeavingDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public bool IsActive { get; set; }

       
    }
}