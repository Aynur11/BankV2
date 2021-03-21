using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class AddedClientType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PhysicalPersonClients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "LegalPersonClients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "PhysicalPersonClients");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "LegalPersonClients");
        }
    }
}
