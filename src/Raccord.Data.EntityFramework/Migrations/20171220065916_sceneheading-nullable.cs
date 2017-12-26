using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class sceneheadingnullable : Migration
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
                name: "Hash",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "OpenIddictAuthorizations");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "OpenIddictApplications");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyToken",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payload",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceId",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyToken",
                table: "OpenIddictScopes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyToken",
                table: "OpenIddictAuthorizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyToken",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ScriptLocationID",
                table: "Scenes",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IntExtID",
                table: "Scenes",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DayNightID",
                table: "Scenes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens",
                column: "ReferenceId",
                unique: true);

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

            migrationBuilder.DropIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "Payload",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "OpenIddictAuthorizations");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "OpenIddictApplications");

            migrationBuilder.AddColumn<string>(
                name: "Ciphertext",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "OpenIddictTokens",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "OpenIddictScopes",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "OpenIddictAuthorizations",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "OpenIddictApplications",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ScriptLocationID",
                table: "Scenes",
                nullable: false);

            migrationBuilder.AlterColumn<long>(
                name: "IntExtID",
                table: "Scenes",
                nullable: false);

            migrationBuilder.AlterColumn<long>(
                name: "DayNightID",
                table: "Scenes",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_Hash",
                table: "OpenIddictTokens",
                column: "Hash",
                unique: true);

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
