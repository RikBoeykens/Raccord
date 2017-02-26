using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class manytomanyimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    FileContent = table.Column<byte[]>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Image_Projects_ProjectID",
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

            migrationBuilder.CreateTable(
                name: "ImageScene",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ImageID = table.Column<long>(nullable: false),
                    SceneID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageScene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageScene_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageScene_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProjectID",
                table: "Image",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageLocation_ImageID",
                table: "ImageLocation",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageLocation_LocationID",
                table: "ImageLocation",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageScene_ImageID",
                table: "ImageScene",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageScene_SceneID",
                table: "ImageScene",
                column: "SceneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageLocation");

            migrationBuilder.DropTable(
                name: "ImageScene");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
