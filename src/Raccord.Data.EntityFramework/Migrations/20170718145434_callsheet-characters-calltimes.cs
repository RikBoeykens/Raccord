using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class callsheetcharacterscalltimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallType",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CallType_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallsheetCharacter",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CallsheetID = table.Column<long>(nullable: false),
                    CharacterID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallsheetCharacter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CallsheetCharacter_Callsheet_CallsheetID",
                        column: x => x.CallsheetID,
                        principalTable: "Callsheet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallsheetCharacter_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterCall",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CallTime = table.Column<DateTime>(nullable: false),
                    CallTypeID = table.Column<long>(nullable: false),
                    CallsheetCharacterID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterCall", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CharacterCall_CallType_CallTypeID",
                        column: x => x.CallTypeID,
                        principalTable: "CallType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterCall_CallsheetCharacter_CallsheetCharacterID",
                        column: x => x.CallsheetCharacterID,
                        principalTable: "CallsheetCharacter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<DateTime>(
                name: "CrewCall",
                table: "Callsheet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_CallType_ProjectID",
                table: "CallType",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetCharacter_CallsheetID",
                table: "CallsheetCharacter",
                column: "CallsheetID");

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetCharacter_CharacterID",
                table: "CallsheetCharacter",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCall_CallTypeID",
                table: "CharacterCall",
                column: "CallTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCall_CallsheetCharacterID",
                table: "CharacterCall",
                column: "CallsheetCharacterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrewCall",
                table: "Callsheet");

            migrationBuilder.DropTable(
                name: "CharacterCall");

            migrationBuilder.DropTable(
                name: "CallType");

            migrationBuilder.DropTable(
                name: "CallsheetCharacter");
        }
    }
}
