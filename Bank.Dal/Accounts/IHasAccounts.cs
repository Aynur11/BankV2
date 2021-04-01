using System.Collections.Generic;

namespace Bank.Dal.Accounts
{
    public interface IHasAccounts
    {
        /// <summary>
        /// Поулчить все счета.
        /// </summary>
        /// <returns>Все счета клиента.</returns>
        List<IAccount> GetAccounts();
    }
}
