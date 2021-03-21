using System;
using Bank.Dal.Accounts;

namespace Bank.Dal.Exceptions
{
    public class CurrencyMismatchException : Exception
    {
        public Currency Sender;
        public Currency Recipient;
        public CurrencyMismatchException(Currency sender, Currency recipient, string message) : base(message)
        {
            Sender = sender;
            Recipient = recipient;
        }
    }
}
