using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class userinvitation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInvitation",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AcceptedDate = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInvitation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUserInvitation",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProjectID = table.Column<long>(nullable: false),
                    RoleID = table.Column<long>(nullable: true),
                    UserInvitationID = table.Column<long>(nullable: false),
                    UserInvitationID1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUserInvitation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectUserInvitation_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUserInvitation_ProjectRoleDefinitions_RoleID",
                        column: x => x.RoleID,
                        principalTable: "ProjectRoleDefinitions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectUserInvitation_UserInvitation_UserInvitationID1",
                        column: x => x.UserInvitationID1,
                        principalTable: "UserInvitation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserInvitation_ProjectID",
                table: "ProjectUserInvitation",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserInvitation_RoleID",
                table: "ProjectUserInvitation",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserInvitation_UserInvitationID1",
                table: "ProjectUserInvitation",
                column: "UserInvitationID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectUserInvitation");

            migrationBuilder.DropTable(
                name: "UserInvitation");
        }
    }
}
