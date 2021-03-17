using System;
using Model;
using Model.Accounts;
using Model.Clients;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class PhysicalPersonClientRepository : IRepository<PhysicalPersonClient>
    {
        private bool disposed;
        private readonly BankContext context;

        public PhysicalPersonClientRepository()
        {
            context = new BankContext();
        }
        public List<PhysicalPersonClient> GetClients()
        {
            return context.PhysicalPersonClients.ToList();
        }

        public void AddAccount(int clientId, decimal amount, decimal rate = 0)
        {
            context.PhysicalPersonAccounts.Add(new PhysicalPersonAccount(clientId, amount, rate));
            context.SaveChanges();
        }

        public void AddCredit(int clientId, decimal amount, int period, decimal rate)
        {
            context.PhysicalPersonCredits.Add(new PhysicalPersonCredit(clientId, amount, period, rate));
            context.SaveChanges();
        }

        public void AddDeposit(int clientId, decimal amount, int period, bool withCapitalization, decimal rate)
        {
            context.PhysicalPersonDeposits.Add(new PhysicalPersonDeposit(clientId, amount, period, withCapitalization, rate));
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
