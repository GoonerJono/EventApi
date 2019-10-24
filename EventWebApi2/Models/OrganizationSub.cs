using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class OrganizationSub
    {
        public int Id { get; set; }
        public int OrganisationId { get; set; }
        public int SubscriptionType { get; set; }
        public bool IsPaid { get; set; }

        public RegisteredOrganization Organisation { get; set; }
    }
}
