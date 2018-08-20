using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Raccord.API.Options;
using Raccord.Core.Options;
using Raccord.Data.EntityFramework;
using Raccord.Data.EntityFramework.Seeding;
using Raccord.Domain.Model.Users;
using Raccord.UI.Helpers;
using Swashbuckle.AspNetCore.Swagger;

namespace Raccord.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var appEnv = PlatformServices.Default.Application;
            ApplicationBasePath = appEnv.ApplicationBasePath;
            ConfigPath = Path.Combine(env.ContentRootPath, "_config");

            var builder = new ConfigurationBuilder()
                .SetBasePath(ConfigPath)
                .AddJsonFile("app.json")
                .AddJsonFile($"app.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }
        public string ApplicationBasePath { get; private set; }
        public string ConfigPath { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DbContextSettings>(Configuration.GetSection("DbContextSettings"));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.Configure<UISettings>(Configuration.GetSection("UISettings"));
            services.Configure<GeocodingSettings>(Configuration.GetSection("GeocodingSettings"));
            services.Configure<WeatherSettings>(Configuration.GetSection("WeatherSettings"));
            // Add framework services.
            var dbConfig = Configuration.GetSection("DbContextSettings");
            var connectionUri = Configuration["DATABASE_URL"];
            if(string.IsNullOrEmpty(connectionUri))
            {
                connectionUri = dbConfig.GetValue<string>("ConnectionUri");
            }
            var connectionString = string.IsNullOrEmpty(connectionUri) ? dbConfig.GetValue<string>("ConnectionString") : DbSettingsHelpers.GetConnectionString(connectionUri);
            services.AddDbContext<RaccordDBContext>(opts =>{ 
                opts.UseNpgsql(connectionString);
                
                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need
                // to replace the default OpenIddict entities.
                opts.UseOpenIddict();
            });


            // Register the Identity services.
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<RaccordDBContext>()
                .AddDefaultTokenProviders();

            // Configure Identity to use the same JWT claims as OpenIddict instead
            // of the legacy WS-Federation claims it uses by default (ClaimTypes),
            // which saves you from doing the mapping in your authorization controller.
            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                        .UseDbContext<RaccordDBContext>();
                })
                .AddServer(options =>
                {
                    options.UseMvc();
                    options.EnableTokenEndpoint("/api/authorization/connect/token");
                    options.AllowPasswordFlow();
                    options.AllowRefreshTokenFlow();
                    options.AcceptAnonymousClients();
                    options.DisableHttpsRequirement();
                });

            // Register the validation handler that is used to decrypt the tokens
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = 
                        OAuthValidationDefaults.AuthenticationScheme;
                })
                .AddOAuthValidation();

            DependencyInjection.ConfigureServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Raccord", Version = "v1" });
            });

            services.ConfigureSwaggerGen(options=>
            {
                options.CustomSchemaIds(x=> x.FullName);
            });
            services.AddCors();
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, RaccordDBContextSeeding seeding)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseAuthentication();

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:3000", "http://raccord-ui-poc.herokuapp.com")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
            );

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Raccord V1");
            });
 
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var raccordDbContext = serviceScope.ServiceProvider.GetService<RaccordDBContext>();
                raccordDbContext.Database.Migrate();
            }

            seeding.EnsureSeedData();

            app.UseMvc();
        }
    }
}
