using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class removelinkcrewmemberprojectuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_CrewMember_CrewMemberID",
                table: "ProjectUser");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUser_CrewMemberID",
                table: "ProjectUser");

            migrationBuilder.DropColumn(
                name: "CrewMemberID",
                table: "ProjectUser");

            migrationBuilder.DropColumn(
                name: "ProjectUserID",
                table: "CrewMember");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CrewMemberID",
                table: "ProjectUser",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProjectUserID",
                table: "CrewMember",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_CrewMemberID",
                table: "ProjectUser",
                column: "CrewMemberID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_CrewMember_CrewMemberID",
                table: "ProjectUser",
                column: "CrewMemberID",
                principalTable: "CrewMember",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
