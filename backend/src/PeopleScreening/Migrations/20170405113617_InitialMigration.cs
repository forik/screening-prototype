using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleScreening.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "EntityFrameworkCoreSequence",
                incrementBy: 100);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ManagerId = table.Column<long>(nullable: true),
                    SkipManagerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_SkipManagerId",
                        column: x => x.SkipManagerId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScreeningProcess",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreeningProcess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeScreening",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    EmployeeId = table.Column<long>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    ScreeningId = table.Column<long>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeScreening", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeScreening_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeScreening_ScreeningProcess_ScreeningId",
                        column: x => x.ScreeningId,
                        principalTable: "ScreeningProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ManagerId",
                table: "Employee",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SkipManagerId",
                table: "Employee",
                column: "SkipManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeScreening_EmployeeId",
                table: "EmployeeScreening",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeScreening_ScreeningId",
                table: "EmployeeScreening",
                column: "ScreeningId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeScreening");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ScreeningProcess");

            migrationBuilder.DropSequence(
                name: "EntityFrameworkHiLoSequence");
        }
    }
}
