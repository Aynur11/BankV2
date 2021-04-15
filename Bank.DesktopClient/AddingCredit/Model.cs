using Bank.Dal.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.DesktopClient.AddingCredit;

namespace Bank.DesktopClient.AddingCredit
{
    public class Model : IModel
    {
        private readonly IAccount account;

        public Model(IAccount account, int clientId, IView view)
        {
            this.account = account;
            if (account is PhysicalPersonCredit)
            {
                this.account = new PhysicalPersonCredit(clientId, view.Currency, view.Amount, view.Period);
            }

            if (account is LegalPersonCredit)
            {
                this.account = new LegalPersonCredit(clientId, view.Currency, view.Amount, view.Period);
            }
        }

        public IAccount GetAccount => account;
    }
}
