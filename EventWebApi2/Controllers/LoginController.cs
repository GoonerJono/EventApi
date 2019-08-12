using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventWebApi2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventWebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EventManagerContext _context;

        public LoginController(EventManagerContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<int> Login(RegisteredUser registeredUser)
        {

            var userid = await _context.RegisteredUser
                .Where(r => r.Username == registeredUser.Username && r.Password == registeredUser.Password)
                .Select(r => r.Id).FirstOrDefaultAsync();
            if (userid == 0)
            {
                return 0;
            }
            return Convert.ToInt32(userid);
        }

    }
}