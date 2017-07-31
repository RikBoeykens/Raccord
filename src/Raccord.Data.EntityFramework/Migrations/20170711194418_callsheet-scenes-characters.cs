using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class callsheetscenescharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Callsheet_ShootingDay_ShootingDayID",
                table: "Callsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_ShootingDay_ScheduleDay_ScheduleDayID",
                table: "ShootingDay");

            migrationBuilder.DropIndex(
                name: "IX_ShootingDay_ScheduleDayID",
                table: "ShootingDay");

            migrationBuilder.DropIndex(
                name: "IX_Callsheet_ShootingDayID",
                table: "Callsheet");

            migrationBuilder.CreateTable(
                name: "CallsheetScene",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CallsheetID = table.Column<long>(nullable: false),
                    LocationSetID = table.Column<long>(nullable: true),
                    PageLength = table.Column<int>(nullable: false),
                    SceneID = table.Column<long>(nullable: false),
                    SortingOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallsheetScene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CallsheetScene_Callsheet_CallsheetID",
                        column: x => x.CallsheetID,
                        principalTable: "Callsheet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallsheetScene_LocationSet_LocationSetID",
                        column: x => x.LocationSetID,
                        principalTable: "LocationSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CallsheetScene_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallsheetSceneCharacter",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CallsheetSceneID = table.Column<long>(nullable: false),
                    CharacterSceneID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallsheetSceneCharacter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CallsheetSceneCharacter_CallsheetScene_CallsheetSceneID",
                        column: x => x.CallsheetSceneID,
                        principalTable: "CallsheetScene",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallsheetSceneCharacter_CharacterScene_CharacterSceneID",
                        column: x => x.CharacterSceneID,
                        principalTable: "CharacterScene",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDay_CallsheetID",
                table: "ShootingDay",
                column: "CallsheetID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDay_ShootingDayID",
                table: "ScheduleDay",
                column: "ShootingDayID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetScene_CallsheetID",
                table: "CallsheetScene",
                column: "CallsheetID");

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetScene_LocationSetID",
                table: "CallsheetScene",
                column: "LocationSetID");

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetScene_SceneID",
                table: "CallsheetScene",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetSceneCharacter_CallsheetSceneID",
                table: "CallsheetSceneCharacter",
                column: "CallsheetSceneID");

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetSceneCharacter_CharacterSceneID",
                table: "CallsheetSceneCharacter",
                column: "CharacterSceneID");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDay_ShootingDay_ShootingDayID",
                table: "ScheduleDay",
                column: "ShootingDayID",
                principalTable: "ShootingDay",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShootingDay_Callsheet_CallsheetID",
                table: "ShootingDay",
                column: "CallsheetID",
                principalTable: "Callsheet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDay_ShootingDay_ShootingDayID",
                table: "ScheduleDay");

            migrationBuilder.DropForeignKey(
                name: "FK_ShootingDay_Callsheet_CallsheetID",
                table: "ShootingDay");

            migrationBuilder.DropIndex(
                name: "IX_ShootingDay_CallsheetID",
                table: "ShootingDay");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleDay_ShootingDayID",
                table: "ScheduleDay");

            migrationBuilder.DropTable(
                name: "CallsheetSceneCharacter");

            migrationBuilder.DropTable(
                name: "CallsheetScene");

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDay_ScheduleDayID",
                table: "ShootingDay",
                column: "ScheduleDayID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Callsheet_ShootingDayID",
                table: "Callsheet",
                column: "ShootingDayID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Callsheet_ShootingDay_ShootingDayID",
                table: "Callsheet",
                column: "ShootingDayID",
                principalTable: "ShootingDay",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShootingDay_ScheduleDay_ScheduleDayID",
                table: "ShootingDay",
                column: "ScheduleDayID",
                principalTable: "ScheduleDay",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
