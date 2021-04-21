using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Dal.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OpenDateTime",
                table: "PhysicalPersonCredits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenDateTime",
                table: "PhysicalPersonCredits");
        }
    }
}
