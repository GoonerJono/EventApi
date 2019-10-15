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
        public async Task<string> CreateNewUser(RegisteredUser registeredUser)
        {
         var userId = _context.RegisteredUser.Add(registeredUser);
          if (await _context.SaveChangesAsync() > 0)
           {
             MailMessage mm = new MailMessage();
             mm.To.Add("jsabate014@gmail.com");
             mm.From = new MailAddress("mail@dynamicprogrammers.co.za");
             mm.Body =
                 $"Verification link : http://dynamicprogrammers.co.za/api/User/VerifyUserDetails/{userId.Entity.Id}";
             // mm.Body = $"Verification link : https://localhost:44346/api/User/VerifyUserDetails/{userId.Entity.Id}";
             mm.Subject = "Verification";
             SmtpClient smcl = new SmtpClient();
             smcl.Credentials = new NetworkCredential("mail@dynamicprogrammers.co.za", "Gooner1478@#");
             smcl.Host = "bl4n1.zadns.co.za";
             smcl.Port = 25;
             smcl.EnableSsl = true;
             smcl.Send(mm);
             return "Registered";
                // var email = "mail@dynamicprogrammers.co.za";
           }
           return "Not Registered";
        }

        [HttpGet("VerifyUserDetails/{id}")]
        public async Task<string> VerifyUserDetails(int id)
        {
            var userDetails = await _context.RegisteredUser.FindAsync(id);
            userDetails.IsVerified = true;
             _context.RegisteredUser.Update(userDetails);
             if (await _context.SaveChangesAsync() > 0)
             {
                 return "User is verified";
             }
             return "User was not verified";
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