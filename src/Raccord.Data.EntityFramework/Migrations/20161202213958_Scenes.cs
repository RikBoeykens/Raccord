using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class Scenes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Locations_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayNights",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayNights", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DayNights_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntExts",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntExts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IntExts_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scenes",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    DayNightID = table.Column<long>(nullable: false),
                    IntExtID = table.Column<long>(nullable: false),
                    LocationID = table.Column<long>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    PageLength = table.Column<int>(nullable: false),
                    ProjectID = table.Column<long>(nullable: false),
                    SortingOrder = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Scenes_DayNights_DayNightID",
                        column: x => x.DayNightID,
                        principalTable: "DayNights",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scenes_IntExts_IntExtID",
                        column: x => x.IntExtID,
                        principalTable: "IntExts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scenes_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scenes_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ProjectID",
                table: "Locations",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_DayNights_ProjectID",
                table: "DayNights",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_IntExts_ProjectID",
                table: "IntExts",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_DayNightID",
                table: "Scenes",
                column: "DayNightID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_IntExtID",
                table: "Scenes",
                column: "IntExtID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_LocationID",
                table: "Scenes",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_ProjectID",
                table: "Scenes",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scenes");

            migrationBuilder.DropTable(
                name: "DayNights");

            migrationBuilder.DropTable(
                name: "IntExts");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
