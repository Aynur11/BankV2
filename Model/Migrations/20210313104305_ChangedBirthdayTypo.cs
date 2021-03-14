using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class ChangedBirthdayTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDay",
                table: "PhysicalPersonClients",
                newName: "Birthday");

            migrationBuilder.AlterColumn<byte>(
                name: "Operation",
                table: "PhysicalPersonDepositArchives",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Operation",
                table: "PhysicalPersonCreditArchive",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Operation",
                table: "PhysicalPersonAccountArchives",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Operation",
                table: "LegalPersonDepositArchives",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Operation",
                table: "LegalPersonCreditArchives",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Operation",
                table: "LegalPersonAccountArchives",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "PhysicalPersonClients",
                newName: "BirthDay");

            migrationBuilder.AlterColumn<int>(
                name: "Operation",
                table: "PhysicalPersonDepositArchives",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Operation",
                table: "PhysicalPersonCreditArchive",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Operation",
                table: "PhysicalPersonAccountArchives",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Operation",
                table: "LegalPersonDepositArchives",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Operation",
                table: "LegalPersonCreditArchives",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Operation",
                table: "LegalPersonAccountArchives",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
