using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class AccountChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Capitalization",
                table: "PhysicalPersonDeposits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "PhysicalPersonDeposits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "PhysicalPersonCredits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Capitalization",
                table: "LegalPersonDeposits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LegalPersonDeposits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LegalPersonCredits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capitalization",
                table: "PhysicalPersonDeposits");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "PhysicalPersonDeposits");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "PhysicalPersonCredits");

            migrationBuilder.DropColumn(
                name: "Capitalization",
                table: "LegalPersonDeposits");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "LegalPersonDeposits");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "LegalPersonCredits");
        }
    }
}
