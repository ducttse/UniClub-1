﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniClub.Application.Common.Interfaces
{
    public interface IResponseCacheService 
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);

        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}