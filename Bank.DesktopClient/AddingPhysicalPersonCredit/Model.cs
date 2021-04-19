using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingPhysicalPersonCredit
{
    public class Model : IModel
    {
        public Model(IAccount account, int clientId, IView view)
        {
            GetAccount = new PhysicalPersonCredit(clientId, view.Currency, view.Amount, view.Period);
        }

        public IAccount GetAccount { get; }
    }
}
