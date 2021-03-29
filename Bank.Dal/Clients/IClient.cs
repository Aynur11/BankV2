using Bank.Dal.Accounts;
using System.Collections.Generic;

namespace Bank.Dal.Clients
{
    public interface IClient<TAccount> : IClient, IHasAccounts
    where TAccount: class, IAccount
    {
        List<TAccount> Accounts { get; set; }
    }
}
