using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Dal.Migrations
{
    public partial class CreditStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasClosed",
                table: "PhysicalPersonCredits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasClosed",
                table: "PhysicalPersonCredits");
        }
    }
}
