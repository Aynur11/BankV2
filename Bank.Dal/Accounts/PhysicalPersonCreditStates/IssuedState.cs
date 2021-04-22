using System.Drawing;

namespace Bank.Dal.Accounts.PhysicalPersonCreditStates
{
    public class IssuedState : State
    {
        public override Color IssueCredit(int clientId, Currency currency, decimal amount, int period, decimal rate)
        {
            using (var repo = new PhysicalPersonClientRepository())
            {
                repo.AddCredit(clientId, currency, amount, period, rate);
            }

            return Color.Green;
        }

        public override Color CloseCredit(IAccount account)
        {
            context.ChangeTo(new RepaidState());
            return Color.Gray;
        }
    }
}
