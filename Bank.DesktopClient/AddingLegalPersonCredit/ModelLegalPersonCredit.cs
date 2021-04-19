using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingLegalPersonCredit
{
    public class ModelLegalPersonCredit : IModelLegalPersonCredit
    {
        public ModelLegalPersonCredit(IAccount account, int clientId, IViewLegalPersonCredit view)
        {
            GetAccount = new LegalPersonCredit(clientId, view.Currency, view.Amount, view.Period);
        }

        public IAccount GetAccount { get; }
    }
}
