using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class commentadditionalcascadedelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_BreakdownItem_ParentBreakdownItemID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Characters_ParentCharacterID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Image_ParentImageID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Location_ParentLocationID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Projects_ParentProjectID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Scenes_ParentSceneID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Slate_ParentSlateID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Take_ParentTakeID",
                table: "Comment");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_BreakdownItem_ParentBreakdownItemID",
                table: "Comment",
                column: "ParentBreakdownItemID",
                principalTable: "BreakdownItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Characters_ParentCharacterID",
                table: "Comment",
                column: "ParentCharacterID",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Image_ParentImageID",
                table: "Comment",
                column: "ParentImageID",
                principalTable: "Image",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Location_ParentLocationID",
                table: "Comment",
                column: "ParentLocationID",
                principalTable: "Location",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Projects_ParentProjectID",
                table: "Comment",
                column: "ParentProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Scenes_ParentSceneID",
                table: "Comment",
                column: "ParentSceneID",
                principalTable: "Scenes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Slate_ParentSlateID",
                table: "Comment",
                column: "ParentSlateID",
                principalTable: "Slate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Take_ParentTakeID",
                table: "Comment",
                column: "ParentTakeID",
                principalTable: "Take",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_BreakdownItem_ParentBreakdownItemID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Characters_ParentCharacterID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Image_ParentImageID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Location_ParentLocationID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Projects_ParentProjectID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Scenes_ParentSceneID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Slate_ParentSlateID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Take_ParentTakeID",
                table: "Comment");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_BreakdownItem_ParentBreakdownItemID",
                table: "Comment",
                column: "ParentBreakdownItemID",
                principalTable: "BreakdownItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Characters_ParentCharacterID",
                table: "Comment",
                column: "ParentCharacterID",
                principalTable: "Characters",
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
                name: "FK_Comment_Projects_ParentProjectID",
                table: "Comment",
                column: "ParentProjectID",
                principalTable: "Projects",
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
    }
}
