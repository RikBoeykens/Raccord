using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class extracomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CallsheetID",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CharacterID",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentBreakdownItemID",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentImageID",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentLocationID",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentSceneID",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentScriptLocationID",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentSlateID",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentTakeID",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CallsheetID",
                table: "Comment",
                column: "CallsheetID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CharacterID",
                table: "Comment",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentBreakdownItemID",
                table: "Comment",
                column: "ParentBreakdownItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentImageID",
                table: "Comment",
                column: "ParentImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentLocationID",
                table: "Comment",
                column: "ParentLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentSceneID",
                table: "Comment",
                column: "ParentSceneID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentScriptLocationID",
                table: "Comment",
                column: "ParentScriptLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentSlateID",
                table: "Comment",
                column: "ParentSlateID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentTakeID",
                table: "Comment",
                column: "ParentTakeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Callsheet_CallsheetID",
                table: "Comment",
                column: "CallsheetID",
                principalTable: "Callsheet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Character_CharacterID",
                table: "Comment",
                column: "CharacterID",
                principalTable: "Character",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_BreakdownItem_ParentBreakdownItemID",
                table: "Comment",
                column: "ParentBreakdownItemID",
                principalTable: "BreakdownItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Image_ParentImageID",
                table: "Comment",
                column: "ParentImageID",
                principalTable: "Image",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Location_ParentLocationID",
                table: "Comment",
                column: "ParentLocationID",
                principalTable: "Location",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Scenes_ParentSceneID",
                table: "Comment",
                column: "ParentSceneID",
                principalTable: "Scenes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ScriptLocations_ParentScriptLocationID",
                table: "Comment",
                column: "ParentScriptLocationID",
                principalTable: "ScriptLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Slate_ParentSlateID",
                table: "Comment",
                column: "ParentSlateID",
                principalTable: "Slate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Take_ParentTakeID",
                table: "Comment",
                column: "ParentTakeID",
                principalTable: "Take",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Callsheet_CallsheetID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Character_CharacterID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_BreakdownItem_ParentBreakdownItemID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Image_ParentImageID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Location_ParentLocationID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Scenes_ParentSceneID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ScriptLocations_ParentScriptLocationID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Slate_ParentSlateID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Take_ParentTakeID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CallsheetID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CharacterID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ParentBreakdownItemID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ParentImageID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ParentLocationID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ParentSceneID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ParentScriptLocationID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ParentSlateID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ParentTakeID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CallsheetID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CharacterID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ParentBreakdownItemID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ParentImageID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ParentLocationID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ParentSceneID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ParentScriptLocationID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ParentSlateID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ParentTakeID",
                table: "Comment");
        }
    }
}
