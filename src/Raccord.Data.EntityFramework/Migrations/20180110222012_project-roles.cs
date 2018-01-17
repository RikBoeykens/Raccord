using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class projectroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectPermissionDefinitions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Permission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPermissionDefinitions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRoleDefinitions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRoleDefinitions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPermissionRoleDefinitions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    PermissionID = table.Column<long>(nullable: false),
                    ProjectPermissionID = table.Column<long>(nullable: true),
                    ProjectRoleID = table.Column<long>(nullable: true),
                    RoleID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPermissionRoleDefinitions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectPermissionRoleDefinitions_ProjectPermissionDefinitions_ProjectPermissionID",
                        column: x => x.ProjectPermissionID,
                        principalTable: "ProjectPermissionDefinitions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectPermissionRoleDefinitions_ProjectRoleDefinitions_ProjectRoleID",
                        column: x => x.ProjectRoleID,
                        principalTable: "ProjectRoleDefinitions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPermissionRoleDefinitions_ProjectPermissionID",
                table: "ProjectPermissionRoleDefinitions",
                column: "ProjectPermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPermissionRoleDefinitions_ProjectRoleID",
                table: "ProjectPermissionRoleDefinitions",
                column: "ProjectRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPermissionRoleDefinitions");

            migrationBuilder.DropTable(
                name: "ProjectPermissionDefinitions");

            migrationBuilder.DropTable(
                name: "ProjectRoleDefinitions");
        }
    }
}
