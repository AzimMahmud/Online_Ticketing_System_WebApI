using System;

namespace BusTicket.API.DTOs
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public string Address { get; set; }
 
        public bool Status { get; set; }

    }
}