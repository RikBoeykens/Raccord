using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class shootingdaycompletionenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletesScene",
                table: "ShootingDayScene");

            migrationBuilder.AddColumn<int>(
                name: "Completion",
                table: "ShootingDayScene",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completion",
                table: "ShootingDayScene");

            migrationBuilder.AddColumn<bool>(
                name: "CompletesScene",
                table: "ShootingDayScene",
                nullable: false,
                defaultValue: false);
        }
    }
}
