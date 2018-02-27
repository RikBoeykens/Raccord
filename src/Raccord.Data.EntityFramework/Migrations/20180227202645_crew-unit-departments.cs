using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class crewunitdepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrewDepartment_Projects_ProjectID",
                table: "CrewDepartment");

            migrationBuilder.DropIndex(
                name: "IX_CrewDepartment_ProjectID",
                table: "CrewDepartment");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "CrewDepartment");

            migrationBuilder.AddColumn<long>(
                name: "CrewUnitID",
                table: "CrewDepartment",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CrewDepartment_CrewUnitID",
                table: "CrewDepartment",
                column: "CrewUnitID");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewDepartment_CrewUnit_CrewUnitID",
                table: "CrewDepartment",
                column: "CrewUnitID",
                principalTable: "CrewUnit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrewDepartment_CrewUnit_CrewUnitID",
                table: "CrewDepartment");

            migrationBuilder.DropIndex(
                name: "IX_CrewDepartment_CrewUnitID",
                table: "CrewDepartment");

            migrationBuilder.DropColumn(
                name: "CrewUnitID",
                table: "CrewDepartment");

            migrationBuilder.AddColumn<long>(
                name: "ProjectID",
                table: "CrewDepartment",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CrewDepartment_ProjectID",
                table: "CrewDepartment",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewDepartment_Projects_ProjectID",
                table: "CrewDepartment",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
