using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BLL.Bank.BLL.Exceptions
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
