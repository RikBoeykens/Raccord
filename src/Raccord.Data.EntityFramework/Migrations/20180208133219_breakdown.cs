using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class breakdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreakdownType_Projects_ProjectID",
                table: "BreakdownType");

            migrationBuilder.DropIndex(
                name: "IX_BreakdownType_ProjectID",
                table: "BreakdownType");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "BreakdownType");

            migrationBuilder.CreateTable(
                name: "Breakdown",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CreatedByID = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDefaultProjectBreakdown = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakdown", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Breakdown_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Breakdown_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<long>(
                name: "SelectedBreakdownID",
                table: "ProjectUser",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BreakdownID",
                table: "BreakdownType",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BreakdownID",
                table: "BreakdownItem",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "OpenIddictScopes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "OpenIddictAuthorizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Permissions",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_SelectedBreakdownID",
                table: "ProjectUser",
                column: "SelectedBreakdownID");

            migrationBuilder.CreateIndex(
                name: "IX_BreakdownType_BreakdownID",
                table: "BreakdownType",
                column: "BreakdownID");

            migrationBuilder.CreateIndex(
                name: "IX_BreakdownItem_BreakdownID",
                table: "BreakdownItem",
                column: "BreakdownID");

            migrationBuilder.CreateIndex(
                name: "IX_Breakdown_CreatedByID",
                table: "Breakdown",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Breakdown_ProjectID",
                table: "Breakdown",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_BreakdownItem_Breakdown_BreakdownID",
                table: "BreakdownItem",
                column: "BreakdownID",
                principalTable: "Breakdown",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BreakdownType_Breakdown_BreakdownID",
                table: "BreakdownType",
                column: "BreakdownID",
                principalTable: "Breakdown",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_Breakdown_SelectedBreakdownID",
                table: "ProjectUser",
                column: "SelectedBreakdownID",
                principalTable: "Breakdown",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreakdownItem_Breakdown_BreakdownID",
                table: "BreakdownItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BreakdownType_Breakdown_BreakdownID",
                table: "BreakdownType");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_Breakdown_SelectedBreakdownID",
                table: "ProjectUser");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUser_SelectedBreakdownID",
                table: "ProjectUser");

            migrationBuilder.DropIndex(
                name: "IX_BreakdownType_BreakdownID",
                table: "BreakdownType");

            migrationBuilder.DropIndex(
                name: "IX_BreakdownItem_BreakdownID",
                table: "BreakdownItem");

            migrationBuilder.DropColumn(
                name: "SelectedBreakdownID",
                table: "ProjectUser");

            migrationBuilder.DropColumn(
                name: "BreakdownID",
                table: "BreakdownType");

            migrationBuilder.DropColumn(
                name: "BreakdownID",
                table: "BreakdownItem");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "OpenIddictAuthorizations");

            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "OpenIddictApplications");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "OpenIddictApplications");

            migrationBuilder.DropTable(
                name: "Breakdown");

            migrationBuilder.AddColumn<long>(
                name: "ProjectID",
                table: "BreakdownType",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_BreakdownType_ProjectID",
                table: "BreakdownType",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_BreakdownType_Projects_ProjectID",
                table: "BreakdownType",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
