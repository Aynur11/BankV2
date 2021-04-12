using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Dal.Accounts;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bank.DesktopClient.AddingAccountWindow
{
    public class PresentorAddingAccountWindow
    {
        private IViewAddingAnyAccountWindow view;
        private IModelAddingAnyAccountWindow model;

        public PresentorAddingAccountWindow(IViewAddingAnyAccountWindow view, IAccount account, int clientId)
        {
            this.view = view;
            model = new ModelAddingAnyAccountWindow(account, clientId);
            model.InitData(view.Amount, view.Period, view.Currency, view.WithCapitalization);
        }

        public IAccount GetAccount => model.GetAccount;
    }
}
