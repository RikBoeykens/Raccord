using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class breakdownitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakdownItem",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    BreakdownTypeID = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakdownItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BreakdownItem_BreakdownType_BreakdownTypeID",
                        column: x => x.BreakdownTypeID,
                        principalTable: "BreakdownType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreakdownItemScene",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    BreakdownItemID = table.Column<long>(nullable: false),
                    SceneID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakdownItemScene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BreakdownItemScene_BreakdownItem_BreakdownItemID",
                        column: x => x.BreakdownItemID,
                        principalTable: "BreakdownItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreakdownItemScene_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageBreakdownItem",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    BreakdownItemID = table.Column<long>(nullable: false),
                    ImageID = table.Column<long>(nullable: false),
                    IsPrimaryImage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageBreakdownItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageBreakdownItem_BreakdownItem_BreakdownItemID",
                        column: x => x.BreakdownItemID,
                        principalTable: "BreakdownItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageBreakdownItem_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreakdownItem_BreakdownTypeID",
                table: "BreakdownItem",
                column: "BreakdownTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_BreakdownItemScene_BreakdownItemID",
                table: "BreakdownItemScene",
                column: "BreakdownItemID");

            migrationBuilder.CreateIndex(
                name: "IX_BreakdownItemScene_SceneID",
                table: "BreakdownItemScene",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageBreakdownItem_BreakdownItemID",
                table: "ImageBreakdownItem",
                column: "BreakdownItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageBreakdownItem_ImageID",
                table: "ImageBreakdownItem",
                column: "ImageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakdownItemScene");

            migrationBuilder.DropTable(
                name: "ImageBreakdownItem");

            migrationBuilder.DropTable(
                name: "BreakdownItem");
        }
    }
}
