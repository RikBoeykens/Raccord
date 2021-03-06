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
using System.Linq;
using Raccord.Domain.Model;
using System.Collections.Generic;
using System;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Comments;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using Raccord.Domain.Model.Images;
using Raccord.Domain.Model.Locations.Locations;
using Raccord.Domain.Model.Shots;
using Raccord.Domain.Model.Locations.LocationSets;

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
        public DbSet<SceneIntro> SceneIntros { get; set; }
        public DbSet<TimeOfDay> TimeOfDays { get; set; }
        public DbSet<Character> Characters { get; set; }
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

            modelBuilder.Entity<Project>()
                        .HasMany(sc => sc.Comments)
                        .WithOne(c => c.ParentProject)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Scene>()
                        .HasMany(sc => sc.Comments)
                        .WithOne(c => c.ParentScene)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
                        .HasMany(sc => sc.Comments)
                        .WithOne(c => c.ParentCharacter)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BreakdownItem>()
                        .HasMany(sc => sc.Comments)
                        .WithOne(c => c.ParentBreakdownItem)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Image>()
                        .HasMany(sc => sc.Comments)
                        .WithOne(c => c.ParentImage)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Location>()
                        .HasMany(sc => sc.Comments)
                        .WithOne(c => c.ParentLocation)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LocationSet>()
                        .HasMany(sc => sc.Comments)
                        .WithOne(c => c.ParentLocationSet)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ScriptLocation>()
                        .HasMany(sc => sc.Comments)
                        .WithOne(c => c.ParentScriptLocation)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Slate>()
                        .HasMany(sc => sc.Comments)
                        .WithOne(c => c.ParentSlate)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Take>()
                        .HasMany(sc => sc.Comments)
                        .WithOne(c => c.ParentTake)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                        .HasMany(sc => sc.Comments)
                        .WithOne(c => c.ParentComment)
                        .OnDelete(DeleteBehavior.Cascade);

            SetPropertiesForBaseEntities<long>(modelBuilder);
            SetPropertiesForBaseEntities<Guid>(modelBuilder);
        }

        private void SetPropertiesForBaseEntities<T>(ModelBuilder modelBuilder)
        {
            foreach (var entityType in GetEntityTypes<T>(modelBuilder))
            {
                SetBaseEntityProperties(modelBuilder, entityType);
            }
        }

        private IEnumerable<IMutableEntityType> GetEntityTypes<T>(ModelBuilder modelBuilder)
        {
            return modelBuilder.Model.GetEntityTypes().Where(t => t.ClrType.IsSubclassOf(typeof(Entity<T>)));
        }

        private void SetBaseEntityProperties(ModelBuilder modelBuilder, IMutableEntityType entityType)
        {
            modelBuilder.Entity(
                entityType.Name,
                x =>
                {
                    x.Property("CreatedAt")
                        .HasDefaultValueSql("now()");
                    x.Property("UpdatedAt")
                        .HasDefaultValueSql("now()");
                });
        }
    }
}
