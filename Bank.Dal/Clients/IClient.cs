using Bank.Dal.Accounts;
using System.Collections.Generic;

namespace Bank.Dal.Clients
{
    public interface IClient<TAccount> : IClient, IHasAccounts
    where TAccount: class, IAccount
    {
        /// <summary>
        /// Все счета клиента.
        /// </summary>
        List<TAccount> Accounts { get; set; }
    }
}
