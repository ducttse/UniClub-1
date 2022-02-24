using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniClub.Redis
{
    public class RedisCacheSettings
    {
        public bool IsEnabled { get; set; }
        public string ConnectionString { get; set; }
    }
}
