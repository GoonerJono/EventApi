using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class Balancehistory
    {
        public int Id { get; set; }
        public string Id2 { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string Amount { get; set; }
        public string Fee { get; set; }
        public string Net { get; set; }
        public string Currency { get; set; }
        public string Created { get; set; }
        public string Available { get; set; }
    }
}
