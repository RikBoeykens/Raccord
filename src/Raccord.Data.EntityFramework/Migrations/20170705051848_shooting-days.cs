using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class shootingdays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShootingDay",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    ScheduleDayID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShootingDay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShootingDay_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShootingDay_ScheduleDay_ScheduleDayID",
                        column: x => x.ScheduleDayID,
                        principalTable: "ScheduleDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<long>(
                name: "ShootingDayID",
                table: "ScheduleDay",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDay_ProjectID",
                table: "ShootingDay",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDay_ScheduleDayID",
                table: "ShootingDay",
                column: "ScheduleDayID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShootingDayID",
                table: "ScheduleDay");

            migrationBuilder.DropTable(
                name: "ShootingDay");
        }
    }
}
