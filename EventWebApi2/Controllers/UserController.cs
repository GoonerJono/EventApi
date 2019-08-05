using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventWebApi2.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventWebApi2.Controllers
{
    [EnableCors]
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
        [HttpPost]
        public async Task CreateNewClient(RegisteredUser registeredUser)
        {
            _context.RegisteredUser.Add(registeredUser);
            await _context.SaveChangesAsync();
        }

        //GET: api/user/user
        [HttpGet("user")]
        public int Login(RegisteredUser user)
        {
            int id =  _context.RegisteredUser.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password).Id;
            return id;
        }


    }
}