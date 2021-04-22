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
            state.ChangeContext(this);
        }

        public Color IssueCredit(int clientId, Currency currency, decimal amount, int period, decimal rate)
        {
            return state.IssueCredit(clientId, currency, amount, period, rate);
        }

        public Color CloseCredit(IAccount account)
        {
            return state.CloseCredit(account);
        }
    }
}
