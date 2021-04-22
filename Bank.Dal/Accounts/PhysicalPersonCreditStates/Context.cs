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

        public Color IssueCredit(PhysicalPersonCredit credit)
        {
            return state.IssueCredit(credit);
        }

        public Color CloseCredit(IAccount account)
        {
            return state.CloseCredit(account);
        }
    }
}
