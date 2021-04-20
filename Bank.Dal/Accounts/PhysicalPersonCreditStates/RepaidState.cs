using System.Drawing;

namespace Bank.Dal.Accounts.PhysicalPersonCreditStates
{
    public class RepaidState : State
    {
        public override Color SetColor()
        {
            return Color.Gray;
        }

        public override void IssueCredit(int clientId, Currency currency, decimal amount, int period, decimal rate)
        {
            throw new System.NotImplementedException();
        }

        public override void CloseCredit(IAccount account)
        {
            PhysicalPersonCredit credit = (PhysicalPersonCredit)account;
            using (var repo = new PhysicalPersonClientRepository())
            {
                credit.HasClosed = true;
                repo.Update(credit.Client);
                repo.Save();
            }
        }
    }
}
