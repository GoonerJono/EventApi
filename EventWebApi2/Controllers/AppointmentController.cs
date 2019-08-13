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
    public class AppointmentController : ControllerBase
    {
        private readonly EventManagerContext _context;

        public AppointmentController(EventManagerContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<List<Appointment>> GetAppointmentsUserId(int userId)
        {
            var userAppointments = await _context.Appointment.Where(u=> u.UserId == userId).ToListAsync();
            return userAppointments == null ? null : userAppointments;
        }

        //[HttpGet("{id}")]
        //public async Task<List<Appointment>> GetAppointmentsConsultantId(int consultantId)
        //{
        //    var consultantAppointments = await _context.Appointment.Where(u => u.UserId == consultantId).ToListAsync();
        //    return consultantAppointments == null ? null : consultantAppointments;
        //}

        [HttpPost]
        public async Task<int> CreateNewAppointment(Appointment appointment)
        {

            _context.Appointment.Add(appointment);
            if (await _context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }

        //[HttpDelete]
        //public async Task<int> DeleteAppointment(int appointmentId)
        //{

        //    _context.Appointment.Remove(appointmentId);
        //    if (await _context.SaveChangesAsync() > 0)
        //    {
        //        return 1;
        //    }
        //    return 0;
        //}


    }
}