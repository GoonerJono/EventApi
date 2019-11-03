using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class Subscription
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int? Premium { get; set; }
    }
}
