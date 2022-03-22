using FirebaseAdmin;
using FluentValidation.AspNetCore;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.IO;
using UniClub.Application;
using UniClub.Application.Interfaces;
using UniClub.Commands;
using UniClub.EntityFrameworkCore;
using UniClub.Helper.KebabCase;
using UniClub.HttpApi.Filters;
using UniClub.HttpApi.Middlewares;
using UniClub.HttpApi.Services;
using UniClub.HttpApi.Utils;
using UniClub.Queries;
using UniClub.Services.Interfaces;

namespace UniClub.HttpApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkCore(Configuration);
            services.AddApplication();
            //services.AddRedis(Configuration);
            //services.AddWorkers();
            services.AddMediaRCommands();
            services.AddMediaRQueries();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            })
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IFireBaseRegisterService, FireBaseRegisterService>();
            services.AddHttpContextAccessor();

            string rootPath;
            if (!string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("HOME")))

                rootPath = Path.Combine(System.Environment.GetEnvironmentVariable("HOME"), "site", "wwwroot");
            else
                rootPath = ".";

            string firebaseSdkPath = Path.Combine(rootPath, Configuration["Firebase:FileOptions"]);

            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(firebaseSdkPath)
            });

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new KebabCaseNamingStrategy()
                    };
                });

            services.AddSwaggerGenNewtonsoftSupport();

            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<KebabCasingParamOperationFilter>();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniClub.HttpApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
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

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
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
            app.UseMiddleware<JwtMiddleware>();
            app.UseCors();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller:slugify}/{action:slugify}/{id:slugify?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
