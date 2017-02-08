using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Raccord.Data.EntityFramework;
using Raccord.Data.EntityFramework.Seeding;

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

            var connectionString = Configuration["DbContextSettings:ConnectionString"];
            services.AddDbContext<RaccordDBContext>(
                opts => opts.UseNpgsql(connectionString)
            );

            DependencyInjection.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<RaccordDBContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetService<RaccordDBContext>().EnsureSeedData();
            }

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:5000", "http://localhost:3000")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
            );

            app.UseMvc();
        }
    }
}
