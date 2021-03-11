using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegalPersonAccountArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    LegalPersonAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonAccountArchives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersonClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersonCreditArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    LegalPersonCreditId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonCreditArchives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersonDepositArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    LegalPersonDepositId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonDepositArchives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersonAccountArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    PhysicalPersonAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonAccountArchives", x => x.Id);
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
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersonCreditArchive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    PhysicalPersonCreditId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonCreditArchive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersonDepositArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    PhysicalPersonDepositId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonDepositArchives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersonAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonAccounts_ClientId",
                table: "LegalPersonAccounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonCredits_ClientId",
                table: "LegalPersonCredits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonDeposits_ClientId",
                table: "LegalPersonDeposits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonAccounts_ClientId",
                table: "PhysicalPersonAccounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonCredits_ClientId",
                table: "PhysicalPersonCredits",
                column: "ClientId");

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
                name: "LegalPersonAccounts");

            migrationBuilder.DropTable(
                name: "LegalPersonCreditArchives");

            migrationBuilder.DropTable(
                name: "LegalPersonCredits");

            migrationBuilder.DropTable(
                name: "LegalPersonDepositArchives");

            migrationBuilder.DropTable(
                name: "LegalPersonDeposits");

            migrationBuilder.DropTable(
                name: "PhysicalPersonAccountArchives");

            migrationBuilder.DropTable(
                name: "PhysicalPersonAccounts");

            migrationBuilder.DropTable(
                name: "PhysicalPersonCreditArchive");

            migrationBuilder.DropTable(
                name: "PhysicalPersonCredits");

            migrationBuilder.DropTable(
                name: "PhysicalPersonDepositArchives");

            migrationBuilder.DropTable(
                name: "PhysicalPersonDeposits");

            migrationBuilder.DropTable(
                name: "LegalPersonClients");

            migrationBuilder.DropTable(
                name: "PhysicalPersonClients");
        }
    }
}
