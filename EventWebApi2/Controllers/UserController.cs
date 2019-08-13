﻿using System.Threading.Tasks;
using EventWebApi2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventWebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EventManagerContext _context;

        public UserController(EventManagerContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<RegisteredUser> GetUserDetails(int id)
        { 
            var user = await _context.RegisteredUser.FindAsync(id);
            return user == null ? null : user;
        }

        [HttpPost]
        public async Task<int> CreateNewUser(RegisteredUser registeredUser)
        {

            _context.RegisteredUser.Add(registeredUser);
            if (await _context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }

        [HttpPut]
        public async Task<int> UpdateUser(RegisteredUser registeredUser)
        {

            _context.RegisteredUser.Update(registeredUser);
            if (await _context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}