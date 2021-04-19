using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingPhysicalPersonCredit
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
