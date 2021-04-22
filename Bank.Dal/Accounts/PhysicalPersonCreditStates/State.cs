using System.Drawing;

namespace Bank.Dal.Accounts.PhysicalPersonCreditStates
{
    public abstract class State
    {
        protected Context context;

        public void ChangeContext(Context context)
        {
            this.context = context;
        }

        public Color Color { get; set; }
        public abstract Color IssueCredit(PhysicalPersonCredit credit);
        public abstract Color CloseCredit(IAccount account);
    }
}