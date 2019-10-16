using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EventWebApi2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
            var userNames = await _context.RegisteredUser.Select(u=> u.Username).ToListAsync();
            var userEmail = await _context.RegisteredUser.Select(u=> u.Email).ToListAsync();
            if (!userNames.Contains(registeredUser.Username) && !userEmail.Contains(registeredUser.Email))
            {
                var userId = _context.RegisteredUser.Add(registeredUser);
                if (await _context.SaveChangesAsync() > 0)
                {
                    SendVerificationEmail(registeredUser, userId);
                    return 1;
                }
                return 0;
            }

            return 2;
        }

        private void SendVerificationEmail(RegisteredUser registeredUser, EntityEntry<RegisteredUser> userId)
        {
            MailMessage mm = new MailMessage();
            var body =  _context.EmailTemplate.Where(e => e.Id == 1).Select(e => e.EmailTemplate1).First();
           var body2 = body.Replace("{UserEmail}", registeredUser.Email);
           var body3 = body2.Replace("{userId}", userId.Entity.Id.ToString());
            mm.To.Add(registeredUser.Email);
            mm.From = new MailAddress("mail@dynamicprogrammers.co.za");
            mm.Body = body3;
             //   $"Verification link : http://dynamicprogrammers.co.za/api/User/VerifyUserDetails/{userId.Entity.Id}";
            // mm.Body = $"Verification link : https://localhost:44346/api/User/VerifyUserDetails/{userId.Entity.Id}";
            mm.IsBodyHtml = true;
            mm.Subject = "Verification";
            SmtpClient smcl = new SmtpClient();
            smcl.Credentials = new NetworkCredential("mail@dynamicprogrammers.co.za", "Gooner1478@#");
            smcl.Host = "bl4n1.zadns.co.za";
            smcl.Port = 25;
            smcl.EnableSsl = true;
            smcl.Send(mm);
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