using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class breakdowncreatedbyuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breakdown_AspNetUsers_CreatedByID",
                table: "Breakdown");

            migrationBuilder.DropIndex(
                name: "IX_Breakdown_CreatedByID",
                table: "Breakdown");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Breakdown");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Breakdown",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breakdown_UserID",
                table: "Breakdown",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Breakdown_AspNetUsers_UserID",
                table: "Breakdown",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breakdown_AspNetUsers_UserID",
                table: "Breakdown");

            migrationBuilder.DropIndex(
                name: "IX_Breakdown_UserID",
                table: "Breakdown");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Breakdown");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "Breakdown",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breakdown_CreatedByID",
                table: "Breakdown",
                column: "CreatedByID");

            migrationBuilder.AddForeignKey(
                name: "FK_Breakdown_AspNetUsers_CreatedByID",
                table: "Breakdown",
                column: "CreatedByID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
