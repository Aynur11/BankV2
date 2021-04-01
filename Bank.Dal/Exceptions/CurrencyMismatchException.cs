using System;
using Bank.Dal.Accounts;

namespace Bank.Dal.Exceptions
{
    /// <summary>
    /// Исключение генерируемое при не соответствии валют со стороны отправителя или принимателя.
    /// </summary>
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
