﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
        public string Password { get; set; }

        [Required]
        public string Gender { get; set; }


        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string JoiningDate { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime Created { get; set; }
        public bool Status { get; set; }


        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            
        }
    }
}
