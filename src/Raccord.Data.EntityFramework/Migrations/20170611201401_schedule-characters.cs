using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class schedulecharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleCharacter",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CharacterSceneID = table.Column<long>(nullable: false),
                    ScheduleSceneID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleCharacter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScheduleCharacter_CharacterScene_CharacterSceneID",
                        column: x => x.CharacterSceneID,
                        principalTable: "CharacterScene",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleCharacter_ScheduleScene_ScheduleSceneID",
                        column: x => x.ScheduleSceneID,
                        principalTable: "ScheduleScene",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleCharacter_CharacterSceneID",
                table: "ScheduleCharacter",
                column: "CharacterSceneID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleCharacter_ScheduleSceneID",
                table: "ScheduleCharacter",
                column: "ScheduleSceneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleCharacter");
        }
    }
}
