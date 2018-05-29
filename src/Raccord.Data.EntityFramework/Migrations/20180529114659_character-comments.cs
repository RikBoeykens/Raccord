using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class charactercomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Character_CharacterID",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "CharacterID",
                table: "Comment",
                newName: "ParentCharacterID");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CharacterID",
                table: "Comment",
                newName: "IX_Comment_ParentCharacterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Character_ParentCharacterID",
                table: "Comment",
                column: "ParentCharacterID",
                principalTable: "Character",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Character_ParentCharacterID",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "ParentCharacterID",
                table: "Comment",
                newName: "CharacterID");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ParentCharacterID",
                table: "Comment",
                newName: "IX_Comment_CharacterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Character_CharacterID",
                table: "Comment",
                column: "CharacterID",
                principalTable: "Character",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
