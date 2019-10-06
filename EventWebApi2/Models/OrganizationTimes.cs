using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class OrganizationTimes
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public TimeSpan? OpenTime { get; set; }
        public TimeSpan? CloseTime { get; set; }
        public string OrganizationStartDay { get; set; }
        public string OrganizationEndDay { get; set; }

        public RegisteredOrganization Organization { get; set; }
    }
}
