using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class TypeOfService
    {
        public TypeOfService()
        {
            Appointment = new HashSet<Appointment>();
            RegisteredOrganization = new HashSet<RegisteredOrganization>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
        public ICollection<RegisteredOrganization> RegisteredOrganization { get; set; }
    }
}
