using System;
using Bank.Dal.Accounts;

namespace Bank.Dal.Exceptions
{
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
