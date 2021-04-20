using System.Drawing;

namespace Bank.Dal.Accounts.PhysicalPersonCreditStates
{
    public class IssuedState : State
    {
        public override Color SetColor()
        {
            return Color.Green;
        }

        public override void IssueCredit(int clientId, Currency currency, decimal amount, int period, decimal rate)
        {
            using (var repo = new PhysicalPersonClientRepository())
            {
                repo.AddCredit(clientId, currency, amount, period, rate);
            }
        }

        public override void CloseCredit(IAccount account)
        {

        }
    }
}
