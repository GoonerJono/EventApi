using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class Province
    {
        public Province()
        {
            RegisteredOrganization = new HashSet<RegisteredOrganization>();
        }

        public int Id { get; set; }
        public string ProvinceName { get; set; }

        public ICollection<RegisteredOrganization> RegisteredOrganization { get; set; }
    }
}
