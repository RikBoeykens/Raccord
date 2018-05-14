using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class castmembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_ProjectUser_ProjectUserID",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_ProjectUserID",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "ProjectUserID",
                table: "Character");

            migrationBuilder.CreateTable(
                name: "CastMember",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    ProjectUserID = table.Column<long>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastMember", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CastMember_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<long>(
                name: "CastMemberID",
                table: "ProjectUser",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CastMemberID",
                table: "Character",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsentType",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_CastMemberID",
                table: "ProjectUser",
                column: "CastMemberID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_CastMemberID",
                table: "Character",
                column: "CastMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_CastMember_ProjectID",
                table: "CastMember",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_CastMember_CastMemberID",
                table: "Character",
                column: "CastMemberID",
                principalTable: "CastMember",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_CastMember_CastMemberID",
                table: "ProjectUser",
                column: "CastMemberID",
                principalTable: "CastMember",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_CastMember_CastMemberID",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_CastMember_CastMemberID",
                table: "ProjectUser");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUser_CastMemberID",
                table: "ProjectUser");

            migrationBuilder.DropIndex(
                name: "IX_Character_CastMemberID",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "CastMemberID",
                table: "ProjectUser");

            migrationBuilder.DropColumn(
                name: "CastMemberID",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "ConsentType",
                table: "OpenIddictApplications");

            migrationBuilder.DropTable(
                name: "CastMember");

            migrationBuilder.AddColumn<long>(
                name: "ProjectUserID",
                table: "Character",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_ProjectUserID",
                table: "Character",
                column: "ProjectUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_ProjectUser_ProjectUserID",
                table: "Character",
                column: "ProjectUserID",
                principalTable: "ProjectUser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
