﻿using System;
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

        [HttpGet("GetAppointmentsUserId/{id}")]
        public async Task<List<Appointment>> GetAppointmentsUserId(int id)
        {
            var userAppointments = await _context.Appointment.Where(u=> u.UserId == id).ToListAsync();
            return userAppointments == null ? null : userAppointments;
        }

        [HttpGet("GetAppointmentsConsultantId/{id}")]
        public async Task<List<Appointment>> GetAppointmentsConsultantId(int id)
        {
            var consultantAppointments = await _context.Appointment.Where(u => u.UserId == id).ToListAsync();
            return consultantAppointments == null ? null : consultantAppointments;
        }

        [HttpGet("GetAppointment/{id}")]
        public async Task<Appointment> GetAppointment(int id)
        {
            var consultantAppointments = await _context.Appointment.Where(a => a.Id == id).FirstOrDefaultAsync();
            return consultantAppointments == null ? null : consultantAppointments;
        }

        [HttpGet("GetAppointmentDetails/{id}")]
        public async Task<AppointmentDetails> GetAppointmentDetails(int id)
        {
            var consultantAppointments = await _context.Appointment.Where(a => a.Id == id).FirstOrDefaultAsync();
            var organizationDetails = await _context.RegisteredOrganization
                .Where(o => o.Id == consultantAppointments.OrganizationId).FirstAsync();
            var userDetails = await _context.RegisteredUser.Where(u => u.Id == consultantAppointments.UserId).FirstAsync();
            var typeOfServiceDetails = await _context.TypeOfService
                .Where(tos => tos.Id == consultantAppointments.TypeOfServiceId).FirstAsync();
            var consultantDetails = await _context.RegisteredConsultant
                .Where(c => c.Id == consultantAppointments.ConsultantId).FirstAsync();
            var appointmentDetails = new AppointmentDetails
            {
                Id = consultantAppointments.Id,
                Date = consultantAppointments.Date,
                TicketNumber = consultantAppointments.TicketNumber,
                ConsultantNameSurname = $"{consultantDetails.Name} {consultantDetails.Surname} ",
                UserNameSurname = $"{userDetails.Name} {userDetails.Surname} ",
                OrganizationName = organizationDetails.Name,
                TypeOfServiceName = typeOfServiceDetails.Name,
                OrganizationId = organizationDetails.Id
            };
            
            return appointmentDetails == null ? null : appointmentDetails;
        }

        [HttpPost("CreateNewAppointment")]
        public async Task<int> CreateNewAppointment(Appointment appointment)
        {
            try
            {
                var appointmentApproved = CheckAppointment(appointment.OrganizationId, appointment.Date);
                if (appointmentApproved.Equals("yes"))
                {
                    _context.Appointment.Add(appointment);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
                if (!appointmentsTaken.Contains(appointmentDate))
                {
                    var test = "yes";
                    return test;
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


    }
}