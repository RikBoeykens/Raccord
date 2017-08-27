using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class shootingdayscheduledaycascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShootingDayScene_CallsheetScene_CallsheetSceneID",
                table: "ShootingDayScene");

            migrationBuilder.AddForeignKey(
                name: "FK_ShootingDayScene_CallsheetScene_CallsheetSceneID",
                table: "ShootingDayScene",
                column: "CallsheetSceneID",
                principalTable: "CallsheetScene",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShootingDayScene_CallsheetScene_CallsheetSceneID",
                table: "ShootingDayScene");

            migrationBuilder.AddForeignKey(
                name: "FK_ShootingDayScene_CallsheetScene_CallsheetSceneID",
                table: "ShootingDayScene",
                column: "CallsheetSceneID",
                principalTable: "CallsheetScene",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
