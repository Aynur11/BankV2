using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Dal.Accounts;
using Bank.DesktopClient.AddingCredit;

namespace Bank.DesktopClient.AddingCredit
{
    public class Presentor
    {
        private IModel model;

        public Presentor(IView view, IAccount account, int clientId)
        {
            model = new Model(account, clientId, view);
        }

        public IAccount GetAccount => model.GetAccount;
    }
}
