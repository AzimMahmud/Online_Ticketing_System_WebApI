﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.API.DTOs
{
    public class CreateRoleDTO
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
