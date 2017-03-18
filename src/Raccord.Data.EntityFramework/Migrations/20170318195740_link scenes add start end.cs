using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class linkscenesaddstartend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleDay",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Date = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    Start = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScheduleDay_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDayNote",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Content = table.Column<string>(nullable: true),
                    ScheduleDayID = table.Column<long>(nullable: false),
                    SortingOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDayNote", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScheduleDayNote_ScheduleDay_ScheduleDayID",
                        column: x => x.ScheduleDayID,
                        principalTable: "ScheduleDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleScene",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    PageLength = table.Column<int>(nullable: false),
                    SceneID = table.Column<long>(nullable: false),
                    ScheduleDayID = table.Column<long>(nullable: false),
                    SortingOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleScene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScheduleScene_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleScene_ScheduleDay_ScheduleDayID",
                        column: x => x.ScheduleDayID,
                        principalTable: "ScheduleDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDay_ProjectID",
                table: "ScheduleDay",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDayNote_ScheduleDayID",
                table: "ScheduleDayNote",
                column: "ScheduleDayID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleScene_SceneID",
                table: "ScheduleScene",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleScene_ScheduleDayID",
                table: "ScheduleScene",
                column: "ScheduleDayID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleDayNote");

            migrationBuilder.DropTable(
                name: "ScheduleScene");

            migrationBuilder.DropTable(
                name: "ScheduleDay");
        }
    }
}
