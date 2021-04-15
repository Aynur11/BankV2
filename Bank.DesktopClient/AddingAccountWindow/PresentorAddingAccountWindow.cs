using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingAccountWindow
{
    public class PresentorAddingAccountWindow
    {
        private IModelAddingAnyAccountWindow model;

        public PresentorAddingAccountWindow(IViewAddingAnyAccountWindow view, IAccount account, int clientId)
        {
            model = new ModelAddingAnyAccountWindow(account, clientId, view);
        }

        public IAccount GetAccount => model.GetAccount;
    }
}
