using System.Drawing;

namespace Bank.Dal.Accounts.PhysicalPersonCreditStates
{
    public class IssuedState : State
    {
        public override Color IssueCredit(PhysicalPersonCredit credit)
        {
            using (var repo = new PhysicalPersonClientRepository())
            {
                repo.AddCredit(credit);
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
