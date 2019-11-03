using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class Orgtotaltickets
    {
        public int Id { get; set; }
        public string Orgname { get; set; }
        public int Totaltickets { get; set; }
    }
}
