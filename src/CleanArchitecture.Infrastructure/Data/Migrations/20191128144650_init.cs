﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CleanArchitecture.Infrastructure.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 12, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 12, nullable: true),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    MissionTypeId = table.Column<int>(nullable: true),
                    EmployerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Missions_MissionTypes_MissionTypeId",
                        column: x => x.MissionTypeId,
                        principalTable: "MissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MissionImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    MissionId = table.Column<int>(nullable: false),
                    FileURL = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissionImages_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 75, nullable: true),
                    Content = table.Column<string>(maxLength: 400, nullable: false),
                    MissionId = table.Column<int>(nullable: false),
                    Pinned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissionNotes_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MissionImages_MissionId",
                table: "MissionImages",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionNotes_MissionId",
                table: "MissionNotes",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_EmployerId",
                table: "Missions",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_MissionTypeId",
                table: "Missions",
                column: "MissionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissionImages");

            migrationBuilder.DropTable(
                name: "MissionNotes");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "MissionTypes");
        }
    }
}
