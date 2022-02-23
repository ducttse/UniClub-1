using Microsoft.Extensions.DependencyInjection;
using UniClub.Interfaces;
using UniClub.Services.Interfaces;

namespace UniClub.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}
