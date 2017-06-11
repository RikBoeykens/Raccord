﻿using System;
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
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

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

            modelBuilder.Entity("Raccord.Domain.Model.Images.ImageLocation", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ImageID");

                    b.Property<bool>("IsPrimaryImage");

                    b.Property<long>("LocationID");

                    b.HasKey("ID");

                    b.HasIndex("ImageID");

                    b.HasIndex("LocationID");

                    b.ToTable("ImageLocation");
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

            modelBuilder.Entity("Raccord.Domain.Model.Locations.Location", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Locations");
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

                    b.Property<long>("LocationID");

                    b.Property<string>("Number");

                    b.Property<int>("PageLength");

                    b.Property<long>("ProjectID");

                    b.Property<int>("SortingOrder");

                    b.Property<string>("Summary");

                    b.HasKey("ID");

                    b.HasIndex("DayNightID");

                    b.HasIndex("IntExtID");

                    b.HasIndex("LocationID");

                    b.HasIndex("ProjectID");

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

                    b.Property<int>("PageLength");

                    b.Property<long>("SceneID");

                    b.Property<long>("ScheduleDayID");

                    b.Property<int>("SortingOrder");

                    b.HasKey("ID");

                    b.HasIndex("SceneID");

                    b.HasIndex("ScheduleDayID");

                    b.ToTable("ScheduleScene");
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

            modelBuilder.Entity("Raccord.Domain.Model.Images.ImageLocation", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Images.Image", "Image")
                        .WithMany("ImageLocations")
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Locations.Location", "Location")
                        .WithMany("ImageLocations")
                        .HasForeignKey("LocationID")
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

            modelBuilder.Entity("Raccord.Domain.Model.Locations.Location", b =>
                {
                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
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

                    b.HasOne("Raccord.Domain.Model.Locations.Location", "Location")
                        .WithMany("Scenes")
                        .HasForeignKey("LocationID");

                    b.HasOne("Raccord.Domain.Model.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
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
                    b.HasOne("Raccord.Domain.Model.Scenes.Scene", "Scene")
                        .WithMany("ScheduleScenes")
                        .HasForeignKey("SceneID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raccord.Domain.Model.Scheduling.ScheduleDay", "ScheduleDay")
                        .WithMany("ScheduleScenes")
                        .HasForeignKey("ScheduleDayID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
