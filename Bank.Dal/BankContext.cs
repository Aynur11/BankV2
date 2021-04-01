using Bank.Dal.Accounts;
using Bank.Dal.Clients;
using Bank.Dal.OperationsArchive;
using Microsoft.EntityFrameworkCore;

namespace Bank.Dal
{
    /// <summary>
    /// Контекст для работы с таблицами БД банковской системы.
    /// </summary>
    public class BankContext : DbContext
    {
        // Таблицы с клиентами..
        public DbSet<LegalPersonClient> LegalPersonClients { get; set; }
        public DbSet<PhysicalPersonClient> PhysicalPersonClients { get; set; }

        // Таблицы со счетами юр. лиц.
        public DbSet<LegalPersonAccount> LegalPersonAccounts { get; set; }
        public DbSet<LegalPersonCredit> LegalPersonCredits { get; set; }
        public DbSet<LegalPersonDeposit> LegalPersonDeposits { get; set; }

        // Таблицы со счетами физ. лиц.
        public DbSet<PhysicalPersonAccount> PhysicalPersonAccounts { get; set; }
        public DbSet<PhysicalPersonCredit> PhysicalPersonCredits { get; set; }
        public DbSet<PhysicalPersonDeposit> PhysicalPersonDeposits { get; set; }


        // Таблицы с архивами историй операций для юр. лиц.
        public DbSet<LegalPersonAccountArchive> LegalPersonAccountArchives { get; set; }
        public DbSet<LegalPersonCreditArchive> LegalPersonCreditArchives { get; set; }
        public DbSet<LegalPersonDepositArchive> LegalPersonDepositArchives { get; set; }

        // Таблицы с архивами историй операций для физ. лиц.
        public DbSet<PhysicalPersonAccountArchive> PhysicalPersonAccountArchives { get; set; }
        public DbSet<PhysicalPersonCreditArchive> PhysicalPersonCreditArchive { get; set; }
        public DbSet<PhysicalPersonDepositArchive> PhysicalPersonDepositArchives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=BankEntities;Integrated Security=True;Pooling=False");
        }
    }
}
