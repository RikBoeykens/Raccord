using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class slatestakes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slate",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Aperture = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Filters = table.Column<string>(nullable: true),
                    Lens = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    SceneID = table.Column<long>(nullable: false),
                    ShootingDayID = table.Column<long>(nullable: false),
                    Sound = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Slate_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slate_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slate_ShootingDay_ShootingDayID",
                        column: x => x.ShootingDayID,
                        principalTable: "ShootingDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Take",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CameraRoll = table.Column<string>(nullable: true),
                    Length = table.Column<TimeSpan>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false),
                    SlateID = table.Column<long>(nullable: false),
                    SoundRoll = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Take", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Take_Slate_SlateID",
                        column: x => x.SlateID,
                        principalTable: "Slate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slate_ProjectID",
                table: "Slate",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Slate_SceneID",
                table: "Slate",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_Slate_ShootingDayID",
                table: "Slate",
                column: "ShootingDayID");

            migrationBuilder.CreateIndex(
                name: "IX_Take_SlateID",
                table: "Take",
                column: "SlateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Take");

            migrationBuilder.DropTable(
                name: "Slate");
        }
    }
}
