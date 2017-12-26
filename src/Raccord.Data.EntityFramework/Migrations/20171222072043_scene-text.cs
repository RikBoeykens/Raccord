using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class scenetext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SceneAction",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Order = table.Column<int>(nullable: false),
                    SceneID = table.Column<long>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneAction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SceneAction_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SceneDialogue",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CharacterID = table.Column<long>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    SceneID = table.Column<long>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneDialogue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SceneDialogue_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SceneDialogue_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SceneAction_SceneID",
                table: "SceneAction",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_SceneDialogue_CharacterID",
                table: "SceneDialogue",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_SceneDialogue_SceneID",
                table: "SceneDialogue",
                column: "SceneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SceneAction");

            migrationBuilder.DropTable(
                name: "SceneDialogue");
        }
    }
}
