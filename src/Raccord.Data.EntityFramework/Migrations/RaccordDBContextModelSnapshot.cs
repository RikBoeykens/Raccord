using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Raccord.Data.EntityFramework;

namespace Raccord.Data.EntityFramework.Migrations
{
    [DbContext(typeof(RaccordDBContext))]
    partial class RaccordDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.3");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Breakdowns.BreakdownItems.BreakdownItem", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BreakdownTypeID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("BreakdownTypeID");

                    b.ToTable("BreakdownItem");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Breakdowns.BreakdownItems.BreakdownItemScene", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BreakdownItemID");

                    b.Property<long>("SceneID");

                    b.HasKey("ID");

                    b.HasIndex("BreakdownItemID");

                    b.HasIndex("SceneID");

                    b.ToTable("BreakdownItemScene");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Breakdowns.BreakdownTypes.BreakdownType", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("BreakdownType");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Breakdowns.BreakdownTypes.BreakdownTypeDefinition", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("BreakdownTypeDefinitions");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.Callsheet", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CrewCall");

                    b.Property<DateTime>("End");

                    b.Property<long>("ProjectID");

                    b.Property<long>("ShootingDayID");

                    b.Property<DateTime>("Start");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Callsheet");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.CallTypes.CallType", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("ProjectID");

                    b.Property<string>("ShortName");

                    b.Property<int>("SortingOrder");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("CallType");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.CallTypes.CallTypeDefinition", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.Property<int>("SortingOrder");

                    b.HasKey("ID");

                    b.ToTable("CallTypeDefinitions");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.Characters.CallsheetCharacter", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CallsheetID");

                    b.Property<long>("CharacterID");

                    b.HasKey("ID");

                    b.HasIndex("CallsheetID");

                    b.HasIndex("CharacterID");

                    b.ToTable("CallsheetCharacter");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.Characters.CharacterCall", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CallTime");

                    b.Property<long>("CallTypeID");

                    b.Property<long>("CallsheetCharacterID");

                    b.HasKey("ID");

                    b.HasIndex("CallTypeID");

                    b.HasIndex("CallsheetCharacterID");

                    b.ToTable("CharacterCall");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.Scenes.CallsheetScene", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CallsheetID");

                    b.Property<long?>("LocationSetID");

                    b.Property<int>("PageLength");

                    b.Property<long>("SceneID");

                    b.Property<int>("SortingOrder");

                    b.HasKey("ID");

                    b.HasIndex("CallsheetID");

                    b.HasIndex("LocationSetID");

                    b.HasIndex("SceneID");

                    b.ToTable("CallsheetScene");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.Scenes.CallsheetSceneCharacter", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CallsheetSceneID");

                    b.Property<long>("CharacterSceneID");

                    b.HasKey("ID");

                    b.HasIndex("CallsheetSceneID");

                    b.HasIndex("CharacterSceneID");

                    b.ToTable("CallsheetSceneCharacter");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Characters.Character", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.Property<long>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Characters.CharacterScene", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CharacterID");

                    b.Property<long>("SceneID");

                    b.HasKey("ID");

                    b.HasIndex("CharacterID");

                    b.HasIndex("SceneID");

                    b.ToTable("CharacterScene");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Images.Image", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<byte[]>("FileContent");

                    b.Property<string>("FileName");

                    b.Property<bool>("IsPrimaryImage");

                    b.Property<long>("ProjectID");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Images.ImageBreakdownItem", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BreakdownItemID");

                    b.Property<long>("ImageID");

                    b.Property<bool>("IsPrimaryImage");

                    b.HasKey("ID");

                    b.HasIndex("BreakdownItemID");

                    b.HasIndex("ImageID");

                    b.ToTable("ImageBreakdownItem");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Images.ImageCharacter", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CharacterID");

                    b.Property<long>("ImageID");

                    b.Property<bool>("IsPrimaryImage");

                    b.HasKey("ID");

                    b.HasIndex("CharacterID");

                    b.HasIndex("ImageID");

                    b.ToTable("ImageCharacter");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Images.ImageScene", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ImageID");

                    b.Property<bool>("IsPrimaryImage");

                    b.Property<long>("SceneID");

                    b.HasKey("ID");

                    b.HasIndex("ImageID");

                    b.HasIndex("SceneID");

                    b.ToTable("ImageScene");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Images.ImageScriptLocation", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ImageID");

                    b.Property<bool>("IsPrimaryImage");

                    b.Property<long>("ScriptLocationID");

                    b.HasKey("ID");

                    b.HasIndex("ImageID");

                    b.HasIndex("ScriptLocationID");

                    b.ToTable("ImageScriptLocation");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Locations.Locations.Location", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("Address3");

                    b.Property<string>("Address4");

                    b.Property<string>("Description");

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<string>("Name");

                    b.Property<long>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Locations.LocationSets.LocationSet", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<double?>("Latitude");

                    b.Property<long>("LocationID");

                    b.Property<double?>("Longitude");

                    b.Property<string>("Name");

                    b.Property<long>("ScriptLocationID");

                    b.HasKey("ID");

                    b.HasIndex("LocationID");

                    b.HasIndex("ScriptLocationID");

                    b.ToTable("LocationSet");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Projects.Project", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Raccord.Domain.Model.SceneProperties.DayNight", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("DayNights");
                });

            modelBuilder.Entity("Raccord.Domain.Model.SceneProperties.IntExt", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("IntExts");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scenes.Scene", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DayNightID");

                    b.Property<long>("IntExtID");

                    b.Property<string>("Number");

                    b.Property<int>("PageLength");

                    b.Property<long>("ProjectID");

                    b.Property<long>("ScriptLocationID");

                    b.Property<int>("SortingOrder");

                    b.Property<string>("Summary");

                    b.HasKey("ID");

                    b.HasIndex("DayNightID");

                    b.HasIndex("IntExtID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("ScriptLocationID");

                    b.ToTable("Scenes");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scheduling.ScheduleCharacter", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CharacterSceneID");

                    b.Property<long>("ScheduleSceneID");

                    b.HasKey("ID");

                    b.HasIndex("CharacterSceneID");

                    b.HasIndex("ScheduleSceneID");

                    b.ToTable("ScheduleCharacter");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scheduling.ScheduleDay", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<DateTime?>("End");

                    b.Property<long>("ProjectID");

                    b.Property<long?>("ShootingDayID");

                    b.Property<DateTime?>("Start");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ScheduleDay");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scheduling.ScheduleDayNote", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<long>("ScheduleDayID");

                    b.Property<int>("SortingOrder");

                    b.HasKey("ID");

                    b.HasIndex("ScheduleDayID");

                    b.ToTable("ScheduleDayNote");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scheduling.ScheduleScene", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("LocationSetID");

                    b.Property<int>("PageLength");

                    b.Property<long>("SceneID");

                    b.Property<long>("ScheduleDayID");

                    b.Property<int>("SortingOrder");

                    b.HasKey("ID");

                    b.HasIndex("LocationSetID");

                    b.HasIndex("SceneID");

                    b.HasIndex("ScheduleDayID");

                    b.ToTable("ScheduleScene");
                });

            modelBuilder.Entity("Raccord.Domain.Model.ScriptLocations.ScriptLocation", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ScriptLocations");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Users.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Users.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Users.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Users.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity("Raccord.Domain.Model.ShootingDays.ShootingDay", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CallsheetID");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Number");

                    b.Property<long>("ProjectID");

                    b.Property<long?>("ScheduleDayID");

                    b.HasKey("ID");

                    b.HasIndex("CallsheetID")
                        .IsUnique();

                    b.HasIndex("ProjectID");

                    b.HasIndex("ScheduleDayID")
                        .IsUnique();

                    b.ToTable("ShootingDay");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Breakdowns.BreakdownItems.BreakdownItem", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Breakdowns.BreakdownTypes.BreakdownType", "BreakdownType")
                        .WithMany("BreakdownItems")
                        .HasForeignKey("BreakdownTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Breakdowns.BreakdownItems.BreakdownItemScene", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Breakdowns.BreakdownItems.BreakdownItem", "BreakdownItem")
                        .WithMany("BreakdownItemScenes")
                        .HasForeignKey("BreakdownItemID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Scenes.Scene", "Scene")
                        .WithMany("BreakdownItemScenes")
                        .HasForeignKey("SceneID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Breakdowns.BreakdownTypes.BreakdownType", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany("BreakdownTypes")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.Callsheet", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.CallTypes.CallType", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany("CallTypes")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.Characters.CallsheetCharacter", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Callsheets.Callsheet", "Callsheet")
                        .WithMany("CallsheetCharacters")
                        .HasForeignKey("CallsheetID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Characters.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.Characters.CharacterCall", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Callsheets.CallTypes.CallType", "CallType")
                        .WithMany("CharacterCalls")
                        .HasForeignKey("CallTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Callsheets.Characters.CallsheetCharacter", "CallsheetCharacter")
                        .WithMany("CharacterCalls")
                        .HasForeignKey("CallsheetCharacterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.Scenes.CallsheetScene", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Callsheets.Callsheet", "Callsheet")
                        .WithMany("CallsheetScenes")
                        .HasForeignKey("CallsheetID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Locations.LocationSets.LocationSet", "LocationSet")
                        .WithMany("CallsheetScenes")
                        .HasForeignKey("LocationSetID");

                    b.HasOne("Raccord.Domain.Model.Scenes.Scene", "Scene")
                        .WithMany("CallsheetScenes")
                        .HasForeignKey("SceneID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Callsheets.Scenes.CallsheetSceneCharacter", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Callsheets.Scenes.CallsheetScene", "CallsheetScene")
                        .WithMany("Characters")
                        .HasForeignKey("CallsheetSceneID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Characters.CharacterScene", "CharacterScene")
                        .WithMany("CallsheetScenes")
                        .HasForeignKey("CharacterSceneID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Characters.Character", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Characters.CharacterScene", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Characters.Character", "Character")
                        .WithMany("CharacterScenes")
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Scenes.Scene", "Scene")
                        .WithMany("CharacterScenes")
                        .HasForeignKey("SceneID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Images.Image", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany("Images")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Images.ImageBreakdownItem", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Breakdowns.BreakdownItems.BreakdownItem", "BreakdownItem")
                        .WithMany("ImageBreakdownItems")
                        .HasForeignKey("BreakdownItemID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Images.Image", "Image")
                        .WithMany("ImageBreakdownItems")
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Images.ImageCharacter", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Characters.Character", "Character")
                        .WithMany("ImageCharacters")
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Images.Image", "Image")
                        .WithMany("ImageCharacters")
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Images.ImageScene", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Images.Image", "Image")
                        .WithMany("ImageScenes")
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Scenes.Scene", "Scene")
                        .WithMany("ImageScenes")
                        .HasForeignKey("SceneID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Images.ImageScriptLocation", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Images.Image", "Image")
                        .WithMany("ImageScriptLocations")
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.ScriptLocations.ScriptLocation", "ScriptLocation")
                        .WithMany("ImageLocations")
                        .HasForeignKey("ScriptLocationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Locations.Locations.Location", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Locations.LocationSets.LocationSet", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Locations.Locations.Location", "Location")
                        .WithMany("LocationSets")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.ScriptLocations.ScriptLocation", "ScriptLocation")
                        .WithMany("LocationSets")
                        .HasForeignKey("ScriptLocationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.SceneProperties.DayNight", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.SceneProperties.IntExt", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scenes.Scene", b =>
                {
                    b.HasOne("Raccord.Domain.Model.SceneProperties.DayNight", "DayNight")
                        .WithMany("Scenes")
                        .HasForeignKey("DayNightID");

                    b.HasOne("Raccord.Domain.Model.SceneProperties.IntExt", "IntExt")
                        .WithMany("Scenes")
                        .HasForeignKey("IntExtID");

                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.ScriptLocations.ScriptLocation", "ScriptLocation")
                        .WithMany("Scenes")
                        .HasForeignKey("ScriptLocationID");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scheduling.ScheduleCharacter", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Characters.CharacterScene", "CharacterScene")
                        .WithMany("ScheduleDays")
                        .HasForeignKey("CharacterSceneID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Scheduling.ScheduleScene", "ScheduleScene")
                        .WithMany("Characters")
                        .HasForeignKey("ScheduleSceneID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scheduling.ScheduleDay", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scheduling.ScheduleDayNote", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Scheduling.ScheduleDay", "ScheduleDay")
                        .WithMany("Notes")
                        .HasForeignKey("ScheduleDayID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scheduling.ScheduleScene", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Locations.LocationSets.LocationSet", "LocationSet")
                        .WithMany("ScheduleScenes")
                        .HasForeignKey("LocationSetID");

                    b.HasOne("Raccord.Domain.Model.Scenes.Scene", "Scene")
                        .WithMany("ScheduleScenes")
                        .HasForeignKey("SceneID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Scheduling.ScheduleDay", "ScheduleDay")
                        .WithMany("ScheduleScenes")
                        .HasForeignKey("ScheduleDayID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.ScriptLocations.ScriptLocation", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.ShootingDays.ShootingDay", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Callsheets.Callsheet", "Callsheet")
                        .WithOne("ShootingDay")
                        .HasForeignKey("Raccord.Domain.Model.ShootingDays.ShootingDay", "CallsheetID");

                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Scheduling.ScheduleDay", "ScheduleDay")
                        .WithOne("ShootingDay")
                        .HasForeignKey("Raccord.Domain.Model.ShootingDays.ShootingDay", "ScheduleDayID");
                });
        }
    }
}
