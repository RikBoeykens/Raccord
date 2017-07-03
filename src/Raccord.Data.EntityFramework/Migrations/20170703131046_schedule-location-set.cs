using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class schedulelocationset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LocationSetID",
                table: "ScheduleScene",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleScene_LocationSetID",
                table: "ScheduleScene",
                column: "LocationSetID");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleScene_LocationSet_LocationSetID",
                table: "ScheduleScene",
                column: "LocationSetID",
                principalTable: "LocationSet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleScene_LocationSet_LocationSetID",
                table: "ScheduleScene");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleScene_LocationSetID",
                table: "ScheduleScene");

            migrationBuilder.DropColumn(
                name: "LocationSetID",
                table: "ScheduleScene");
        }
    }
}
