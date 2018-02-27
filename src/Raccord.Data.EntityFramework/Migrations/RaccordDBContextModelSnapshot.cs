﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Raccord.Data.EntityFramework;
using Raccord.Core.Enums;

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

            modelBuilder.Entity("OpenIddict.Models.OpenIddictApplication", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ClientId")
                        .IsRequired();

                    b.Property<string>("ClientSecret");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken();

                    b.Property<string>("ConsentType");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Permissions");

                    b.Property<string>("PostLogoutRedirectUris");

                    b.Property<string>("Properties");

                    b.Property<string>("RedirectUris");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("OpenIddictApplications");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictAuthorization", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ApplicationId");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken();

                    b.Property<string>("Properties");

                    b.Property<string>("Scopes");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("OpenIddictAuthorizations");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictScope", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Properties");

                    b.Property<string>("Resources");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("OpenIddictScopes");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictToken", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ApplicationId");

                    b.Property<string>("AuthorizationId");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken();

                    b.Property<DateTimeOffset?>("CreationDate");

                    b.Property<DateTimeOffset?>("ExpirationDate");

                    b.Property<string>("Payload");

                    b.Property<string>("Properties");

                    b.Property<string>("ReferenceId");

                    b.Property<string>("Status");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("AuthorizationId");

                    b.HasIndex("ReferenceId")
                        .IsUnique();

                    b.ToTable("OpenIddictTokens");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Breakdowns.Breakdown", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsDefaultProjectBreakdown");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Name");

                    b.Property<long>("ProjectID");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("UserID");

                    b.ToTable("Breakdown");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Breakdowns.BreakdownItems.BreakdownItem", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BreakdownID");

                    b.Property<long>("BreakdownTypeID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("BreakdownID");

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

                    b.Property<long>("BreakdownID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("BreakdownID");

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

                    b.Property<int?>("SortingOrder");

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

                    b.Property<int?>("SortingOrder");

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

                    b.Property<long>("ShootingDaySceneID");

                    b.Property<int?>("SortingOrder");

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

            modelBuilder.Entity("Raccord.Domain.Model.Cast.CastMember", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<long>("ProjectID");

                    b.Property<long?>("ProjectUserID");

                    b.Property<string>("Telephone");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("CastMember");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Characters.Character", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CastMemberID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.Property<long>("ProjectID");

                    b.Property<long?>("ScriptUploadID");

                    b.HasKey("ID");

                    b.HasIndex("CastMemberID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("ScriptUploadID");

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

            modelBuilder.Entity("Raccord.Domain.Model.Comments.Comment", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ParentCommentID");

                    b.Property<long?>("ParentProjectID");

                    b.Property<string>("Text");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ParentCommentID");

                    b.HasIndex("ParentProjectID");

                    b.HasIndex("UserID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Crew.CrewMembers.CrewMember", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DepartmentID");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("JobTitle");

                    b.Property<string>("LastName");

                    b.Property<long?>("ProjectUserID");

                    b.Property<string>("Telephone");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("ProjectUserID");

                    b.ToTable("CrewMember");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Crew.CrewUnits.CrewUnit", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("CrewUnit");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Crew.CrewUnits.CrewUnitMember", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CrewUnitID");

                    b.Property<long>("ProjectUserID");

                    b.HasKey("ID");

                    b.HasIndex("CrewUnitID");

                    b.HasIndex("ProjectUserID");

                    b.ToTable("CrewUnitMember");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Crew.Departments.CrewDepartment", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CrewUnitID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("SortingOrder");

                    b.HasKey("ID");

                    b.HasIndex("CrewUnitID");

                    b.ToTable("CrewDepartment");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Crew.Departments.CrewDepartmentDefinition", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("SortingOrder");

                    b.HasKey("ID");

                    b.ToTable("CrewDepartmentDefinitions");
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

            modelBuilder.Entity("Raccord.Domain.Model.Images.ImageSlate", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ImageID");

                    b.Property<bool>("IsPrimaryImage");

                    b.Property<long>("SlateID");

                    b.HasKey("ID");

                    b.HasIndex("ImageID");

                    b.HasIndex("SlateID");

                    b.ToTable("ImageSlate");
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

                    b.Property<bool>("PublishedSchedule");

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

                    b.Property<long?>("ScriptUploadID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("ScriptUploadID");

                    b.ToTable("DayNights");
                });

            modelBuilder.Entity("Raccord.Domain.Model.SceneProperties.IntExt", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("ProjectID");

                    b.Property<long?>("ScriptUploadID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("ScriptUploadID");

                    b.ToTable("IntExts");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scenes.Actions.SceneAction", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Order");

                    b.Property<long>("SceneID");

                    b.Property<string>("Text");

                    b.HasKey("ID");

                    b.HasIndex("SceneID");

                    b.ToTable("SceneAction");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scenes.Dialogues.SceneDialogue", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CharacterID");

                    b.Property<int>("Order");

                    b.Property<long>("SceneID");

                    b.Property<string>("Text");

                    b.HasKey("ID");

                    b.HasIndex("CharacterID");

                    b.HasIndex("SceneID");

                    b.ToTable("SceneDialogue");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scenes.Scene", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("DayNightID");

                    b.Property<long?>("IntExtID");

                    b.Property<string>("Number");

                    b.Property<int>("PageLength");

                    b.Property<long>("ProjectID");

                    b.Property<long?>("ScriptLocationID");

                    b.Property<long?>("ScriptUploadID");

                    b.Property<int?>("SortingOrder");

                    b.Property<string>("Summary");

                    b.Property<TimeSpan>("Timing");

                    b.HasKey("ID");

                    b.HasIndex("DayNightID");

                    b.HasIndex("IntExtID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("ScriptLocationID");

                    b.HasIndex("ScriptUploadID");

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

                    b.Property<int?>("SortingOrder");

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

                    b.Property<int?>("SortingOrder");

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

                    b.Property<long?>("ScriptUploadID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("ScriptUploadID");

                    b.ToTable("ScriptLocations");
                });

            modelBuilder.Entity("Raccord.Domain.Model.ScriptUploads.ScriptUpload", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("End");

                    b.Property<string>("FileName");

                    b.Property<long>("ProjectID");

                    b.Property<DateTime>("Start");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ScriptUpload");
                });

            modelBuilder.Entity("Raccord.Domain.Model.ShootingDays.Scenes.ShootingDayScene", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CallsheetSceneID");

                    b.Property<int>("Completion");

                    b.Property<long?>("LocationSetID");

                    b.Property<int>("PageLength");

                    b.Property<long>("SceneID");

                    b.Property<long>("ShootingDayID");

                    b.Property<TimeSpan>("Timings");

                    b.HasKey("ID");

                    b.HasIndex("CallsheetSceneID")
                        .IsUnique();

                    b.HasIndex("LocationSetID");

                    b.HasIndex("SceneID");

                    b.HasIndex("ShootingDayID");

                    b.ToTable("ShootingDayScene");
                });

            modelBuilder.Entity("Raccord.Domain.Model.ShootingDays.ShootingDay", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CallsheetID");

                    b.Property<bool>("Completed");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("End");

                    b.Property<string>("Number");

                    b.Property<TimeSpan>("OverTime");

                    b.Property<long>("ProjectID");

                    b.Property<long?>("ScheduleDayID");

                    b.Property<DateTime>("Start");

                    b.Property<DateTime>("Turn");

                    b.HasKey("ID");

                    b.HasIndex("CallsheetID")
                        .IsUnique();

                    b.HasIndex("ProjectID");

                    b.HasIndex("ScheduleDayID")
                        .IsUnique();

                    b.ToTable("ShootingDay");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Shots.Slate", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Aperture");

                    b.Property<string>("Description");

                    b.Property<string>("Distance");

                    b.Property<string>("Filters");

                    b.Property<bool>("IsVfx");

                    b.Property<string>("Lens");

                    b.Property<string>("Number");

                    b.Property<long>("ProjectID");

                    b.Property<long?>("SceneID");

                    b.Property<long?>("ShootingDayID");

                    b.Property<int?>("SortingOrder");

                    b.Property<string>("Sound");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("SceneID");

                    b.HasIndex("ShootingDayID");

                    b.ToTable("Slate");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Shots.Take", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CameraRoll");

                    b.Property<TimeSpan>("Length");

                    b.Property<string>("Notes");

                    b.Property<string>("Number");

                    b.Property<bool>("Selected");

                    b.Property<long>("SlateID");

                    b.Property<int?>("SortingOrder");

                    b.Property<string>("SoundRoll");

                    b.HasKey("ID");

                    b.HasIndex("SlateID");

                    b.ToTable("Take");
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

                    b.Property<string>("FirstName");

                    b.Property<byte[]>("ImageContent");

                    b.Property<string>("ImageName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PreferredEmail");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Telephone");

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

            modelBuilder.Entity("Raccord.Domain.Model.Users.ProjectRoles.ProjectPermissionDefinition", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Permission");

                    b.HasKey("ID");

                    b.ToTable("ProjectPermissionDefinitions");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Users.ProjectRoles.ProjectPermissionRoleDefinition", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ProjectPermissionID");

                    b.Property<long>("ProjectRoleID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectPermissionID");

                    b.HasIndex("ProjectRoleID");

                    b.ToTable("ProjectPermissionRoleDefinitions");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Users.ProjectRoles.ProjectRoleDefinition", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Role");

                    b.HasKey("ID");

                    b.ToTable("ProjectRoleDefinitions");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Users.ProjectUser", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CastMemberID");

                    b.Property<long>("ProjectID");

                    b.Property<long?>("RoleID");

                    b.Property<long?>("SelectedBreakdownID");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("CastMemberID")
                        .IsUnique();

                    b.HasIndex("ProjectID");

                    b.HasIndex("RoleID");

                    b.HasIndex("SelectedBreakdownID");

                    b.HasIndex("UserID");

                    b.ToTable("ProjectUser");
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
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictAuthorization", b =>
                {
                    b.HasOne("OpenIddict.Models.OpenIddictApplication", "Application")
                        .WithMany("Authorizations")
                        .HasForeignKey("ApplicationId");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictToken", b =>
                {
                    b.HasOne("OpenIddict.Models.OpenIddictApplication", "Application")
                        .WithMany("Tokens")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("OpenIddict.Models.OpenIddictAuthorization", "Authorization")
                        .WithMany("Tokens")
                        .HasForeignKey("AuthorizationId");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Breakdowns.Breakdown", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany("Breakdowns")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Users.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Breakdowns.BreakdownItems.BreakdownItem", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Breakdowns.Breakdown", "Breakdown")
                        .WithMany("Items")
                        .HasForeignKey("BreakdownID")
                        .OnDelete(DeleteBehavior.Cascade);

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
                    b.HasOne("Raccord.Domain.Model.Breakdowns.Breakdown", "Breakdown")
                        .WithMany("Types")
                        .HasForeignKey("BreakdownID")
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

            modelBuilder.Entity("Raccord.Domain.Model.Cast.CastMember", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Characters.Character", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Cast.CastMember", "CastMember")
                        .WithMany("Characters")
                        .HasForeignKey("CastMemberID");

                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.ScriptUploads.ScriptUpload", "ScriptUpload")
                        .WithMany("Characters")
                        .HasForeignKey("ScriptUploadID");
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

            modelBuilder.Entity("Raccord.Domain.Model.Comments.Comment", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Comments.Comment", "ParentComment")
                        .WithMany("Comments")
                        .HasForeignKey("ParentCommentID");

                    b.HasOne("Raccord.Domain.Model.Projects.Project", "ParentProject")
                        .WithMany("Comments")
                        .HasForeignKey("ParentProjectID");

                    b.HasOne("Raccord.Domain.Model.Users.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Crew.CrewMembers.CrewMember", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Crew.Departments.CrewDepartment", "Department")
                        .WithMany("Crew")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Users.ProjectUser", "ProjectUser")
                        .WithMany("CrewMembers")
                        .HasForeignKey("ProjectUserID");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Crew.CrewUnits.CrewUnit", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany("CrewUnits")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Crew.CrewUnits.CrewUnitMember", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Crew.CrewUnits.CrewUnit", "CrewUnit")
                        .WithMany("CrewUnitMembers")
                        .HasForeignKey("CrewUnitID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Users.ProjectUser", "ProjectUser")
                        .WithMany("CrewUnitMembers")
                        .HasForeignKey("ProjectUserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Crew.Departments.CrewDepartment", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Crew.CrewUnits.CrewUnit", "CrewUnit")
                        .WithMany("CrewDepartments")
                        .HasForeignKey("CrewUnitID")
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

            modelBuilder.Entity("Raccord.Domain.Model.Images.ImageSlate", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Images.Image", "Image")
                        .WithMany("ImageSlates")
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Shots.Slate", "Slate")
                        .WithMany("ImageSlates")
                        .HasForeignKey("SlateID")
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

                    b.HasOne("Raccord.Domain.Model.ScriptUploads.ScriptUpload", "ScriptUpload")
                        .WithMany()
                        .HasForeignKey("ScriptUploadID");
                });

            modelBuilder.Entity("Raccord.Domain.Model.SceneProperties.IntExt", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.ScriptUploads.ScriptUpload", "ScriptUpload")
                        .WithMany()
                        .HasForeignKey("ScriptUploadID");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scenes.Actions.SceneAction", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Scenes.Scene", "Scene")
                        .WithMany("Actions")
                        .HasForeignKey("SceneID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Scenes.Dialogues.SceneDialogue", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Characters.Character", "Character")
                        .WithMany("Dialogues")
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Scenes.Scene", "Scene")
                        .WithMany("Dialogues")
                        .HasForeignKey("SceneID")
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

                    b.HasOne("Raccord.Domain.Model.ScriptUploads.ScriptUpload", "ScriptUpload")
                        .WithMany("Scenes")
                        .HasForeignKey("ScriptUploadID");
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

                    b.HasOne("Raccord.Domain.Model.ScriptUploads.ScriptUpload", "ScriptUpload")
                        .WithMany("ScriptLocations")
                        .HasForeignKey("ScriptUploadID");
                });

            modelBuilder.Entity("Raccord.Domain.Model.ScriptUploads.ScriptUpload", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.ShootingDays.Scenes.ShootingDayScene", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Callsheets.Scenes.CallsheetScene", "CallsheetScene")
                        .WithOne("ShootingDayScene")
                        .HasForeignKey("Raccord.Domain.Model.ShootingDays.Scenes.ShootingDayScene", "CallsheetSceneID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Locations.LocationSets.LocationSet", "LocationSet")
                        .WithMany("ShootingDayScenes")
                        .HasForeignKey("LocationSetID");

                    b.HasOne("Raccord.Domain.Model.Scenes.Scene", "Scene")
                        .WithMany("ShootingDayScenes")
                        .HasForeignKey("SceneID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.ShootingDays.ShootingDay", "ShootingDay")
                        .WithMany("ShootingDayScenes")
                        .HasForeignKey("ShootingDayID")
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

            modelBuilder.Entity("Raccord.Domain.Model.Shots.Slate", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Scenes.Scene", "Scene")
                        .WithMany("Slates")
                        .HasForeignKey("SceneID");

                    b.HasOne("Raccord.Domain.Model.ShootingDays.ShootingDay", "ShootingDay")
                        .WithMany("Slates")
                        .HasForeignKey("ShootingDayID");
                });

            modelBuilder.Entity("Raccord.Domain.Model.Shots.Take", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Shots.Slate", "Slate")
                        .WithMany("Takes")
                        .HasForeignKey("SlateID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Users.ProjectRoles.ProjectPermissionRoleDefinition", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Users.ProjectRoles.ProjectPermissionDefinition", "ProjectPermission")
                        .WithMany("PermissionRoles")
                        .HasForeignKey("ProjectPermissionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Users.ProjectRoles.ProjectRoleDefinition", "ProjectRole")
                        .WithMany("PermissionRoles")
                        .HasForeignKey("ProjectRoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raccord.Domain.Model.Users.ProjectUser", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Cast.CastMember", "CastMember")
                        .WithOne("ProjectUser")
                        .HasForeignKey("Raccord.Domain.Model.Users.ProjectUser", "CastMemberID");

                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Users.ProjectRoles.ProjectRoleDefinition", "Role")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("RoleID");

                    b.HasOne("Raccord.Domain.Model.Breakdowns.Breakdown", "SelectedBreakdown")
                        .WithMany("SelectedByUsers")
                        .HasForeignKey("SelectedBreakdownID");

                    b.HasOne("Raccord.Domain.Model.Users.ApplicationUser", "User")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("UserID");
                });
        }
    }
}
