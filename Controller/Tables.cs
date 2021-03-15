using Model;
using Model.Clients;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;

namespace Controller
{
    public class Tables
    {
        public List<PhysicalPersonClient> GetPhysicalPersonClients()
        {
            using (BankContext context = new BankContext())
            {
                return context.PhysicalPersonClients.ToList();
            }
        }

        public List<LegalPersonClient> GetLegalPersonClients()
        {
            using (BankContext context = new BankContext())
            {
                return context.LegalPersonClients.ToList();
            }
        }

        public void AddPhysicalPersonAccount(decimal amount, int clientId, decimal rate = 0)
        {
            using (BankContext context = new BankContext())
            {
                context.PhysicalPersonAccounts.Add(new PhysicalPersonAccount(clientId, amount, rate));
                context.SaveChanges();
            }
        }

        public void AddLegalPersonAccount(decimal amount, int clientId, decimal rate = 0)
        {
            using (BankContext context = new BankContext())
            {
                context.LegalPersonAccounts.Add(new LegalPersonAccount(clientId, amount, rate));
                context.SaveChanges();
            }
        }
    }
}
