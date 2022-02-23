using Microsoft.Extensions.DependencyInjection;
using UniClub.Application.Interfaces;

namespace UniClub.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            return services;
        }
    }
}
