using System.Drawing;

namespace Bank.Dal.Accounts.PhysicalPersonCreditStates
{
    public abstract class State
    {
        protected Context context;

        public void ChangeContext(Context context)
        {
            this.context = context;
        }

        public abstract Color SetColor();
        public abstract void IssueCredit(int clientId, Currency currency, decimal amount, int period, decimal rate);
        public abstract void CloseCredit(IAccount account);
    }
}