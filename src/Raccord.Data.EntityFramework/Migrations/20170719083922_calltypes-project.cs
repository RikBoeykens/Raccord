using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class calltypesproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDay_ShootingDay_ShootingDayID",
                table: "ScheduleDay");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleDay_ShootingDayID",
                table: "ScheduleDay");

            migrationBuilder.CreateTable(
                name: "CallTypeDefinitions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    SortingOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallTypeDefinitions", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDay_ScheduleDayID",
                table: "ShootingDay",
                column: "ScheduleDayID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShootingDay_ScheduleDay_ScheduleDayID",
                table: "ShootingDay",
                column: "ScheduleDayID",
                principalTable: "ScheduleDay",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShootingDay_ScheduleDay_ScheduleDayID",
                table: "ShootingDay");

            migrationBuilder.DropIndex(
                name: "IX_ShootingDay_ScheduleDayID",
                table: "ShootingDay");

            migrationBuilder.DropTable(
                name: "CallTypeDefinitions");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDay_ShootingDayID",
                table: "ScheduleDay",
                column: "ShootingDayID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDay_ShootingDay_ShootingDayID",
                table: "ScheduleDay",
                column: "ShootingDayID",
                principalTable: "ShootingDay",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
