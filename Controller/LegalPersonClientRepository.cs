using System;
using Model;
using Model.Clients;
using System.Collections.Generic;
using System.Linq;
using Model.Accounts;
using Model.OperationsArchive;

namespace Controller
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

        public void AddAccount(int clientId, decimal amount, decimal rate = 0)
        {
            context.LegalPersonAccounts.Add(new LegalPersonAccount(clientId, amount, rate));
            context.LegalPersonAccountArchives.Add(new LegalPersonAccountArchive(amount, Operations.AddAccount,
                clientId));
            context.SaveChanges();
        }

        public void AddCredit(int clientId, decimal amount, int period, decimal rate)
        {
            context.LegalPersonCredits.Add(new LegalPersonCredit(clientId, amount, period, rate));
            context.SaveChanges();
        }

        public void AddDeposit(int clientId, decimal amount, int period, bool withCapitalization, decimal rate)
        {
            context.LegalPersonDeposits.Add(new LegalPersonDeposit(clientId, amount, period, withCapitalization, rate));
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
