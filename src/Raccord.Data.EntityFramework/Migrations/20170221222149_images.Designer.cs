using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Raccord.Data.EntityFramework;

namespace Raccord.Data.EntityFramework.Migrations
{
    [DbContext(typeof(RaccordDBContext))]
    [Migration("20170221222149_images")]
    partial class images
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

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
        }
    }
}
