using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using BusTicket.API.DTOs;
using BusTicket.API.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BusTicket.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singInManager;
        private readonly IMapper _mapper;
        private readonly ApplicationSettings _appSettings;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings, IMapper mapper)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(ApplicationUserDTO model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                JoiningDate = model.JoiningDate,
                Gender = model.Gender,
                Address = model.Address,
                Designation = model.Designation
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //Get role assigned to the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }

    }
}
