using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Dal.Migrations
{
    public partial class afterRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegalPersonClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersonClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersonAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<byte>(type: "tinyint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalPersonAccounts_LegalPersonClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "LegalPersonClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersonCredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<byte>(type: "tinyint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalPersonCredits_LegalPersonClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "LegalPersonClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersonDeposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<byte>(type: "tinyint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    WithCapitalization = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalPersonDeposits_LegalPersonClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "LegalPersonClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersonAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<byte>(type: "tinyint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalPersonAccounts_PhysicalPersonClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "PhysicalPersonClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersonCredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<byte>(type: "tinyint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalPersonCredits_PhysicalPersonClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "PhysicalPersonClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersonDeposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<byte>(type: "tinyint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    WithCapitalization = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalPersonDeposits_PhysicalPersonClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "PhysicalPersonClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersonAccountArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Operation = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonAccountArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalPersonAccountArchives_LegalPersonAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "LegalPersonAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersonCreditArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Operation = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonCreditArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalPersonCreditArchives_LegalPersonCredits_AccountId",
                        column: x => x.AccountId,
                        principalTable: "LegalPersonCredits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersonDepositArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Operation = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonDepositArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalPersonDepositArchives_LegalPersonDeposits_AccountId",
                        column: x => x.AccountId,
                        principalTable: "LegalPersonDeposits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersonAccountArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Operation = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonAccountArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalPersonAccountArchives_PhysicalPersonAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "PhysicalPersonAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersonCreditArchive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Operation = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonCreditArchive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalPersonCreditArchive_PhysicalPersonCredits_AccountId",
                        column: x => x.AccountId,
                        principalTable: "PhysicalPersonCredits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersonDepositArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Operation = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonDepositArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalPersonDepositArchives_PhysicalPersonDeposits_AccountId",
                        column: x => x.AccountId,
                        principalTable: "PhysicalPersonDeposits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonAccountArchives_AccountId",
                table: "LegalPersonAccountArchives",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonAccounts_ClientId",
                table: "LegalPersonAccounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonCreditArchives_AccountId",
                table: "LegalPersonCreditArchives",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonCredits_ClientId",
                table: "LegalPersonCredits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonDepositArchives_AccountId",
                table: "LegalPersonDepositArchives",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonDeposits_ClientId",
                table: "LegalPersonDeposits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonAccountArchives_AccountId",
                table: "PhysicalPersonAccountArchives",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonAccounts_ClientId",
                table: "PhysicalPersonAccounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonCreditArchive_AccountId",
                table: "PhysicalPersonCreditArchive",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonCredits_ClientId",
                table: "PhysicalPersonCredits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonDepositArchives_AccountId",
                table: "PhysicalPersonDepositArchives",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonDeposits_ClientId",
                table: "PhysicalPersonDeposits",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalPersonAccountArchives");

            migrationBuilder.DropTable(
                name: "LegalPersonCreditArchives");

            migrationBuilder.DropTable(
                name: "LegalPersonDepositArchives");

            migrationBuilder.DropTable(
                name: "PhysicalPersonAccountArchives");

            migrationBuilder.DropTable(
                name: "PhysicalPersonCreditArchive");

            migrationBuilder.DropTable(
                name: "PhysicalPersonDepositArchives");

            migrationBuilder.DropTable(
                name: "LegalPersonAccounts");

            migrationBuilder.DropTable(
                name: "LegalPersonCredits");

            migrationBuilder.DropTable(
                name: "LegalPersonDeposits");

            migrationBuilder.DropTable(
                name: "PhysicalPersonAccounts");

            migrationBuilder.DropTable(
                name: "PhysicalPersonCredits");

            migrationBuilder.DropTable(
                name: "PhysicalPersonDeposits");

            migrationBuilder.DropTable(
                name: "LegalPersonClients");

            migrationBuilder.DropTable(
                name: "PhysicalPersonClients");
        }
    }
}
