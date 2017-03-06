using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class characters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    ProjectID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Character_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterScene",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CharacterID = table.Column<long>(nullable: false),
                    SceneID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterScene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CharacterScene_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterScene_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageCharacter",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CharacterID = table.Column<long>(nullable: false),
                    ImageID = table.Column<long>(nullable: false),
                    IsPrimaryImage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCharacter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageCharacter_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageCharacter_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_ProjectID",
                table: "Character",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterScene_CharacterID",
                table: "CharacterScene",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterScene_SceneID",
                table: "CharacterScene",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageCharacter_CharacterID",
                table: "ImageCharacter",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageCharacter_ImageID",
                table: "ImageCharacter",
                column: "ImageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterScene");

            migrationBuilder.DropTable(
                name: "ImageCharacter");

            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}
