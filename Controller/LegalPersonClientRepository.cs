using System;
using Model;
using Model.Clients;
using System.Collections.Generic;
using System.Linq;
using Model.Accounts;

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
            //using (BankContext context = new BankContext())
            //{
                return context.LegalPersonClients.ToList();
            //}
        }

        public void AddAccount(decimal amount, int clientId, decimal rate = 0)
        {
            //using (BankContext context = new BankContext())
            //{
                context.LegalPersonAccounts.Add(new LegalPersonAccount(clientId, amount, rate));
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
