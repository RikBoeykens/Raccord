using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class shootingdayscenes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShootingDayScene",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    LocationSetID = table.Column<long>(nullable: true),
                    PageLength = table.Column<int>(nullable: false),
                    SceneID = table.Column<long>(nullable: false),
                    ShootingDayID = table.Column<long>(nullable: false),
                    Timings = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShootingDayScene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShootingDayScene_LocationSet_LocationSetID",
                        column: x => x.LocationSetID,
                        principalTable: "LocationSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShootingDayScene_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShootingDayScene_ShootingDay_ShootingDayID",
                        column: x => x.ShootingDayID,
                        principalTable: "ShootingDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "ShootingDay",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "ShootingDay",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Turn",
                table: "ShootingDay",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDayScene_LocationSetID",
                table: "ShootingDayScene",
                column: "LocationSetID");

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDayScene_SceneID",
                table: "ShootingDayScene",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDayScene_ShootingDayID",
                table: "ShootingDayScene",
                column: "ShootingDayID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "ShootingDay");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "ShootingDay");

            migrationBuilder.DropColumn(
                name: "Turn",
                table: "ShootingDay");

            migrationBuilder.DropTable(
                name: "ShootingDayScene");
        }
    }
}
