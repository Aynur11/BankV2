using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class EnumChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Capitalization",
                table: "PhysicalPersonDeposits",
                newName: "WithCapitalization");

            migrationBuilder.RenameColumn(
                name: "Capitalization",
                table: "LegalPersonDeposits",
                newName: "WithCapitalization");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PhysicalPersonDepositArchives",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PhysicalPersonCreditArchive",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<byte>(
                name: "Type",
                table: "PhysicalPersonClients",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PhysicalPersonAccountArchives",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "LegalPersonDepositArchives",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "LegalPersonCreditArchives",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<byte>(
                name: "Type",
                table: "LegalPersonClients",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "LegalPersonAccountArchives",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonDepositArchives_PhysicalPersonDepositId",
                table: "PhysicalPersonDepositArchives",
                column: "PhysicalPersonDepositId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonCreditArchive_PhysicalPersonCreditId",
                table: "PhysicalPersonCreditArchive",
                column: "PhysicalPersonCreditId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonAccountArchives_PhysicalPersonAccountId",
                table: "PhysicalPersonAccountArchives",
                column: "PhysicalPersonAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonDepositArchives_LegalPersonDepositId",
                table: "LegalPersonDepositArchives",
                column: "LegalPersonDepositId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonCreditArchives_LegalPersonCreditId",
                table: "LegalPersonCreditArchives",
                column: "LegalPersonCreditId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonAccountArchives_LegalPersonAccountId",
                table: "LegalPersonAccountArchives",
                column: "LegalPersonAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalPersonAccountArchives_LegalPersonAccounts_LegalPersonAccountId",
                table: "LegalPersonAccountArchives",
                column: "LegalPersonAccountId",
                principalTable: "LegalPersonAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LegalPersonCreditArchives_LegalPersonCredits_LegalPersonCreditId",
                table: "LegalPersonCreditArchives",
                column: "LegalPersonCreditId",
                principalTable: "LegalPersonCredits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LegalPersonDepositArchives_LegalPersonDeposits_LegalPersonDepositId",
                table: "LegalPersonDepositArchives",
                column: "LegalPersonDepositId",
                principalTable: "LegalPersonDeposits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalPersonAccountArchives_PhysicalPersonAccounts_PhysicalPersonAccountId",
                table: "PhysicalPersonAccountArchives",
                column: "PhysicalPersonAccountId",
                principalTable: "PhysicalPersonAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalPersonCreditArchive_PhysicalPersonCredits_PhysicalPersonCreditId",
                table: "PhysicalPersonCreditArchive",
                column: "PhysicalPersonCreditId",
                principalTable: "PhysicalPersonCredits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalPersonDepositArchives_PhysicalPersonDeposits_PhysicalPersonDepositId",
                table: "PhysicalPersonDepositArchives",
                column: "PhysicalPersonDepositId",
                principalTable: "PhysicalPersonDeposits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalPersonAccountArchives_LegalPersonAccounts_LegalPersonAccountId",
                table: "LegalPersonAccountArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalPersonCreditArchives_LegalPersonCredits_LegalPersonCreditId",
                table: "LegalPersonCreditArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalPersonDepositArchives_LegalPersonDeposits_LegalPersonDepositId",
                table: "LegalPersonDepositArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalPersonAccountArchives_PhysicalPersonAccounts_PhysicalPersonAccountId",
                table: "PhysicalPersonAccountArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalPersonCreditArchive_PhysicalPersonCredits_PhysicalPersonCreditId",
                table: "PhysicalPersonCreditArchive");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalPersonDepositArchives_PhysicalPersonDeposits_PhysicalPersonDepositId",
                table: "PhysicalPersonDepositArchives");

            migrationBuilder.DropIndex(
                name: "IX_PhysicalPersonDepositArchives_PhysicalPersonDepositId",
                table: "PhysicalPersonDepositArchives");

            migrationBuilder.DropIndex(
                name: "IX_PhysicalPersonCreditArchive_PhysicalPersonCreditId",
                table: "PhysicalPersonCreditArchive");

            migrationBuilder.DropIndex(
                name: "IX_PhysicalPersonAccountArchives_PhysicalPersonAccountId",
                table: "PhysicalPersonAccountArchives");

            migrationBuilder.DropIndex(
                name: "IX_LegalPersonDepositArchives_LegalPersonDepositId",
                table: "LegalPersonDepositArchives");

            migrationBuilder.DropIndex(
                name: "IX_LegalPersonCreditArchives_LegalPersonCreditId",
                table: "LegalPersonCreditArchives");

            migrationBuilder.DropIndex(
                name: "IX_LegalPersonAccountArchives_LegalPersonAccountId",
                table: "LegalPersonAccountArchives");

            migrationBuilder.RenameColumn(
                name: "WithCapitalization",
                table: "PhysicalPersonDeposits",
                newName: "Capitalization");

            migrationBuilder.RenameColumn(
                name: "WithCapitalization",
                table: "LegalPersonDeposits",
                newName: "Capitalization");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "PhysicalPersonDepositArchives",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "PhysicalPersonCreditArchive",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "PhysicalPersonClients",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "PhysicalPersonAccountArchives",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "LegalPersonDepositArchives",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "LegalPersonCreditArchives",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "LegalPersonClients",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "LegalPersonAccountArchives",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
