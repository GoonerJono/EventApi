using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EventWebApi2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventWebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly EventManagerContext _context;

        public AppointmentController(EventManagerContext context)
        {
            _context = context;
        }

        [HttpGet("GetAppointmentsUserId/{id}")]
        public async Task<List<Appointment>> GetAppointmentsUserId(int id)
        {
            var userAppointments = await _context.Appointment.Where(u=> u.UserId == id && u.Date >= DateTime.Today && u.IsAccepted == true).ToListAsync();
            return userAppointments == null ? null : userAppointments;
        }

        [HttpGet("GetAppointmentsConsultantId/{id}")]
        public async Task<List<Appointment>> GetAppointmentsConsultantId(int id)
        {
            var consultantAppointments = await _context.Appointment.Where(u => u.UserId == id && u.IsAccepted == true).ToListAsync();
            return consultantAppointments == null ? null : consultantAppointments;
        }

        [HttpGet("GetAppointment/{id}")]
        public async Task<Appointment> GetAppointment(int id)
        {
            var consultantAppointments = await _context.Appointment.Where(a => a.Id == id && a.IsAccepted == true).FirstOrDefaultAsync();
            return consultantAppointments == null ? null : consultantAppointments;
        }

        [HttpGet("GetRejectedAppointmentByUserId/{id}")]
        public async Task<List<AppointmentDetails>> GetRejectedAppointmentByUserId(int id)
        {
            var rejectedAppointments = await _context.Appointment.Where(a => a.UserId == id && a.IsRejected == true).Select(a=> new AppointmentDetails
            {
                Id = a.Id,
                Date = a.Date,
                OrganizationId = a.OrganizationId,
                ConsultantNameSurname = $"{a.Consultant.Name} {a.Consultant.Surname}",
                OrganizationName = a.Organization.Name,
                TicketNumber = a.TicketNumber,
                TypeOfServiceName = a.TypeOfService.Name,
                UserNameSurname = $"{a.User.Name} {a.User.Surname}",
                Reason =  a.AppointmentRejection.Where(b=> b.AppointmentId == a.Id).Select(c => c.Reason).FirstOrDefault()
            }).ToListAsync();
            return rejectedAppointments == null ? null : rejectedAppointments;
        }

        [HttpGet("GetAppointmentDetails/{id}")]
        public async Task<AppointmentDetails> GetAppointmentDetails(int id)
        {
           var appointmentDetails = await _context.Appointment.Where(a => a.Id == id && a.IsAccepted == true).Select(a =>  
           new AppointmentDetails
            {
                Id = a.Id,
                Date = a.Date,
                TicketNumber = a.TicketNumber,
                ConsultantNameSurname = $"{a.Consultant.Name} {a.Consultant.Surname} ",
                UserNameSurname = $"{a.User.Name} {a.User.Surname} ",
                OrganizationName = a.Organization.Name,
                TypeOfServiceName = a.TypeOfService.Name,
                OrganizationId = a.OrganizationId,
                Reason = a.Reason
            }).FirstOrDefaultAsync();
            
            return appointmentDetails == null ? null : appointmentDetails;
        }

        [HttpPost("CreateNewAppointment")]
        public async Task<int> CreateNewAppointment(Appointment appointment)
        {
                var appointmentApproved = CheckAppointment(appointment.OrganizationId, appointment.Date);
                if (appointmentApproved.Equals("yes"))
                {
                    var ticketNumber = CreateTicket(appointment.OrganizationId);
                    appointment.TicketNumber = ticketNumber;
                    _context.Appointment.Add(appointment);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return 1;
                    }
                }
                else if (appointmentApproved.Equals("Time slot Taken"))
                {
                    return 2;
                }
                   return 3;
                
        }

        private string CreateTicket(int organizationId)
        {
            Random random = new Random();
            var organizationName = _context.RegisteredOrganization.Where(o => o.Id == organizationId)
                .Select(o => o.Name).First();
            var ticketNumber = organizationName[0]+ $"{random.Next(0,1000)}";
            var appointmentsTickets = _context.Appointment.Where(o => o.OrganizationId == organizationId)
                .Select(a => a.TicketNumber).ToList();
            if (!appointmentsTickets.Contains(ticketNumber))
            {
                return ticketNumber;
            }
            else
            {
               ticketNumber = organizationName[0] + $"{random.Next(1)}";
                return ticketNumber;
            }
            
        }

        private string CheckAppointment(int appointmentOrganizationId, DateTime appointmentDate)
        {
            var organizationTimeDay =
                _context.OrganizationTimes.First(o => o.OrganizationId == appointmentOrganizationId);

           var startDayOfWeek = GetDayOfTheWeek(organizationTimeDay.OrganizationStartDay);
           var endDayOfWeek = GetDayOfTheWeek(organizationTimeDay.OrganizationEndDay);

            if (appointmentDate.DayOfWeek >= startDayOfWeek && appointmentDate.DayOfWeek <= endDayOfWeek && appointmentDate.TimeOfDay >= organizationTimeDay.OpenTime && appointmentDate.TimeOfDay < organizationTimeDay.CloseTime)
            {
                var appointmentsTaken = _context.Appointment.Where(o => o.OrganizationId == appointmentOrganizationId)
                    .Select(a => a.Date).ToList();
                var listofHours = new List<string>();
                foreach (var AppointmentTime in appointmentsTaken)
                {
                    
                    var hour = AppointmentTime.ToString("MM/dd/yyyy HH:mm");
                    listofHours.Add(hour);
                   
                }
                if (!listofHours.Contains(appointmentDate.ToString("MM/dd/yyyy HH:mm")))
                {
                    return "yes";
                }
                return "Time slot Taken";
            }
            else
            {
                return "Out side of business hours";
            }
        }

        private DayOfWeek GetDayOfTheWeek(string businessDay)
        {
            DayOfWeek dayOfWeek = DayOfWeek.Friday;
            switch (businessDay)
            {
                case "Monday":
                    dayOfWeek = DayOfWeek.Monday;
                    break;
                case "Tuesday":
                    dayOfWeek = DayOfWeek.Tuesday;
                    break;
                case "Wednesday":
                    dayOfWeek = DayOfWeek.Wednesday;
                    break;
                case "Thursday":
                    dayOfWeek = DayOfWeek.Thursday;
                    break;
                case "Friday":
                    dayOfWeek = DayOfWeek.Friday;
                    break;
                case "Saturday":
                    dayOfWeek = DayOfWeek.Saturday;
                    break;
                case "Sunday":
                    dayOfWeek = DayOfWeek.Sunday;
                    break;
                default:
                    Console.WriteLine("No match found");
                    break;
            }

            return dayOfWeek;
        }

        [HttpDelete("DeleteAppointment")]
        public async Task<int> DeleteAppointment(int appointmentId)
        {
            var appointment = await _context.Appointment.FindAsync(appointmentId);
            _context.Appointment.Remove(appointment);
            if (await _context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }

        private async Task SendEmail(int consultantId, int userId)
        {
            var consultantDetails = await _context.RegisteredConsultant.Where(c => c.Id == consultantId).FirstAsync();
            var userDetails = await _context.RegisteredUser.Where(u => u.Id == userId).FirstAsync();
            MailMessage mm = new MailMessage();
            var body = await _context.EmailTemplate.Where(e => e.Id == 1).Select(e => e.EmailTemplate1).FirstAsync();
            var body2 = body.Replace("{UserEmail}", userDetails.Email);
            var body3 = body2.Replace("{userId}", userDetails.Id.ToString());
            mm.To.Add(consultantDetails.Email);
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

        [HttpGet("AcceptAppointment/{id}")]
        public async Task<string> AcceptAppointment(int id)
        {
            var appointmentDetails = await _context.Appointment.FindAsync(id);
            appointmentDetails.IsAccepted = true;
            appointmentDetails.IsRejected = false;
            _context.Appointment.Update(appointmentDetails);
            if (await _context.SaveChangesAsync() > 0)
            {
                return "Appointment Accepted";
            }
            return "Appointment Not Accepted";
        }

        [HttpGet("DeclineAppointment/{id}")]
        public async Task<string> DeclineAppointment(int id)
        {
            var appointmentDetails = await _context.Appointment.FindAsync(id);
            appointmentDetails.IsAccepted = false;
            appointmentDetails.IsRejected = true;
            _context.Appointment.Update(appointmentDetails);
            if (await _context.SaveChangesAsync() > 0)
            {
                return "Appointment Declined";
            }
            return "Appointment Not Declined";
        }
    }
}