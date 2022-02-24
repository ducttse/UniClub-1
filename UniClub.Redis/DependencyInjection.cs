using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniClub.Application.Interfaces;

namespace UniClub.Redis
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            if (!bool.TryParse(configuration.GetSection("Redis").GetSection("IsEnabled").Value, out bool isEnabled))
            {
                var redisCacheSettings = new RedisCacheSettings()
                {
                    ConnectionString = configuration.GetSection("Redis").GetSection("ConnectionString").Value,
                    IsEnabled = isEnabled
                };

                services.AddSingleton(redisCacheSettings);

                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = configuration.GetSection("Redis").GetSection("ConnectionString").Value;
                });

                services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            }

            return services;

        }
    }
}
