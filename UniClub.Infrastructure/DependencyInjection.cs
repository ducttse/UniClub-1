﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;
using UniClub.Infrastructure.Identity;
using UniClub.Infrastructure.Persistence;
using UniClub.Infrastructure.Repository;
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


            services
            .AddDefaultIdentity<Person>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<UniClubContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<Person, UniClubContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddTransient<IUniversityRepository, UniversityRepository>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
