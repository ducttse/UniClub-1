using FirebaseAdmin;
using FluentValidation.AspNetCore;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.IO;
using UniClub.Application;
using UniClub.Application.Common.Interfaces;
using UniClub.HttpApi.Filters;
using UniClub.HttpApi.Helper.KebabCase;
using UniClub.HttpApi.Helpers.KebabCase;
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

            //FirebaseApp.Create(new AppOptions
            //{
            //    Credential = GoogleCredential.FromFile(Path.Combine(Directory.GetCurrentDirectory(), Configuration.GetSection("Firebase").GetSection("FileOptions").Value))
            //});

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(opt =>
            //    {
            //        opt.Authority = Configuration["Jwt:Firebase:ValidIssuer"];
            //        opt.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = Configuration.GetSection("Jwt").GetSection("Firebase").GetSection("ValidIssuer").Value,
            //            ValidAudience = Configuration.GetSection("Jwt").GetSection("Firebase").GetSection("ValidAudience").Value
            //        };
            //    });

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new Helper.KebabCase.KebabCaseNamingStrategy()
                    };
                });

            services.AddSwaggerGenNewtonsoftSupport();

            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<KebabCasingParamOperationFilter>();
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
            var options = new RewriteOptions().Add(new ConvertKebabParameterToPascalCaseRule());
            app.UseRewriter(options);
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniClub.HttpApi v1"));
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();
            //app.UseAuthentication();
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
