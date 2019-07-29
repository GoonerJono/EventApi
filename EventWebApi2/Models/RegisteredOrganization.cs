using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class RegisteredOrganization
    {
        public RegisteredOrganization()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Address { get; set; }
        public string Hours { get; set; }
        public int PhoneNumber { get; set; }
        public int TypeOfServiceId { get; set; }

        public TypeOfService TypeOfService { get; set; }
        public ICollection<Appointment> Appointment { get; set; }
    }
}
