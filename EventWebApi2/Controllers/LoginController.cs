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

            var userid =  _context.RegisteredUser.Where(r => r.Username == registeredUser.Username && r.Password == registeredUser.Password).Select(r=> r.Id);
            return Convert.ToInt32(userid);
        }

    }
}