using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleScreening.Migrations
{
    public partial class NotificationColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NotificationIsInProgress",
                table: "EmployeeScreening",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NotificationSentDate",
                table: "EmployeeScreening",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationIsInProgress",
                table: "EmployeeScreening");

            migrationBuilder.DropColumn(
                name: "NotificationSentDate",
                table: "EmployeeScreening");
        }
    }
}
