using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class callsheets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Callsheet",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    ShootingDayID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Callsheet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Callsheet_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Callsheet_ShootingDay_ShootingDayID",
                        column: x => x.ShootingDayID,
                        principalTable: "ShootingDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<long>(
                name: "CallsheetID",
                table: "ShootingDay",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Callsheet_ProjectID",
                table: "Callsheet",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Callsheet_ShootingDayID",
                table: "Callsheet",
                column: "ShootingDayID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallsheetID",
                table: "ShootingDay");

            migrationBuilder.DropTable(
                name: "Callsheet");
        }
    }
}
