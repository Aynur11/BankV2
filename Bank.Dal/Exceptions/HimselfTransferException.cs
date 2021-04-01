using System;
using Bank.Dal.Accounts;

namespace Bank.Dal.Exceptions
{
    /// <summary>
    /// Исключение при попытке переведо денег на один и тот же счет.
    /// </summary>
    public class HimselfTransferException : Exception
    {
        public IAccount FromAccount;
        public IAccount ToAccount;
        public HimselfTransferException(IAccount fromAccount, IAccount toAccount, string message) : base(message)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
        }
    }
}
