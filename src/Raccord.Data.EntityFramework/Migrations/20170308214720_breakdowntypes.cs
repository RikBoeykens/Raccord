using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class breakdowntypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakdownType",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakdownType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BreakdownType_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreakdownTypeDefinitions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakdownTypeDefinitions", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreakdownType_ProjectID",
                table: "BreakdownType",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakdownType");

            migrationBuilder.DropTable(
                name: "BreakdownTypeDefinitions");
        }
    }
}
