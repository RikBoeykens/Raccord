using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class unitcrewmember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrewMember_ProjectUser_ProjectUserID",
                table: "CrewMember");

            migrationBuilder.DropIndex(
                name: "IX_CrewMember_ProjectUserID",
                table: "CrewMember");

            migrationBuilder.DropColumn(
                name: "ProjectUserID",
                table: "CrewMember");

            migrationBuilder.AddColumn<long>(
                name: "CrewUnitMemberID",
                table: "CrewMember",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrewMember_CrewUnitMemberID",
                table: "CrewMember",
                column: "CrewUnitMemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewMember_CrewUnitMember_CrewUnitMemberID",
                table: "CrewMember",
                column: "CrewUnitMemberID",
                principalTable: "CrewUnitMember",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrewMember_CrewUnitMember_CrewUnitMemberID",
                table: "CrewMember");

            migrationBuilder.DropIndex(
                name: "IX_CrewMember_CrewUnitMemberID",
                table: "CrewMember");

            migrationBuilder.DropColumn(
                name: "CrewUnitMemberID",
                table: "CrewMember");

            migrationBuilder.AddColumn<long>(
                name: "ProjectUserID",
                table: "CrewMember",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrewMember_ProjectUserID",
                table: "CrewMember",
                column: "ProjectUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewMember_ProjectUser_ProjectUserID",
                table: "CrewMember",
                column: "ProjectUserID",
                principalTable: "ProjectUser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
