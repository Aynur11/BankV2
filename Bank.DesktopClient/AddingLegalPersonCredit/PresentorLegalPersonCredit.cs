using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingLegalPersonCredit
{
    public class PresentorLegalPersonCredit
    {
        private IModelLegalPersonCredit model;

        public PresentorLegalPersonCredit(IViewLegalPersonCredit view, IAccount account, int clientId)
        {
            model = new ModelLegalPersonCredit(account, clientId, view);
        }

        public IAccount GetAccount => model.GetAccount;
    }
}
