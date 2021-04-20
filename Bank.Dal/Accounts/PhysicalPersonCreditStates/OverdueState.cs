using System.Drawing;

namespace Bank.Dal.Accounts.PhysicalPersonCreditStates
{
    public class OverdueState : State
    {
        public override Color SetColor()
        {
            return Color.Red;
        }

        public override void IssueCredit(int clientId, Currency currency, decimal amount, int period, decimal rate)
        {
            throw new System.NotImplementedException();
        }

        public override void CloseCredit(IAccount account)
        {
            throw new System.NotImplementedException();

        }
    }
}
