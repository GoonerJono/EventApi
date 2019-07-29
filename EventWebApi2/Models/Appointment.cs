using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public DateTime Date { get; set; }
        public int TypeOfServiceId { get; set; }
        public int OrganizationId { get; set; }
        public int UserId { get; set; }
        public int ConsultantId { get; set; }

        public RegisteredOrganization Consultant { get; set; }
        public TypeOfService TypeOfService { get; set; }
        public RegisteredUser User { get; set; }
    }
}
