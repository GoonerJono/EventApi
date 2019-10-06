using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class RegisteredOrganization
    {
        public RegisteredOrganization()
        {
            Appointment = new HashSet<Appointment>();
            OrganizationTimes = new HashSet<OrganizationTimes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int TypeOfServiceId { get; set; }
        public bool? IsVerified { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public int ProvinceId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public Province Province { get; set; }
        public TypeOfService TypeOfService { get; set; }
        public ICollection<Appointment> Appointment { get; set; }
        public ICollection<OrganizationTimes> OrganizationTimes { get; set; }
    }
}
