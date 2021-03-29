using System.Collections.Generic;

namespace Bank.Dal.Accounts
{
    public interface IHasAccounts
    {
        List<IAccount> GetAccounts();
    }
}
