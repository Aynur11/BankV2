using Bank.Dal.Accounts;
using Bank.Dal.Clients;
using Bank.Dal.Exceptions;
using Bank.Dal.OperationsArchive;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bank.Dal
{
    public class LegalPersonClientRepository : IRepository<LegalPersonClient>
    {
        private bool disposed;
        private readonly BankContext context;

        public LegalPersonClientRepository()
        {
            context = new BankContext();
        }

        public List<LegalPersonClient> GetClients()
        {
            return context.LegalPersonClients.ToList();
        }

        public List<LegalPersonAccount> GetAllClientAccounts(int clientId)
        {
            return context.LegalPersonAccounts.Where(a => a.ClientId == clientId).ToList();
        }

        public void AddAccount(int clientId, Currency currency, decimal amount, decimal rate = 0)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.LegalPersonAccounts.Add(new LegalPersonAccount(clientId, currency, amount, rate));
                context.LegalPersonAccountArchives.Add(new LegalPersonAccountArchive(amount, Operation.AddAccount,
                    clientId));
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw  new Exception($"Произошла ошибка при добавлении счета: {e.Message}");
            }
        }

        public void AddCredit(int clientId, Currency currency, decimal amount, int period, decimal rate)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.LegalPersonCredits.Add(new LegalPersonCredit(clientId, currency, amount, period, rate));
                context.LegalPersonCreditArchives.Add(new LegalPersonCreditArchive(amount, Operation.AddCredit,
                    clientId));
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
                context.LegalPersonDeposits.Add(new LegalPersonDeposit(clientId, currency, amount, period, withCapitalization, rate));
                context.LegalPersonDepositArchives.Add(new LegalPersonDepositArchive(amount, Operation.AddDeposit, clientId));
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

        public void Save()
        {
            context.SaveChanges();
        }
        
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
