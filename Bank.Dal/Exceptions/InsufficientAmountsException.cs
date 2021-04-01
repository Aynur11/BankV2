using System;

namespace Bank.Dal.Exceptions
{
    /// <summary>
    /// Исключение генерируемое при недостаточном балансе на счету.
    /// </summary>
    public class InsufficientAmountsException : Exception
    {
        public decimal Amount;
        public InsufficientAmountsException(decimal amount, string message) : base(message)
        {
            Amount = amount;
        }
    }
}
