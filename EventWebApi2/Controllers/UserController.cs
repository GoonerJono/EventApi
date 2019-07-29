using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventWebApi2.Models;
using Microsoft.AspNetCore.Http;
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
        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<RegisteredUser>GetUserById (int id)
        {
            var user = await _context.RegisteredUser.FindAsync(id);
            return user;
        }

        // PUT: api/user/
        [HttpPut("{registeredUser}")]
        public async Task CreateNewClient(RegisteredUser registeredUser)
        {
            _context.RegisteredUser.Add(registeredUser);
            await _context.SaveChangesAsync();
        }
    }
}