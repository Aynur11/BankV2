using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.DAL.Accounts;

namespace Bank.BLL.Bank.BLL.Exceptions
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
