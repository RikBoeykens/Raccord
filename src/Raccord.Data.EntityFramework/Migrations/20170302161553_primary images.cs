using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class primaryimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrimaryImage",
                table: "ImageScene",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimaryImage",
                table: "ImageLocation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimaryImage",
                table: "Image",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrimaryImage",
                table: "ImageScene");

            migrationBuilder.DropColumn(
                name: "IsPrimaryImage",
                table: "ImageLocation");

            migrationBuilder.DropColumn(
                name: "IsPrimaryImage",
                table: "Image");
        }
    }
}
