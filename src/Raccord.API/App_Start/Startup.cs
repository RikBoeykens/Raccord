using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Raccord.Data.EntityFramework;
using Raccord.Data.EntityFramework.Seeding;
using Raccord.Domain.Model.Users;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Identity;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;

namespace Raccord.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddCors();
            
            services.AddMvc();

                        //Get Database Connection 
            string _connectionString = Configuration["DATABASE_URL"];
            _connectionString.Replace("//", "");

            char[] delimiterChars = { '/', ':', '@', '?' };
            string[] strConn = _connectionString.Split(delimiterChars);
            strConn = strConn.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            var user = strConn[1];
            var pass = strConn[2];
            var server = strConn[3];
            var database = strConn[5];
            var port = strConn[4];
            var connectionString = "host=" + server + ";port=" + port + ";database=" + database + ";uid=" + user + ";pwd=" + pass + ";sslmode=Require;Trust Server Certificate=true;Timeout=1000";

            services.AddDbContext<RaccordDBContext>(opts =>{ 
                opts.UseNpgsql(connectionString);
                
                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need
                // to replace the default OpenIddict entities.
                opts.UseOpenIddict();
            });

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
                //options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });
 
            // Register the OpenIddict services.
            services.AddOpenIddict()
                // Register the Entity Framework stores.
                .AddEntityFrameworkCoreStores<RaccordDBContext>()
 
                // Register the ASP.NET Core MVC binder used by OpenIddict.
                // Note: if you don't call this method, you won't be able to
                // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
                .AddMvcBinders()
 
                // Enable the token endpoint.
                .EnableTokenEndpoint("/api/authorization/connect/token")
 
                // Enable the password flow.
                .AllowPasswordFlow()
 
                // During development, you can disable the HTTPS requirement.
                .DisableHttpsRequirement();

            DependencyInjection.ConfigureServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Raccord", Version = "v1" });
            });

            services.ConfigureSwaggerGen(options=>
            {
                options.CustomSchemaIds(x=> x.FullName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, RaccordDBContextSeeding seeding)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Add a middleware used to validate access
            // tokens and protect the API endpoints.
            app.UseOAuthValidation();
 
            // Alternatively, you can also use the introspection middleware.
            // Using it is recommended if your resource server is in a
            // different application/separated from the authorization server.
            //
            // app.UseOAuthIntrospection(options =>
            // {
            //     options.AutomaticAuthenticate = true;
            //     options.AutomaticChallenge = true;
            //     options.Authority = "http://localhost:58795/";
            //     options.Audiences.Add("resource_server");
            //     options.ClientId = "resource_server";
            //     options.ClientSecret = "875sqd4s5d748z78z7ds1ff8zz8814ff88ed8ea4z4zzd";
            // });

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:5000", "http://localhost:3000", "http://raccord-ui-poc.herokuapp.com")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
            );

            app.UseOpenIddict();

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
