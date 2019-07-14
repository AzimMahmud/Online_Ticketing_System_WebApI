﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;
using BusTicket.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BusTicket.API.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BusTicketContext _context;

        public AuthRepository(BusTicketContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username && x.PasswordHash == password);

            if (user == null)
                return null;

            // if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //     return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        public async Task<User> Register(User user, string password)
        {
            //byte[] passwordHash, passwordSalt;
            //CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //user.PasswordHash = passwordHash.ToString();
            //await _context.Users.AddAsync(user);

            //await _context.SaveChangesAsync();
            
        

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.UserName == username))
                return true;

            return false;
        }
    }
}
