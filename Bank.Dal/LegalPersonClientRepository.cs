using Bank.Dal.Accounts;
using Bank.Dal.Clients;
using Bank.Dal.OperationsArchive;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank.Dal
{
    public class LegalPersonClientRepository : IRepository<LegalPersonClient, LegalPersonCredit, LegalPersonDeposit,
        LegalPersonAccount, LegalPersonAccountArchive, LegalPersonCreditArchive>
    {
        private bool disposed;
        private readonly BankContext context;

        public LegalPersonClientRepository()
        {
            context = new BankContext();
        }

        public List<LegalPersonCreditArchive> GetCreditHistory(int accountId)
        {
            return context.LegalPersonCreditArchives.Where(a => a.LegalPersonCreditId == accountId).ToList();
        }

        public List<LegalPersonAccountArchive> GetAccountHistory(int accountId)
        {
            return context.LegalPersonAccountArchives.Where(a => a.LegalPersonAccountId == accountId).ToList();
        }

        public List<LegalPersonClient> GetClients()
        {
            return context.LegalPersonClients.ToList();
        }

        public List<LegalPersonAccount> GetAllClientAccounts(int clientId)
        {
            return context.LegalPersonAccounts.Where(a => a.ClientId == clientId).ToList();
        }

        public List<LegalPersonDeposit> GetAllClientDeposits(int clientId)
        {
            return context.LegalPersonDeposits.Where(a => a.ClientId == clientId).ToList();
        }
        public List<LegalPersonCredit> GetAllClientCredits(int clientId)
        {
            return context.LegalPersonCredits.Where(a => a.ClientId == clientId).ToList();
        }

        public void AddAccount(int clientId, Currency currency, decimal amount, decimal rate = 0)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var account = new LegalPersonAccount(clientId, currency, amount, rate);
                context.LegalPersonAccounts.Add(account);
                context.SaveChanges();
                context.LegalPersonAccountArchives.Add(new LegalPersonAccountArchive(amount, Operation.AddAccount,
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
                var credit = new LegalPersonCredit(clientId, currency, amount, period, rate);
                context.LegalPersonCredits.Add(credit);
                context.SaveChanges();
                context.LegalPersonCreditArchives.Add(new LegalPersonCreditArchive(amount, Operation.AddCredit,
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
                var deposit = new LegalPersonDeposit(clientId, currency, amount, period, withCapitalization, rate);
                context.LegalPersonDeposits.Add(deposit);
                context.SaveChanges();
                context.LegalPersonDepositArchives.Add(new LegalPersonDepositArchive(amount, Operation.AddDeposit, deposit.Id));
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception($"Произошла ошибка при добавлении счета: {e.Message}");
            }
        }

        public void AddClient(LegalPersonClient client)
        {
            context.LegalPersonClients.Add(client);
        }

        public void RemoveClient(LegalPersonClient client)
        {
            context.LegalPersonClients.Remove(client);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(LegalPersonClient client)
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
