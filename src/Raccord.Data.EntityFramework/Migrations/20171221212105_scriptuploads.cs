using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class scriptuploads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScriptUpload",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    End = table.Column<DateTime>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScriptUpload", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScriptUpload_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<long>(
                name: "ScriptUploadID",
                table: "ScriptLocations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScriptUploadID",
                table: "Scenes",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScriptUploadID",
                table: "IntExts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScriptUploadID",
                table: "DayNights",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScriptUploadID",
                table: "Character",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScriptLocations_ScriptUploadID",
                table: "ScriptLocations",
                column: "ScriptUploadID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_ScriptUploadID",
                table: "Scenes",
                column: "ScriptUploadID");

            migrationBuilder.CreateIndex(
                name: "IX_IntExts_ScriptUploadID",
                table: "IntExts",
                column: "ScriptUploadID");

            migrationBuilder.CreateIndex(
                name: "IX_DayNights_ScriptUploadID",
                table: "DayNights",
                column: "ScriptUploadID");

            migrationBuilder.CreateIndex(
                name: "IX_Character_ScriptUploadID",
                table: "Character",
                column: "ScriptUploadID");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptUpload_ProjectID",
                table: "ScriptUpload",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_ScriptUpload_ScriptUploadID",
                table: "Character",
                column: "ScriptUploadID",
                principalTable: "ScriptUpload",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayNights_ScriptUpload_ScriptUploadID",
                table: "DayNights",
                column: "ScriptUploadID",
                principalTable: "ScriptUpload",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IntExts_ScriptUpload_ScriptUploadID",
                table: "IntExts",
                column: "ScriptUploadID",
                principalTable: "ScriptUpload",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scenes_ScriptUpload_ScriptUploadID",
                table: "Scenes",
                column: "ScriptUploadID",
                principalTable: "ScriptUpload",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptLocations_ScriptUpload_ScriptUploadID",
                table: "ScriptLocations",
                column: "ScriptUploadID",
                principalTable: "ScriptUpload",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_ScriptUpload_ScriptUploadID",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_DayNights_ScriptUpload_ScriptUploadID",
                table: "DayNights");

            migrationBuilder.DropForeignKey(
                name: "FK_IntExts_ScriptUpload_ScriptUploadID",
                table: "IntExts");

            migrationBuilder.DropForeignKey(
                name: "FK_Scenes_ScriptUpload_ScriptUploadID",
                table: "Scenes");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptLocations_ScriptUpload_ScriptUploadID",
                table: "ScriptLocations");

            migrationBuilder.DropIndex(
                name: "IX_ScriptLocations_ScriptUploadID",
                table: "ScriptLocations");

            migrationBuilder.DropIndex(
                name: "IX_Scenes_ScriptUploadID",
                table: "Scenes");

            migrationBuilder.DropIndex(
                name: "IX_IntExts_ScriptUploadID",
                table: "IntExts");

            migrationBuilder.DropIndex(
                name: "IX_DayNights_ScriptUploadID",
                table: "DayNights");

            migrationBuilder.DropIndex(
                name: "IX_Character_ScriptUploadID",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "ScriptUploadID",
                table: "ScriptLocations");

            migrationBuilder.DropColumn(
                name: "ScriptUploadID",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "ScriptUploadID",
                table: "IntExts");

            migrationBuilder.DropColumn(
                name: "ScriptUploadID",
                table: "DayNights");

            migrationBuilder.DropColumn(
                name: "ScriptUploadID",
                table: "Character");

            migrationBuilder.DropTable(
                name: "ScriptUpload");
        }
    }
}
