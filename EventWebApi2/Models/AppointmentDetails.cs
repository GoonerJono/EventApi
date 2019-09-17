using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventWebApi2.Models
{
    public partial class AppointmentDetails
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public DateTime Date { get; set; }
        public string TypeOfServiceName { get; set; }
        public string OrganizationName { get; set; }
        public string UserNameSurname { get; set; }
        public string ConsultantNameSurname { get; set; }
        public int OrganizationId { get; set; }

    }
}
