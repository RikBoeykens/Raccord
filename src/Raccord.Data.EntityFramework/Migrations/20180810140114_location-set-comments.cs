using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class locationsetcomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentLocationSetID",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentLocationSetID",
                table: "Comment",
                column: "ParentLocationSetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_LocationSet_ParentLocationSetID",
                table: "Comment",
                column: "ParentLocationSetID",
                principalTable: "LocationSet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_LocationSet_ParentLocationSetID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ParentLocationSetID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ParentLocationSetID",
                table: "Comment");
        }
    }
}
