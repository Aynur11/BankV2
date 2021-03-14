﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace Model.Migrations
{
    [DbContext(typeof(BankContext))]
    partial class BankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Accounts.LegalPersonAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(9,3)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("LegalPersonAccounts");
                });

            modelBuilder.Entity("Model.Accounts.LegalPersonCredit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(9,3)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("LegalPersonCredits");
                });

            modelBuilder.Entity("Model.Accounts.LegalPersonDeposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(9,3)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("LegalPersonDeposits");
                });

            modelBuilder.Entity("Model.Accounts.PhysicalPersonAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(9,3)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("PhysicalPersonAccounts");
                });

            modelBuilder.Entity("Model.Accounts.PhysicalPersonCredit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(9,3)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("PhysicalPersonCredits");
                });

            modelBuilder.Entity("Model.Accounts.PhysicalPersonDeposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(9,3)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("PhysicalPersonDeposits");
                });

            modelBuilder.Entity("Model.Clients.LegalPersonClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LegalPersonClients");
                });

            modelBuilder.Entity("Model.Clients.PhysicalPersonClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhysicalPersonClients");
                });

            modelBuilder.Entity("Model.OperationsArchive.LegalPersonAccountArchive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("LegalPersonAccountId")
                        .HasColumnType("int");

                    b.Property<byte>("Operation")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("LegalPersonAccountArchives");
                });

            modelBuilder.Entity("Model.OperationsArchive.LegalPersonCreditArchive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("LegalPersonCreditId")
                        .HasColumnType("int");

                    b.Property<byte>("Operation")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("LegalPersonCreditArchives");
                });

            modelBuilder.Entity("Model.OperationsArchive.LegalPersonDepositArchive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("LegalPersonDepositId")
                        .HasColumnType("int");

                    b.Property<byte>("Operation")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("LegalPersonDepositArchives");
                });

            modelBuilder.Entity("Model.OperationsArchive.PhysicalPersonAccountArchive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<byte>("Operation")
                        .HasColumnType("tinyint");

                    b.Property<int>("PhysicalPersonAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PhysicalPersonAccountArchives");
                });

            modelBuilder.Entity("Model.OperationsArchive.PhysicalPersonCreditArchive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<byte>("Operation")
                        .HasColumnType("tinyint");

                    b.Property<int>("PhysicalPersonCreditId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PhysicalPersonCreditArchive");
                });

            modelBuilder.Entity("Model.OperationsArchive.PhysicalPersonDepositArchive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<byte>("Operation")
                        .HasColumnType("tinyint");

                    b.Property<int>("PhysicalPersonDepositId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PhysicalPersonDepositArchives");
                });

            modelBuilder.Entity("Model.Accounts.LegalPersonAccount", b =>
                {
                    b.HasOne("Model.Clients.LegalPersonClient", "Client")
                        .WithMany("Accounts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Model.Accounts.LegalPersonCredit", b =>
                {
                    b.HasOne("Model.Clients.LegalPersonClient", "Client")
                        .WithMany("Credits")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Model.Accounts.LegalPersonDeposit", b =>
                {
                    b.HasOne("Model.Clients.LegalPersonClient", "Client")
                        .WithMany("Deposits")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Model.Accounts.PhysicalPersonAccount", b =>
                {
                    b.HasOne("Model.Clients.PhysicalPersonClient", "Client")
                        .WithMany("Accounts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Model.Accounts.PhysicalPersonCredit", b =>
                {
                    b.HasOne("Model.Clients.PhysicalPersonClient", "Client")
                        .WithMany("Credits")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Model.Accounts.PhysicalPersonDeposit", b =>
                {
                    b.HasOne("Model.Clients.PhysicalPersonClient", "Client")
                        .WithMany("Deposits")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Model.Clients.LegalPersonClient", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Credits");

                    b.Navigation("Deposits");
                });

            modelBuilder.Entity("Model.Clients.PhysicalPersonClient", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Credits");

                    b.Navigation("Deposits");
                });
#pragma warning restore 612, 618
        }
    }
}
