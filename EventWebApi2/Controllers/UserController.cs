using System;
using System.Collections.Generic;
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
                    await SendVerificationEmail(registeredUser, userId);
                    return 1;
                }
                return 0;
            }

            return 2;
        }

        private async Task SendVerificationEmail(RegisteredUser registeredUser, EntityEntry<RegisteredUser> userId)
        {
            MailMessage mm = new MailMessage();
            var body = await GetBody(userId);
            mm.To.Add(registeredUser.Email);
            mm.From = new MailAddress("dynamicp@dynamicprogrammers.co.za");
            mm.Body = body;
             //   $"Verification link : http://dynamicprogrammers.co.za/api/User/VerifyUserDetails/{userId.Entity.Id}";
            // mm.Body = $"Verification link : https://localhost:44346/api/User/VerifyUserDetails/{userId.Entity.Id}";
            mm.IsBodyHtml = true;
            mm.Subject = "Verification";
            SmtpClient smcl = new SmtpClient();
            smcl.Credentials = new NetworkCredential("dynamicp@dynamicprogrammers.co.za", "Gooner1478@#");
            smcl.Host = "bl4n2.zadns.co.za";
            smcl.Port = 25;
            smcl.EnableSsl = true;
            smcl.Send(mm);
        }

        [HttpGet("VerifyUserDetails/{id}")]
        public async Task<string> VerifyUserDetails(int id)
        {
            var userDetails = await _context.RegisteredUser.FindAsync(id);
            if(userDetails.IsVerified != true)
            {
                userDetails.IsVerified = true;
                _context.RegisteredUser.Update(userDetails);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return "User is verified";
                }
            }else
            {
                return "User is already Verified";
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

        private async Task<string> GetBody(EntityEntry<RegisteredUser> userId)
        {
            var body = await _context.EmailTemplate.Where(e => e.Id == 1).Select(a => a.EmailTemplate1).FirstOrDefaultAsync();
            var userDetails = await _context.RegisteredUser.Where(a => a.Id == (int)userId.Entity.Id).Select(a => new RegisteredUser
            {
                Id = a.Id,
                Name = a.Name,
                Surname = a.Surname,
                Email = a.Email
            }).FirstOrDefaultAsync();
            var emailTokens = new Dictionary<string, string>()
            {
                ["{useremail}"] = userDetails.Email,
                ["{username}"] = $"{userDetails.Name} {userDetails.Surname}",
                ["{userId}"] = userDetails.Id.ToString()
                
            };
            foreach (var token in emailTokens) body = body.Replace($"{token.Key}", token.Value);

            return body;
        }
    }
}