using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class renamelocationsamendscriptlocationid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageScriptLocation_ScriptLocations_ScriptLocationID",
                table: "ImageScriptLocation");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "ImageScriptLocation");

            migrationBuilder.AlterColumn<long>(
                name: "ScriptLocationID",
                table: "Scenes",
                nullable: false);

            migrationBuilder.AlterColumn<long>(
                name: "ScriptLocationID",
                table: "ImageScriptLocation",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageScriptLocation_ScriptLocations_ScriptLocationID",
                table: "ImageScriptLocation",
                column: "ScriptLocationID",
                principalTable: "ScriptLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageScriptLocation_ScriptLocations_ScriptLocationID",
                table: "ImageScriptLocation");

            migrationBuilder.AddColumn<long>(
                name: "LocationID",
                table: "Scenes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LocationID",
                table: "ImageScriptLocation",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "ScriptLocationID",
                table: "Scenes",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ScriptLocationID",
                table: "ImageScriptLocation",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageScriptLocation_ScriptLocations_ScriptLocationID",
                table: "ImageScriptLocation",
                column: "ScriptLocationID",
                principalTable: "ScriptLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
