using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class projectuserroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RoleID",
                table: "ProjectUser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_RoleID",
                table: "ProjectUser",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_ProjectRoleDefinitions_RoleID",
                table: "ProjectUser",
                column: "RoleID",
                principalTable: "ProjectRoleDefinitions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_ProjectRoleDefinitions_RoleID",
                table: "ProjectUser");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUser_RoleID",
                table: "ProjectUser");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "ProjectUser");
        }
    }
}
