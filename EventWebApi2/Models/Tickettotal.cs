using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class Tickettotal
    {
        public int Ticketid { get; set; }
        public int? Orgid { get; set; }
        public int? Total { get; set; }
        public int? Missed { get; set; }
        public DateTime Date { get; set; }
    }
}
