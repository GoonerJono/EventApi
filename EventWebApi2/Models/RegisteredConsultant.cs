﻿using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class RegisteredConsultant
    {
        public RegisteredConsultant()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public int? OrganisationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
