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
            //using (BankContext context = new BankContext())
            //{
                return context.PhysicalPersonClients.ToList();
            //}
        }

        public void AddAccount(decimal amount, int clientId, decimal rate = 0)
        {
            //using (BankContext context = new BankContext())
            //{
                context.PhysicalPersonAccounts.Add(new PhysicalPersonAccount(clientId, amount, rate));
                context.SaveChanges();
            //}
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
