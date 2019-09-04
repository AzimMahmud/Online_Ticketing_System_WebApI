using System;
using System.Collections.Generic;
using BusTicket.API.Core.Domain;


namespace BusTicket.API.DTOs
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }

        
    }
}