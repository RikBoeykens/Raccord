﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class crewmember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                table: "OpenIddictTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                table: "OpenIddictTokens");

            migrationBuilder.DropIndex(
                name: "IX_OpenIddictTokens_Hash",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "Ciphertext",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "Hash",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "Scopes",
                table: "OpenIddictAuthorizations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OpenIddictAuthorizations");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "OpenIddictAuthorizations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "OpenIddictAuthorizations");

            migrationBuilder.DropColumn(
                name: "PostLogoutRedirectUris",
                table: "OpenIddictApplications");

            migrationBuilder.DropColumn(
                name: "RedirectUris",
                table: "OpenIddictApplications");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "OpenIddictApplications");

            migrationBuilder.CreateTable(
                name: "CrewMember",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    DepartmentID = table.Column<long>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewMember", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrewMember_CrewDepartment_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "CrewDepartment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<string>(
                name: "Scope",
                table: "OpenIddictAuthorizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoutRedirectUri",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RedirectUri",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "OpenIddictAuthorizations",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrewMember_DepartmentID",
                table: "CrewMember",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                table: "OpenIddictTokens",
                column: "ApplicationId",
                principalTable: "OpenIddictApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                table: "OpenIddictTokens",
                column: "AuthorizationId",
                principalTable: "OpenIddictAuthorizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                table: "OpenIddictTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "Scope",
                table: "OpenIddictAuthorizations");

            migrationBuilder.DropColumn(
                name: "LogoutRedirectUri",
                table: "OpenIddictApplications");

            migrationBuilder.DropColumn(
                name: "RedirectUri",
                table: "OpenIddictApplications");

            migrationBuilder.DropTable(
                name: "CrewMember");

            migrationBuilder.AddColumn<string>(
                name: "Ciphertext",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExpirationDate",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "OpenIddictTokens",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OpenIddictScopes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "OpenIddictScopes",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Scopes",
                table: "OpenIddictAuthorizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "OpenIddictAuthorizations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "OpenIddictAuthorizations",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "OpenIddictAuthorizations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostLogoutRedirectUris",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RedirectUris",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "OpenIddictApplications",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "OpenIddictTokens",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "OpenIddictTokens",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_Hash",
                table: "OpenIddictTokens",
                column: "Hash",
                unique: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "OpenIddictAuthorizations",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "OpenIddictApplications",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "OpenIddictApplications",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                table: "OpenIddictTokens",
                column: "ApplicationId",
                principalTable: "OpenIddictApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                table: "OpenIddictTokens",
                column: "AuthorizationId",
                principalTable: "OpenIddictAuthorizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
