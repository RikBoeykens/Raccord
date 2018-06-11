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
using Raccord.Domain.Model.Callsheets.Scenes;
using Raccord.Domain.Model.Crew.Departments;
using Raccord.Domain.Model.Users.ProjectRoles;
using Raccord.Domain.Model.Callsheets;
using Raccord.Domain.Model.ShootingDays;
using Raccord.Domain.Model.ShootingDays.Scenes;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.Cast;
using Raccord.Domain.Model.Users.Invitations;

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
        public DbSet<CrewDepartmentDefinition> CrewDepartmentDefinitions { get; set; }
        public DbSet<ProjectRoleDefinition> ProjectRoleDefinitions { get; set; }
        public DbSet<ProjectPermissionDefinition> ProjectPermissionDefinitions { get; set; }
        public DbSet<ProjectPermissionRoleDefinition> ProjectPermissionRoleDefinitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CallsheetScene>()
                        .HasOne(cs=> cs.ShootingDayScene)
                        .WithOne(sds=> sds.CallsheetScene)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShootingDay>()
                        .HasOne(cs => cs.Callsheet)
                        .WithOne(sd => sd.ShootingDay)
                        .HasForeignKey<Callsheet>(cs => cs.ShootingDayID);

            modelBuilder.Entity<ShootingDay>()
                        .HasOne(cs => cs.ScheduleDay)
                        .WithOne(sd => sd.ShootingDay)
                        .HasForeignKey<ScheduleDay>(cs => cs.ShootingDayID);

            modelBuilder.Entity<CallsheetScene>()
                        .HasOne(cs => cs.ShootingDayScene)
                        .WithOne(sd => sd.CallsheetScene)
                        .HasForeignKey<ShootingDayScene>(cs => cs.CallsheetSceneID);

            modelBuilder.Entity<ProjectUser>()
                        .HasOne(cs => cs.CastMember)
                        .WithOne(sd => sd.ProjectUser)
                        .HasForeignKey<CastMember>(cs => cs.ProjectUserID);

            modelBuilder.Entity<ProjectUserInvitation>()
                        .HasOne(cs => cs.CastMember)
                        .WithOne(sd => sd.ProjectUserInvitation)
                        .HasForeignKey<CastMember>(cs => cs.ProjectUserInvitationID);

            modelBuilder.Entity<UserInvitation>()
                        .HasMany(pui => pui.ProjectUserInvitations)
                        .WithOne(ui => ui.UserInvitation);
        }
    }
}
