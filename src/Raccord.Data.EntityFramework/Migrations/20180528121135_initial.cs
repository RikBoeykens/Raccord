﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    ImageContent = table.Column<byte[]>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    PreferredEmail = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BreakdownTypeDefinitions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakdownTypeDefinitions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CallTypeDefinitions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    SortingOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallTypeDefinitions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CrewDepartmentDefinitions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SortingOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewDepartmentDefinitions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ClientId = table.Column<string>(nullable: false),
                    ClientSecret = table.Column<string>(nullable: true),
                    ConcurrencyToken = table.Column<string>(nullable: true),
                    ConsentType = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Permissions = table.Column<string>(nullable: true),
                    PostLogoutRedirectUris = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    RedirectUris = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyToken = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Properties = table.Column<string>(nullable: true),
                    Resources = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPermissionDefinitions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Permission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPermissionDefinitions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRoleDefinitions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRoleDefinitions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorizations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ApplicationId = table.Column<string>(nullable: true),
                    ConcurrencyToken = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    Scopes = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPermissionRoleDefinitions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProjectPermissionID = table.Column<long>(nullable: false),
                    ProjectRoleID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPermissionRoleDefinitions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectPermissionRoleDefinitions_ProjectPermissionDefinitions_ProjectPermissionID",
                        column: x => x.ProjectPermissionID,
                        principalTable: "ProjectPermissionDefinitions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectPermissionRoleDefinitions_ProjectRoleDefinitions_ProjectRoleID",
                        column: x => x.ProjectRoleID,
                        principalTable: "ProjectRoleDefinitions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Breakdown",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    IsDefaultProjectBreakdown = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakdown", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Breakdown_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Breakdown_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CallType",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    SortingOrder = table.Column<int>(nullable: true)
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
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ParentCommentID = table.Column<long>(nullable: true),
                    ParentProjectID = table.Column<long>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ParentCommentID",
                        column: x => x.ParentCommentID,
                        principalTable: "Comment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Projects_ParentProjectID",
                        column: x => x.ParentProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrewUnit",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewUnit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrewUnit_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    FileContent = table.Column<byte[]>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    IsPrimaryImage = table.Column<bool>(nullable: false),
                    ProjectID = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Image_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true),
                    Address4 = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Location_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScriptUpload",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    End = table.Column<DateTime>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScriptUpload", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScriptUpload_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUserInvitation",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProjectID = table.Column<long>(nullable: false),
                    RoleID = table.Column<long>(nullable: true),
                    UserInvitationID = table.Column<Guid>(nullable: false)
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
                        name: "FK_ProjectUserInvitation_UserInvitation_UserInvitationID",
                        column: x => x.UserInvitationID,
                        principalTable: "UserInvitation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictTokens",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ApplicationId = table.Column<string>(nullable: true),
                    AuthorizationId = table.Column<string>(nullable: true),
                    ConcurrencyToken = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(nullable: true),
                    ExpirationDate = table.Column<DateTimeOffset>(nullable: true),
                    Payload = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    ReferenceId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "OpenIddictAuthorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreakdownType",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BreakdownID = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakdownType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BreakdownType_Breakdown_BreakdownID",
                        column: x => x.BreakdownID,
                        principalTable: "Breakdown",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CastMemberID = table.Column<long>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    RoleID = table.Column<long>(nullable: true),
                    SelectedBreakdownID = table.Column<long>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_ProjectRoleDefinitions_RoleID",
                        column: x => x.RoleID,
                        principalTable: "ProjectRoleDefinitions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Breakdown_SelectedBreakdownID",
                        column: x => x.SelectedBreakdownID,
                        principalTable: "Breakdown",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectUser_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrewDepartment",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CrewUnitID = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SortingOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewDepartment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrewDepartment_CrewUnit_CrewUnitID",
                        column: x => x.CrewUnitID,
                        principalTable: "CrewUnit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShootingDay",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CallsheetID = table.Column<long>(nullable: true),
                    Completed = table.Column<bool>(nullable: false),
                    CrewUnitID = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    OverTime = table.Column<TimeSpan>(nullable: false),
                    ScheduleDayID = table.Column<long>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    Turn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShootingDay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShootingDay_CrewUnit_CrewUnitID",
                        column: x => x.CrewUnitID,
                        principalTable: "CrewUnit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayNights",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    ScriptUploadID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayNights", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DayNights_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayNights_ScriptUpload_ScriptUploadID",
                        column: x => x.ScriptUploadID,
                        principalTable: "ScriptUpload",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IntExts",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    ScriptUploadID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntExts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IntExts_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntExts_ScriptUpload_ScriptUploadID",
                        column: x => x.ScriptUploadID,
                        principalTable: "ScriptUpload",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScriptLocations",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    ScriptUploadID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScriptLocations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScriptLocations_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScriptLocations_ScriptUpload_ScriptUploadID",
                        column: x => x.ScriptUploadID,
                        principalTable: "ScriptUpload",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreakdownItem",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BreakdownID = table.Column<long>(nullable: false),
                    BreakdownTypeID = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakdownItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BreakdownItem_Breakdown_BreakdownID",
                        column: x => x.BreakdownID,
                        principalTable: "Breakdown",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreakdownItem_BreakdownType_BreakdownTypeID",
                        column: x => x.BreakdownTypeID,
                        principalTable: "BreakdownType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CastMember",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    ProjectUserID = table.Column<long>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastMember", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CastMember_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastMember_ProjectUser_ProjectUserID",
                        column: x => x.ProjectUserID,
                        principalTable: "ProjectUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrewUnitMember",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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

            migrationBuilder.CreateTable(
                name: "Callsheet",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CrewCall = table.Column<DateTime>(nullable: false),
                    CrewUnitID = table.Column<long>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    ShootingDayID = table.Column<long>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Callsheet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Callsheet_CrewUnit_CrewUnitID",
                        column: x => x.CrewUnitID,
                        principalTable: "CrewUnit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Callsheet_ShootingDay_ShootingDayID",
                        column: x => x.ShootingDayID,
                        principalTable: "ShootingDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDay",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CrewUnitID = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    ShootingDayID = table.Column<long>(nullable: true),
                    Start = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScheduleDay_CrewUnit_CrewUnitID",
                        column: x => x.CrewUnitID,
                        principalTable: "CrewUnit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleDay_ShootingDay_ShootingDayID",
                        column: x => x.ShootingDayID,
                        principalTable: "ShootingDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageScriptLocation",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ImageID = table.Column<long>(nullable: false),
                    IsPrimaryImage = table.Column<bool>(nullable: false),
                    ScriptLocationID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageScriptLocation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageScriptLocation_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageScriptLocation_ScriptLocations_ScriptLocationID",
                        column: x => x.ScriptLocationID,
                        principalTable: "ScriptLocations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationSet",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    LocationID = table.Column<long>(nullable: false),
                    Longitude = table.Column<double>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ScriptLocationID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LocationSet_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationSet_ScriptLocations_ScriptLocationID",
                        column: x => x.ScriptLocationID,
                        principalTable: "ScriptLocations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scenes",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DayNightID = table.Column<long>(nullable: true),
                    IntExtID = table.Column<long>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    PageLength = table.Column<int>(nullable: false),
                    ProjectID = table.Column<long>(nullable: false),
                    ScriptLocationID = table.Column<long>(nullable: true),
                    ScriptUploadID = table.Column<long>(nullable: true),
                    SortingOrder = table.Column<int>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Timing = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Scenes_DayNights_DayNightID",
                        column: x => x.DayNightID,
                        principalTable: "DayNights",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scenes_IntExts_IntExtID",
                        column: x => x.IntExtID,
                        principalTable: "IntExts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scenes_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scenes_ScriptLocations_ScriptLocationID",
                        column: x => x.ScriptLocationID,
                        principalTable: "ScriptLocations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scenes_ScriptUpload_ScriptUploadID",
                        column: x => x.ScriptUploadID,
                        principalTable: "ScriptUpload",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageBreakdownItem",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BreakdownItemID = table.Column<long>(nullable: false),
                    ImageID = table.Column<long>(nullable: false),
                    IsPrimaryImage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageBreakdownItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageBreakdownItem_BreakdownItem_BreakdownItemID",
                        column: x => x.BreakdownItemID,
                        principalTable: "BreakdownItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageBreakdownItem_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CastMemberID = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    ProjectID = table.Column<long>(nullable: false),
                    ScriptUploadID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Character_CastMember_CastMemberID",
                        column: x => x.CastMemberID,
                        principalTable: "CastMember",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_ScriptUpload_ScriptUploadID",
                        column: x => x.ScriptUploadID,
                        principalTable: "ScriptUpload",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrewMember",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CrewUnitMemberID = table.Column<long>(nullable: true),
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
                        name: "FK_CrewMember_CrewUnitMember_CrewUnitMemberID",
                        column: x => x.CrewUnitMemberID,
                        principalTable: "CrewUnitMember",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CrewMember_CrewDepartment_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "CrewDepartment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDayNote",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Content = table.Column<string>(nullable: true),
                    ScheduleDayID = table.Column<long>(nullable: false),
                    SortingOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDayNote", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScheduleDayNote_ScheduleDay_ScheduleDayID",
                        column: x => x.ScheduleDayID,
                        principalTable: "ScheduleDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreakdownItemScene",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BreakdownItemID = table.Column<long>(nullable: false),
                    SceneID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakdownItemScene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BreakdownItemScene_BreakdownItem_BreakdownItemID",
                        column: x => x.BreakdownItemID,
                        principalTable: "BreakdownItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreakdownItemScene_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallsheetScene",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CallsheetID = table.Column<long>(nullable: false),
                    LocationSetID = table.Column<long>(nullable: true),
                    PageLength = table.Column<int>(nullable: false),
                    SceneID = table.Column<long>(nullable: false),
                    ShootingDaySceneID = table.Column<long>(nullable: false),
                    SortingOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallsheetScene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CallsheetScene_Callsheet_CallsheetID",
                        column: x => x.CallsheetID,
                        principalTable: "Callsheet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallsheetScene_LocationSet_LocationSetID",
                        column: x => x.LocationSetID,
                        principalTable: "LocationSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CallsheetScene_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageScene",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ImageID = table.Column<long>(nullable: false),
                    IsPrimaryImage = table.Column<bool>(nullable: false),
                    SceneID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageScene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageScene_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageScene_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SceneAction",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Order = table.Column<int>(nullable: false),
                    SceneID = table.Column<long>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneAction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SceneAction_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleScene",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LocationSetID = table.Column<long>(nullable: true),
                    PageLength = table.Column<int>(nullable: false),
                    SceneID = table.Column<long>(nullable: false),
                    ScheduleDayID = table.Column<long>(nullable: false),
                    SortingOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleScene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScheduleScene_LocationSet_LocationSetID",
                        column: x => x.LocationSetID,
                        principalTable: "LocationSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleScene_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleScene_ScheduleDay_ScheduleDayID",
                        column: x => x.ScheduleDayID,
                        principalTable: "ScheduleDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slate",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Aperture = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Distance = table.Column<string>(nullable: true),
                    Filters = table.Column<string>(nullable: true),
                    IsVfx = table.Column<bool>(nullable: false),
                    Lens = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    ProjectID = table.Column<long>(nullable: false),
                    SceneID = table.Column<long>(nullable: true),
                    ShootingDayID = table.Column<long>(nullable: true),
                    SortingOrder = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Slate_ShootingDay_ShootingDayID",
                        column: x => x.ShootingDayID,
                        principalTable: "ShootingDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CallsheetCharacter",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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
                name: "CharacterScene",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CharacterID = table.Column<long>(nullable: false),
                    SceneID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterScene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CharacterScene_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterScene_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageCharacter",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CharacterID = table.Column<long>(nullable: false),
                    ImageID = table.Column<long>(nullable: false),
                    IsPrimaryImage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCharacter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageCharacter_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageCharacter_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SceneDialogue",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CharacterID = table.Column<long>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    SceneID = table.Column<long>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneDialogue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SceneDialogue_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SceneDialogue_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShootingDayScene",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CallsheetSceneID = table.Column<long>(nullable: true),
                    Completion = table.Column<int>(nullable: false),
                    LocationSetID = table.Column<long>(nullable: true),
                    PageLength = table.Column<int>(nullable: false),
                    SceneID = table.Column<long>(nullable: false),
                    ShootingDayID = table.Column<long>(nullable: false),
                    Timings = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShootingDayScene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShootingDayScene_CallsheetScene_CallsheetSceneID",
                        column: x => x.CallsheetSceneID,
                        principalTable: "CallsheetScene",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShootingDayScene_LocationSet_LocationSetID",
                        column: x => x.LocationSetID,
                        principalTable: "LocationSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShootingDayScene_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShootingDayScene_ShootingDay_ShootingDayID",
                        column: x => x.ShootingDayID,
                        principalTable: "ShootingDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageSlate",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ImageID = table.Column<long>(nullable: false),
                    IsPrimaryImage = table.Column<bool>(nullable: false),
                    SlateID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageSlate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageSlate_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageSlate_Slate_SlateID",
                        column: x => x.SlateID,
                        principalTable: "Slate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Take",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CameraRoll = table.Column<string>(nullable: true),
                    Length = table.Column<TimeSpan>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false),
                    SlateID = table.Column<long>(nullable: false),
                    SortingOrder = table.Column<int>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "CharacterCall",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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

            migrationBuilder.CreateTable(
                name: "CallsheetSceneCharacter",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CallsheetSceneID = table.Column<long>(nullable: false),
                    CharacterSceneID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallsheetSceneCharacter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CallsheetSceneCharacter_CallsheetScene_CallsheetSceneID",
                        column: x => x.CallsheetSceneID,
                        principalTable: "CallsheetScene",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallsheetSceneCharacter_CharacterScene_CharacterSceneID",
                        column: x => x.CharacterSceneID,
                        principalTable: "CharacterScene",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleCharacter",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CharacterSceneID = table.Column<long>(nullable: false),
                    ScheduleSceneID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleCharacter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScheduleCharacter_CharacterScene_CharacterSceneID",
                        column: x => x.CharacterSceneID,
                        principalTable: "CharacterScene",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleCharacter_ScheduleScene_ScheduleSceneID",
                        column: x => x.ScheduleSceneID,
                        principalTable: "ScheduleScene",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breakdown_ProjectID",
                table: "Breakdown",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Breakdown_UserID",
                table: "Breakdown",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BreakdownItem_BreakdownID",
                table: "BreakdownItem",
                column: "BreakdownID");

            migrationBuilder.CreateIndex(
                name: "IX_BreakdownItem_BreakdownTypeID",
                table: "BreakdownItem",
                column: "BreakdownTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_BreakdownItemScene_BreakdownItemID",
                table: "BreakdownItemScene",
                column: "BreakdownItemID");

            migrationBuilder.CreateIndex(
                name: "IX_BreakdownItemScene_SceneID",
                table: "BreakdownItemScene",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_BreakdownType_BreakdownID",
                table: "BreakdownType",
                column: "BreakdownID");

            migrationBuilder.CreateIndex(
                name: "IX_Callsheet_CrewUnitID",
                table: "Callsheet",
                column: "CrewUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Callsheet_ShootingDayID",
                table: "Callsheet",
                column: "ShootingDayID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetCharacter_CallsheetID",
                table: "CallsheetCharacter",
                column: "CallsheetID");

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetCharacter_CharacterID",
                table: "CallsheetCharacter",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetScene_CallsheetID",
                table: "CallsheetScene",
                column: "CallsheetID");

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetScene_LocationSetID",
                table: "CallsheetScene",
                column: "LocationSetID");

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetScene_SceneID",
                table: "CallsheetScene",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetSceneCharacter_CallsheetSceneID",
                table: "CallsheetSceneCharacter",
                column: "CallsheetSceneID");

            migrationBuilder.CreateIndex(
                name: "IX_CallsheetSceneCharacter_CharacterSceneID",
                table: "CallsheetSceneCharacter",
                column: "CharacterSceneID");

            migrationBuilder.CreateIndex(
                name: "IX_CallType_ProjectID",
                table: "CallType",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_CastMember_ProjectID",
                table: "CastMember",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_CastMember_ProjectUserID",
                table: "CastMember",
                column: "ProjectUserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_CastMemberID",
                table: "Character",
                column: "CastMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Character_ProjectID",
                table: "Character",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Character_ScriptUploadID",
                table: "Character",
                column: "ScriptUploadID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCall_CallTypeID",
                table: "CharacterCall",
                column: "CallTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCall_CallsheetCharacterID",
                table: "CharacterCall",
                column: "CallsheetCharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterScene_CharacterID",
                table: "CharacterScene",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterScene_SceneID",
                table: "CharacterScene",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentCommentID",
                table: "Comment",
                column: "ParentCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentProjectID",
                table: "Comment",
                column: "ParentProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserID",
                table: "Comment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewDepartment_CrewUnitID",
                table: "CrewDepartment",
                column: "CrewUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewMember_CrewUnitMemberID",
                table: "CrewMember",
                column: "CrewUnitMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewMember_DepartmentID",
                table: "CrewMember",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewUnit_ProjectID",
                table: "CrewUnit",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewUnitMember_CrewUnitID",
                table: "CrewUnitMember",
                column: "CrewUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewUnitMember_ProjectUserID",
                table: "CrewUnitMember",
                column: "ProjectUserID");

            migrationBuilder.CreateIndex(
                name: "IX_DayNights_ProjectID",
                table: "DayNights",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_DayNights_ScriptUploadID",
                table: "DayNights",
                column: "ScriptUploadID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProjectID",
                table: "Image",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageBreakdownItem_BreakdownItemID",
                table: "ImageBreakdownItem",
                column: "BreakdownItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageBreakdownItem_ImageID",
                table: "ImageBreakdownItem",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageCharacter_CharacterID",
                table: "ImageCharacter",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageCharacter_ImageID",
                table: "ImageCharacter",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageScene_ImageID",
                table: "ImageScene",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageScene_SceneID",
                table: "ImageScene",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageScriptLocation_ImageID",
                table: "ImageScriptLocation",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageScriptLocation_ScriptLocationID",
                table: "ImageScriptLocation",
                column: "ScriptLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSlate_ImageID",
                table: "ImageSlate",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSlate_SlateID",
                table: "ImageSlate",
                column: "SlateID");

            migrationBuilder.CreateIndex(
                name: "IX_IntExts_ProjectID",
                table: "IntExts",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_IntExts_ScriptUploadID",
                table: "IntExts",
                column: "ScriptUploadID");

            migrationBuilder.CreateIndex(
                name: "IX_Location_ProjectID",
                table: "Location",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSet_LocationID",
                table: "LocationSet",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSet_ScriptLocationID",
                table: "LocationSet",
                column: "ScriptLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId",
                table: "OpenIddictAuthorizations",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ApplicationId",
                table: "OpenIddictTokens",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_AuthorizationId",
                table: "OpenIddictTokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPermissionRoleDefinitions_ProjectPermissionID",
                table: "ProjectPermissionRoleDefinitions",
                column: "ProjectPermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPermissionRoleDefinitions_ProjectRoleID",
                table: "ProjectPermissionRoleDefinitions",
                column: "ProjectRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_ProjectID",
                table: "ProjectUser",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_RoleID",
                table: "ProjectUser",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_SelectedBreakdownID",
                table: "ProjectUser",
                column: "SelectedBreakdownID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_UserID",
                table: "ProjectUser",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserInvitation_ProjectID",
                table: "ProjectUserInvitation",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserInvitation_RoleID",
                table: "ProjectUserInvitation",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserInvitation_UserInvitationID",
                table: "ProjectUserInvitation",
                column: "UserInvitationID");

            migrationBuilder.CreateIndex(
                name: "IX_SceneAction_SceneID",
                table: "SceneAction",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_SceneDialogue_CharacterID",
                table: "SceneDialogue",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_SceneDialogue_SceneID",
                table: "SceneDialogue",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_DayNightID",
                table: "Scenes",
                column: "DayNightID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_IntExtID",
                table: "Scenes",
                column: "IntExtID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_ProjectID",
                table: "Scenes",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_ScriptLocationID",
                table: "Scenes",
                column: "ScriptLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_ScriptUploadID",
                table: "Scenes",
                column: "ScriptUploadID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleCharacter_CharacterSceneID",
                table: "ScheduleCharacter",
                column: "CharacterSceneID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleCharacter_ScheduleSceneID",
                table: "ScheduleCharacter",
                column: "ScheduleSceneID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDay_CrewUnitID",
                table: "ScheduleDay",
                column: "CrewUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDay_ShootingDayID",
                table: "ScheduleDay",
                column: "ShootingDayID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDayNote_ScheduleDayID",
                table: "ScheduleDayNote",
                column: "ScheduleDayID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleScene_LocationSetID",
                table: "ScheduleScene",
                column: "LocationSetID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleScene_SceneID",
                table: "ScheduleScene",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleScene_ScheduleDayID",
                table: "ScheduleScene",
                column: "ScheduleDayID");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptLocations_ProjectID",
                table: "ScriptLocations",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptLocations_ScriptUploadID",
                table: "ScriptLocations",
                column: "ScriptUploadID");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptUpload_ProjectID",
                table: "ScriptUpload",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDay_CrewUnitID",
                table: "ShootingDay",
                column: "CrewUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDayScene_CallsheetSceneID",
                table: "ShootingDayScene",
                column: "CallsheetSceneID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDayScene_LocationSetID",
                table: "ShootingDayScene",
                column: "LocationSetID");

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDayScene_SceneID",
                table: "ShootingDayScene",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_ShootingDayScene_ShootingDayID",
                table: "ShootingDayScene",
                column: "ShootingDayID");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BreakdownItemScene");

            migrationBuilder.DropTable(
                name: "BreakdownTypeDefinitions");

            migrationBuilder.DropTable(
                name: "CallsheetSceneCharacter");

            migrationBuilder.DropTable(
                name: "CallTypeDefinitions");

            migrationBuilder.DropTable(
                name: "CharacterCall");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "CrewDepartmentDefinitions");

            migrationBuilder.DropTable(
                name: "CrewMember");

            migrationBuilder.DropTable(
                name: "ImageBreakdownItem");

            migrationBuilder.DropTable(
                name: "ImageCharacter");

            migrationBuilder.DropTable(
                name: "ImageScene");

            migrationBuilder.DropTable(
                name: "ImageScriptLocation");

            migrationBuilder.DropTable(
                name: "ImageSlate");

            migrationBuilder.DropTable(
                name: "OpenIddictScopes");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens");

            migrationBuilder.DropTable(
                name: "ProjectPermissionRoleDefinitions");

            migrationBuilder.DropTable(
                name: "ProjectUserInvitation");

            migrationBuilder.DropTable(
                name: "SceneAction");

            migrationBuilder.DropTable(
                name: "SceneDialogue");

            migrationBuilder.DropTable(
                name: "ScheduleCharacter");

            migrationBuilder.DropTable(
                name: "ScheduleDayNote");

            migrationBuilder.DropTable(
                name: "ShootingDayScene");

            migrationBuilder.DropTable(
                name: "Take");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CallType");

            migrationBuilder.DropTable(
                name: "CallsheetCharacter");

            migrationBuilder.DropTable(
                name: "CrewUnitMember");

            migrationBuilder.DropTable(
                name: "CrewDepartment");

            migrationBuilder.DropTable(
                name: "BreakdownItem");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations");

            migrationBuilder.DropTable(
                name: "ProjectPermissionDefinitions");

            migrationBuilder.DropTable(
                name: "UserInvitation");

            migrationBuilder.DropTable(
                name: "CharacterScene");

            migrationBuilder.DropTable(
                name: "ScheduleScene");

            migrationBuilder.DropTable(
                name: "CallsheetScene");

            migrationBuilder.DropTable(
                name: "Slate");

            migrationBuilder.DropTable(
                name: "BreakdownType");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "ScheduleDay");

            migrationBuilder.DropTable(
                name: "Callsheet");

            migrationBuilder.DropTable(
                name: "LocationSet");

            migrationBuilder.DropTable(
                name: "Scenes");

            migrationBuilder.DropTable(
                name: "CastMember");

            migrationBuilder.DropTable(
                name: "ShootingDay");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "DayNights");

            migrationBuilder.DropTable(
                name: "IntExts");

            migrationBuilder.DropTable(
                name: "ScriptLocations");

            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.DropTable(
                name: "CrewUnit");

            migrationBuilder.DropTable(
                name: "ScriptUpload");

            migrationBuilder.DropTable(
                name: "ProjectRoleDefinitions");

            migrationBuilder.DropTable(
                name: "Breakdown");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
