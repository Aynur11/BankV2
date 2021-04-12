using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingAccountWindow
{
    public class ModelAddingAnyAccountWindow : IModelAddingAnyAccountWindow
    {
        private IAccount newAccount;
        private int clientId;

        public ModelAddingAnyAccountWindow(IAccount account, int clientId)
        {
            newAccount = account;
            this.clientId = clientId;
        }

        //public decimal Amount { get; private set; }
        //public int Period { get; private set; }
        //public Currency Currency { get; private set; }
        //public bool WithCapitalization { get; private set; }

        public IAccount GetAccount => newAccount;

        public void InitData(decimal amount, int period, Currency currency, bool withCapitalization)
        {
            if (newAccount is PhysicalPersonAccount)
            {
                newAccount = new PhysicalPersonAccount(clientId, currency, amount);
            }

            if (newAccount is LegalPersonAccount)
            {
                newAccount = new LegalPersonAccount(clientId, currency, amount);
            }

            if (newAccount is PhysicalPersonCredit)
            {
                newAccount = new PhysicalPersonCredit(clientId, currency, amount, period);
            }

            if (newAccount is PhysicalPersonCredit)
            {
                newAccount = new PhysicalPersonCredit(clientId, currency, amount, period);
            }

            if (newAccount is PhysicalPersonDeposit)
            {
                newAccount = new PhysicalPersonDeposit(clientId, currency, amount, period, withCapitalization);
            }

            if (newAccount is LegalPersonDeposit)
            {
                newAccount = new LegalPersonDeposit(clientId, currency, amount, period, withCapitalization);
            }
        }
    }
}
