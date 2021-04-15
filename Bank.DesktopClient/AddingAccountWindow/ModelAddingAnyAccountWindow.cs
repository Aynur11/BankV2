using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingAccountWindow
{
    public class ModelAddingAnyAccountWindow : IModelAddingAnyAccountWindow
    {
        private readonly IAccount newAccount;

        public ModelAddingAnyAccountWindow(IAccount account, int clientId, IViewAddingAnyAccountWindow view)
        {
            newAccount = account;

            if (newAccount is PhysicalPersonAccount)
            {
                newAccount = new PhysicalPersonAccount(clientId, view.Currency, view.Amount);
            }

            if (newAccount is LegalPersonAccount)
            {
                newAccount = new LegalPersonAccount(clientId, view.Currency, view.Amount);
            }

            if (newAccount is PhysicalPersonCredit)
            {
                newAccount = new PhysicalPersonCredit(clientId, view.Currency, view.Amount, view.Period);
            }

            if (newAccount is PhysicalPersonCredit)
            {
                newAccount = new PhysicalPersonCredit(clientId, view.Currency, view.Amount, view.Period);
            }

            if (newAccount is PhysicalPersonDeposit)
            {
                newAccount = new PhysicalPersonDeposit(clientId, view.Currency, view.Amount, view.Period, view.WithCapitalization);
            }

            if (newAccount is LegalPersonDeposit)
            {
                newAccount = new LegalPersonDeposit(clientId, view.Currency, view.Amount, view.Period, view.WithCapitalization);
            }
        }

        public IAccount GetAccount => newAccount;
    }
}
