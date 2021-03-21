using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class RateSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "PhysicalPersonDeposits",
                type: "decimal(9,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "PhysicalPersonCredits",
                type: "decimal(9,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "PhysicalPersonAccounts",
                type: "decimal(9,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "LegalPersonDeposits",
                type: "decimal(9,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "LegalPersonCredits",
                type: "decimal(9,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "LegalPersonAccounts",
                type: "decimal(9,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "PhysicalPersonDeposits",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "PhysicalPersonCredits",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "PhysicalPersonAccounts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "LegalPersonDeposits",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "LegalPersonCredits",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "LegalPersonAccounts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,3)");
        }
    }
}
