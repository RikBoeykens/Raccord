using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class imageslates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageSlate",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ImageID = table.Column<long>(nullable: false),
                    IsPrimaryImage = table.Column<bool>(nullable: false),
                    SlateID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageSlate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageSlate_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageSlate_Slate_SlateID",
                        column: x => x.SlateID,
                        principalTable: "Slate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageSlate_ImageID",
                table: "ImageSlate",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSlate_SlateID",
                table: "ImageSlate",
                column: "SlateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageSlate");
        }
    }
}
