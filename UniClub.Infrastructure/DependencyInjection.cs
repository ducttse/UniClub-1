using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;
using UniClub.Infrastructure.Identity;
using UniClub.Infrastructure.Persistence;
using UniClub.Infrastructure.Repositories;
using UniClub.Infrastructure.Services;

namespace UniClub.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<UniClubContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(UniClubContext).Assembly.FullName)));


            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<UniClubContext>());

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;
            });

            services
            .AddDefaultIdentity<Person>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<UniClubContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<Person, UniClubContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddTransient<IUniversityRepository, UniversityRepository>();
            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<IClubPeriodRepository, ClubPeriodRepository>();
            services.AddTransient<IClubRoleRepository, ClubRoleRepository>();
            services.AddTransient<IClubTaskRepository, ClubTaskRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostImageRepository, PostImageRepository>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
