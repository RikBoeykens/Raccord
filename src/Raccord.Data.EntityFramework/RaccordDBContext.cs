using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.ScriptLocations;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Raccord.Domain.Model.Users;
using Raccord.Domain.Model.Callsheets.CallTypes;

namespace Raccord.Data.EntityFramework
{
    public class RaccordDBContext : IdentityDbContext<ApplicationUser>
    {
        public RaccordDBContext(DbContextOptions<RaccordDBContext> options)
            : base(options)
        { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<ScriptLocation> ScriptLocations { get; set; }
        public DbSet<IntExt> IntExts { get; set; }
        public DbSet<DayNight> DayNights { get; set; }
        public DbSet<BreakdownTypeDefinition> BreakdownTypeDefinitions { get; set; }
        public DbSet<CallTypeDefinition> CallTypeDefinitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Scene>()
                        .HasOne(s => s.ScriptLocation)
                        .WithMany(l => l.Scenes)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Scene>()
                        .HasOne(s => s.IntExt)
                        .WithMany(l => l.Scenes)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Scene>()
                        .HasOne(s => s.DayNight)
                        .WithMany(l => l.Scenes)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
