using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class shotssortingorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slate_Scenes_SceneID",
                table: "Slate");

            migrationBuilder.DropForeignKey(
                name: "FK_Slate_ShootingDay_ShootingDayID",
                table: "Slate");

            migrationBuilder.AddColumn<int>(
                name: "SortingOrder",
                table: "Take",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortingOrder",
                table: "Slate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "ShootingDayID",
                table: "Slate",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SceneID",
                table: "Slate",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Slate_Scenes_SceneID",
                table: "Slate",
                column: "SceneID",
                principalTable: "Scenes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slate_ShootingDay_ShootingDayID",
                table: "Slate",
                column: "ShootingDayID",
                principalTable: "ShootingDay",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slate_Scenes_SceneID",
                table: "Slate");

            migrationBuilder.DropForeignKey(
                name: "FK_Slate_ShootingDay_ShootingDayID",
                table: "Slate");

            migrationBuilder.DropColumn(
                name: "SortingOrder",
                table: "Take");

            migrationBuilder.DropColumn(
                name: "SortingOrder",
                table: "Slate");

            migrationBuilder.AlterColumn<long>(
                name: "ShootingDayID",
                table: "Slate",
                nullable: false);

            migrationBuilder.AlterColumn<long>(
                name: "SceneID",
                table: "Slate",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Slate_Scenes_SceneID",
                table: "Slate",
                column: "SceneID",
                principalTable: "Scenes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slate_ShootingDay_ShootingDayID",
                table: "Slate",
                column: "ShootingDayID",
                principalTable: "ShootingDay",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
