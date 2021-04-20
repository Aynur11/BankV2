using System.Drawing;

namespace Bank.Dal.Accounts.PhysicalPersonCreditStates
{
    public class Context
    {
        private State state;

        public Context(State state)
        {
            ChangeTo(state);
        }

        public void ChangeTo(State state)
        {
            this.state = state;
        }

        public Color SetColor()
        {
            return state.SetColor();
        }

        public void IssueCredit(int clientId, Currency currency, decimal amount, int period, decimal rate)
        {
            state.IssueCredit(clientId, currency, amount, period, rate);
        }

        public void CloseCredit(IAccount account)
        {
            state.CloseCredit(account);
        }
    }
}
