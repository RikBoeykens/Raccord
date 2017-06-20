using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class renamelocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenes_Locations_LocationID",
                table: "Scenes");

            migrationBuilder.DropIndex(
                name: "IX_Scenes_LocationID",
                table: "Scenes");

            migrationBuilder.DropTable(
                name: "ImageLocation");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.CreateTable(
                name: "ScriptLocations",
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
                    table.PrimaryKey("PK_ScriptLocations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScriptLocations_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageScriptLocation",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ImageID = table.Column<long>(nullable: false),
                    IsPrimaryImage = table.Column<bool>(nullable: false),
                    LocationID = table.Column<long>(nullable: false),
                    ScriptLocationID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageScriptLocation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageScriptLocation_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageScriptLocation_ScriptLocations_ScriptLocationID",
                        column: x => x.ScriptLocationID,
                        principalTable: "ScriptLocations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<long>(
                name: "ScriptLocationID",
                table: "Scenes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_ScriptLocationID",
                table: "Scenes",
                column: "ScriptLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageScriptLocation_ImageID",
                table: "ImageScriptLocation",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageScriptLocation_ScriptLocationID",
                table: "ImageScriptLocation",
                column: "ScriptLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptLocations_ProjectID",
                table: "ScriptLocations",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenes_ScriptLocations_ScriptLocationID",
                table: "Scenes",
                column: "ScriptLocationID",
                principalTable: "ScriptLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenes_ScriptLocations_ScriptLocationID",
                table: "Scenes");

            migrationBuilder.DropIndex(
                name: "IX_Scenes_ScriptLocationID",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "ScriptLocationID",
                table: "Scenes");

            migrationBuilder.DropTable(
                name: "ImageScriptLocation");

            migrationBuilder.DropTable(
                name: "ScriptLocations");

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
                name: "ImageLocation",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ImageID = table.Column<long>(nullable: false),
                    IsPrimaryImage = table.Column<bool>(nullable: false),
                    LocationID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageLocation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageLocation_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageLocation_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_LocationID",
                table: "Scenes",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageLocation_ImageID",
                table: "ImageLocation",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageLocation_LocationID",
                table: "ImageLocation",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ProjectID",
                table: "Locations",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenes_Locations_LocationID",
                table: "Scenes",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
