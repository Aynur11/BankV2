using Bank.Dal.Accounts;
using Bank.Dal.Clients;
using Bank.Dal.OperationsArchive;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank.Dal
{
    public class PhysicalPersonClientRepository : IRepository<PhysicalPersonClient>, IRepositoryHistory
    {
        private bool disposed;
        private readonly BankContext context;

        public PhysicalPersonClientRepository()
        {
            context = new BankContext();
        }

        public List<IAccountArchive> GetDepositHistory(int accountId)
        {
            return new List<IAccountArchive>(context.PhysicalPersonDepositArchives.Where(a => a.AccountId == accountId).ToList());
        }

        public List<IAccountArchive> GetCreditHistory(int accountId)
        {
            return new List<IAccountArchive>(context.PhysicalPersonCreditArchive.Where(a => a.AccountId == accountId).ToList());
        }

        public List<IAccountArchive> GetAccountHistory(int accountId)
        {
            return new List<IAccountArchive>(context.PhysicalPersonAccountArchives.Where(a => a.AccountId == accountId).ToList());
        }

        public List<PhysicalPersonClient> GetClients()
        {
            return context
                .PhysicalPersonClients
                .Include(a => a.Accounts)
                .Include(c => c.Credits)
                .Include(d => d.Deposits)
                .ToList();
        }

        public void AddAccount(IAccount account)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                PhysicalPersonAccount physicalPersonAccount = (PhysicalPersonAccount) account;
                context.PhysicalPersonAccounts.Add(physicalPersonAccount);
                context.SaveChanges();
                context.PhysicalPersonAccountArchives.Add(new PhysicalPersonAccountArchive(account.Amount, Operation.AddAccount,
                    account.Id));
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception($"Произошла ошибка при добавлении счета: {e.Message}");
            }
        }

        public void AddCredit(int clientId, Currency currency, decimal amount, int period, decimal rate)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var credit = new PhysicalPersonCredit(clientId, currency, amount, period, rate);
                context.PhysicalPersonCredits.Add(credit);
                context.SaveChanges();
                context.PhysicalPersonCreditArchive.Add(new PhysicalPersonCreditArchive(amount, Operation.AddCredit,
                    credit.Id));
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception($"Произошла ошибка при добавлении счета: {e.Message}");
            }
        }

        public void AddDeposit(int clientId, Currency currency, decimal amount, int period, bool withCapitalization, decimal rate)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var deposit = new PhysicalPersonDeposit(clientId, currency, amount, period, withCapitalization, rate);
                context.PhysicalPersonDeposits.Add(deposit);
                context.SaveChanges();
                context.PhysicalPersonDepositArchives.Add(new PhysicalPersonDepositArchive(amount, Operation.AddDeposit, deposit.Id));
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception($"Произошла ошибка при добавлении счета: {e.Message}");
            }
        }

        public void AddClient(PhysicalPersonClient client)
        {
            context.PhysicalPersonClients.Add(client);
        }

        public void RemoveClient(PhysicalPersonClient client)
        {
            context.PhysicalPersonClients.Remove(client);
        }

        public void Save()
        {
            context.SaveChanges();
        }
        
        public void Update(PhysicalPersonClient client)
        {
            context.Update(client);
        }

        /// <summary>
        /// Уничтожение объекта.
        /// </summary>
        /// <param name="disposing">Запущено уничтожение?</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposed = true;
            }
        }

        /// <summary>
        /// Уничтожение объекта.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
