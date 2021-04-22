using System.Drawing;

namespace Bank.Dal.Accounts.PhysicalPersonCreditStates
{
    public class OverdueState : State
    {
        public override Color IssueCredit(int clientId, Currency currency, decimal amount, int period, decimal rate)
        {
            return Color.Green;
        }

        public override Color CloseCredit(IAccount account)
        {
            return Color.Gray;
        }
    }
}
