﻿using System;
using System.Collections.Generic;

namespace EventWebApi2.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}