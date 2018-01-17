using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class projectrolesfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPermissionRoleDefinitions_ProjectPermissionDefinitions_ProjectPermissionID",
                table: "ProjectPermissionRoleDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPermissionRoleDefinitions_ProjectRoleDefinitions_ProjectRoleID",
                table: "ProjectPermissionRoleDefinitions");

            migrationBuilder.DropColumn(
                name: "PermissionID",
                table: "ProjectPermissionRoleDefinitions");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "ProjectPermissionRoleDefinitions");

            migrationBuilder.AlterColumn<long>(
                name: "ProjectRoleID",
                table: "ProjectPermissionRoleDefinitions",
                nullable: false);

            migrationBuilder.AlterColumn<long>(
                name: "ProjectPermissionID",
                table: "ProjectPermissionRoleDefinitions",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPermissionRoleDefinitions_ProjectPermissionDefinitions_ProjectPermissionID",
                table: "ProjectPermissionRoleDefinitions",
                column: "ProjectPermissionID",
                principalTable: "ProjectPermissionDefinitions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPermissionRoleDefinitions_ProjectRoleDefinitions_ProjectRoleID",
                table: "ProjectPermissionRoleDefinitions",
                column: "ProjectRoleID",
                principalTable: "ProjectRoleDefinitions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPermissionRoleDefinitions_ProjectPermissionDefinitions_ProjectPermissionID",
                table: "ProjectPermissionRoleDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPermissionRoleDefinitions_ProjectRoleDefinitions_ProjectRoleID",
                table: "ProjectPermissionRoleDefinitions");

            migrationBuilder.AddColumn<long>(
                name: "PermissionID",
                table: "ProjectPermissionRoleDefinitions",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RoleID",
                table: "ProjectPermissionRoleDefinitions",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "ProjectRoleID",
                table: "ProjectPermissionRoleDefinitions",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProjectPermissionID",
                table: "ProjectPermissionRoleDefinitions",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPermissionRoleDefinitions_ProjectPermissionDefinitions_ProjectPermissionID",
                table: "ProjectPermissionRoleDefinitions",
                column: "ProjectPermissionID",
                principalTable: "ProjectPermissionDefinitions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPermissionRoleDefinitions_ProjectRoleDefinitions_ProjectRoleID",
                table: "ProjectPermissionRoleDefinitions",
                column: "ProjectRoleID",
                principalTable: "ProjectRoleDefinitions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
