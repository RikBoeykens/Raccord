using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class crewunitmembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrewUnitMember",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CrewUnitID = table.Column<long>(nullable: false),
                    ProjectUserID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewUnitMember", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrewUnitMember_CrewUnit_CrewUnitID",
                        column: x => x.CrewUnitID,
                        principalTable: "CrewUnit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrewUnitMember_ProjectUser_ProjectUserID",
                        column: x => x.ProjectUserID,
                        principalTable: "ProjectUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrewUnitMember_CrewUnitID",
                table: "CrewUnitMember",
                column: "CrewUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewUnitMember_ProjectUserID",
                table: "CrewUnitMember",
                column: "ProjectUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrewUnitMember");
        }
    }
}
