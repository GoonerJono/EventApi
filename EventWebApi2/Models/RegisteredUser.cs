using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class RegisteredUser
    {
        public RegisteredUser()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int CellphoneNumber { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
