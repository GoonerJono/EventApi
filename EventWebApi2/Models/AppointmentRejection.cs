using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class AppointmentRejection
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Reason { get; set; }

        public Appointment Appointment { get; set; }
    }
}
