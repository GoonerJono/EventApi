using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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

        [HttpGet("GetUserDetails/{id}")]
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
             MailMessage mm = new MailMessage();
             mm.To.Add("jsabate014@gmail.com");
             mm.From = new MailAddress("mail@dynamicprogrammers.co.za");
             mm.Body = "Test";
             mm.Subject = "Verification";
             SmtpClient smcl = new SmtpClient();
             smcl.Credentials = new NetworkCredential("mail@dynamicprogrammers.co.za", "Gooner1478@#");
             smcl.Host = "bl4n1.zadns.co.za";
             smcl.Port = 25;
             smcl.EnableSsl = true;
             smcl.Send(mm);
             return 1;
                // var email = "mail@dynamicprogrammers.co.za";
           }
           return 0;
        }

        [HttpPut("UpdateUser")]
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