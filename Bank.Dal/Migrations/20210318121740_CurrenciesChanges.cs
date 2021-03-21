using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class CurrenciesChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Currency",
                table: "PhysicalPersonDeposits",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Currency",
                table: "PhysicalPersonCredits",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Currency",
                table: "PhysicalPersonAccounts",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Currency",
                table: "LegalPersonDeposits",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Currency",
                table: "LegalPersonCredits",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Currency",
                table: "LegalPersonAccounts",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "PhysicalPersonDeposits");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "PhysicalPersonCredits");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "PhysicalPersonAccounts");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "LegalPersonDeposits");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "LegalPersonCredits");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "LegalPersonAccounts");
        }
    }
}
