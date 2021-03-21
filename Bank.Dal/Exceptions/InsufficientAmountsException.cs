using System;

namespace Bank.Dal.Exceptions
{
    public class InsufficientAmountsException : Exception
    {
        public decimal Amount;
        public InsufficientAmountsException(decimal amount, string message) : base(message)
        {
            Amount = amount;
        }
    }
}
