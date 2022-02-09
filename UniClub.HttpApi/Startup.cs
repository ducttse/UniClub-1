using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using UniClub.Application;
using UniClub.Application.Common.Interfaces;
using UniClub.HttpApi.Filters;
using UniClub.HttpApi.Helper;
using UniClub.HttpApi.Services;
using UniClub.Infrastructure;

namespace UniClub.HttpApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            })
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniClub.HttpApi", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniClub.HttpApi v1"));
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "AdminAreaRoute",
        areaName: "Admin",
        pattern: "admin/{controller:slugify=Dashboard}/{action:slugify=Index}/{id:slugify?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller:slugify}/{action:slugify}/{id:slugify?}",
        defaults: new { controller = "Home", action = "Index" });
});
        }
    }
}
