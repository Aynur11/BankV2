using System.Drawing;

namespace Bank.Dal.Accounts.PhysicalPersonCreditStates
{
    public class RepaidState : State
    {
        public override Color IssueCredit(int clientId, Currency currency, decimal amount, int period, decimal rate)
        {
            context.ChangeTo(new IssuedState());
            return Color.Green;
        }

        public override Color CloseCredit(IAccount account)
        {
            PhysicalPersonCredit credit = (PhysicalPersonCredit)account;
            using (var repo = new PhysicalPersonClientRepository())
            {
                credit.HasClosed = true;
                repo.Update(credit.Client);
                repo.Save();
            }

            return Color.Gray;
        }
    }
}
