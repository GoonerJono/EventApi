using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class OrganizationDetails
    {
        public int OrganizationId { get; set; }
        public TimeSpan? OpenTime { get; set; }
        public TimeSpan? CloseTime { get; set; }
        public string OrganizationStartDay { get; set; }
        public string OrganizationEndDay { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int TypeOfServiceId { get; set; }
        public bool? IsVerified { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string Province { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

    }
}
