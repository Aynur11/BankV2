using Model;
using Model.Clients;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class Tables
    {
        private readonly BankContext bankContext;
        public Tables()
        {
            bankContext = new BankContext();
        }

        public List<PhysicalPersonClient> PhysicalPersonClients => bankContext.PhysicalPersonClients.ToList();
        public List<LegalPersonClient> LegalPersonClients => bankContext.LegalPersonClients.ToList();

        public void AddPlAccount()
        {
            //bankContext.PhysicalPersonAccounts.Add(new PhysicalPersonAccount());
        }
    }
}
