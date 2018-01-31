using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class nullablesortingorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "Take",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "Slate",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "ScheduleScene",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "ScheduleDayNote",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "Scenes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "CrewDepartmentDefinitions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "CrewDepartment",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "CallsheetScene",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "CallTypeDefinitions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "CallType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "Take",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "Slate",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "ScheduleScene",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "ScheduleDayNote",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "Scenes",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "CrewDepartmentDefinitions",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "CrewDepartment",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "CallsheetScene",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "CallTypeDefinitions",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "SortingOrder",
                table: "CallType",
                nullable: false);
        }
    }
}
