﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniClub.Infrastructure.Settings
{
    public class RedisCacheSettings
    {
        public bool Enabled { get; set; }
        public string ConnectionString { get; set; }
    }
}
