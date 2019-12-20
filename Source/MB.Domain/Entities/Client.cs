﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Entities
{
    public class Client : BaseEntity<int>
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public Account Account { get; set; }
    }
}