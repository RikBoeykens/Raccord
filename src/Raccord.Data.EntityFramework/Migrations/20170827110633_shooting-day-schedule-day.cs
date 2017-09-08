using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class shootingdayscheduleday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CallsheetSceneID",
                table: "ShootingDayScene",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ShootingDaySceneID",
                table: "CallsheetScene",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDayScene_CallsheetSceneID",
                table: "ShootingDayScene",
                column: "CallsheetSceneID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShootingDayScene_CallsheetScene_CallsheetSceneID",
                table: "ShootingDayScene",
                column: "CallsheetSceneID",
                principalTable: "CallsheetScene",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShootingDayScene_CallsheetScene_CallsheetSceneID",
                table: "ShootingDayScene");

            migrationBuilder.DropIndex(
                name: "IX_ShootingDayScene_CallsheetSceneID",
                table: "ShootingDayScene");

            migrationBuilder.DropColumn(
                name: "CallsheetSceneID",
                table: "ShootingDayScene");

            migrationBuilder.DropColumn(
                name: "ShootingDaySceneID",
                table: "CallsheetScene");
        }
    }
}
