using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class crewunitschedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Callsheet_Projects_ProjectID",
                table: "Callsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDay_Projects_ProjectID",
                table: "ScheduleDay");

            migrationBuilder.DropForeignKey(
                name: "FK_ShootingDay_Projects_ProjectID",
                table: "ShootingDay");

            migrationBuilder.DropIndex(
                name: "IX_ShootingDay_ProjectID",
                table: "ShootingDay");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleDay_ProjectID",
                table: "ScheduleDay");

            migrationBuilder.DropIndex(
                name: "IX_Callsheet_ProjectID",
                table: "Callsheet");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "ShootingDay");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "ScheduleDay");

            migrationBuilder.DropColumn(
                name: "PublishedSchedule",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Callsheet");

            migrationBuilder.AddColumn<long>(
                name: "CrewUnitID",
                table: "ShootingDay",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CrewUnitID",
                table: "ScheduleDay",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CrewUnitID",
                table: "Callsheet",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDay_CrewUnitID",
                table: "ShootingDay",
                column: "CrewUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDay_CrewUnitID",
                table: "ScheduleDay",
                column: "CrewUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Callsheet_CrewUnitID",
                table: "Callsheet",
                column: "CrewUnitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Callsheet_CrewUnit_CrewUnitID",
                table: "Callsheet",
                column: "CrewUnitID",
                principalTable: "CrewUnit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDay_CrewUnit_CrewUnitID",
                table: "ScheduleDay",
                column: "CrewUnitID",
                principalTable: "CrewUnit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShootingDay_CrewUnit_CrewUnitID",
                table: "ShootingDay",
                column: "CrewUnitID",
                principalTable: "CrewUnit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Callsheet_CrewUnit_CrewUnitID",
                table: "Callsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDay_CrewUnit_CrewUnitID",
                table: "ScheduleDay");

            migrationBuilder.DropForeignKey(
                name: "FK_ShootingDay_CrewUnit_CrewUnitID",
                table: "ShootingDay");

            migrationBuilder.DropIndex(
                name: "IX_ShootingDay_CrewUnitID",
                table: "ShootingDay");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleDay_CrewUnitID",
                table: "ScheduleDay");

            migrationBuilder.DropIndex(
                name: "IX_Callsheet_CrewUnitID",
                table: "Callsheet");

            migrationBuilder.DropColumn(
                name: "CrewUnitID",
                table: "ShootingDay");

            migrationBuilder.DropColumn(
                name: "CrewUnitID",
                table: "ScheduleDay");

            migrationBuilder.DropColumn(
                name: "CrewUnitID",
                table: "Callsheet");

            migrationBuilder.AddColumn<long>(
                name: "ProjectID",
                table: "ShootingDay",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProjectID",
                table: "ScheduleDay",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "PublishedSchedule",
                table: "Projects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ProjectID",
                table: "Callsheet",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDay_ProjectID",
                table: "ShootingDay",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDay_ProjectID",
                table: "ScheduleDay",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Callsheet_ProjectID",
                table: "Callsheet",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Callsheet_Projects_ProjectID",
                table: "Callsheet",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDay_Projects_ProjectID",
                table: "ScheduleDay",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShootingDay_Projects_ProjectID",
                table: "ShootingDay",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
