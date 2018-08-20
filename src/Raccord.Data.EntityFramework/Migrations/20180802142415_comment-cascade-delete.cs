using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class commentcascadedelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_ParentCommentID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ScriptLocations_ParentScriptLocationID",
                table: "Comment");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_ParentCommentID",
                table: "Comment",
                column: "ParentCommentID",
                principalTable: "Comment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ScriptLocations_ParentScriptLocationID",
                table: "Comment",
                column: "ParentScriptLocationID",
                principalTable: "ScriptLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_ParentCommentID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ScriptLocations_ParentScriptLocationID",
                table: "Comment");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_ParentCommentID",
                table: "Comment",
                column: "ParentCommentID",
                principalTable: "Comment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ScriptLocations_ParentScriptLocationID",
                table: "Comment",
                column: "ParentScriptLocationID",
                principalTable: "ScriptLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
