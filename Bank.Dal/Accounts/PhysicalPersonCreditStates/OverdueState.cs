using System.Drawing;

namespace Bank.Dal.Accounts.PhysicalPersonCreditStates
{
    public class OverdueState : State
    {
        public override Color IssueCredit(PhysicalPersonCredit credit)
        {
            return Color.Green;
        }

        public override Color CloseCredit(IAccount account)
        {
            return Color.Gray;
        }
    }
}
