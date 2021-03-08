using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_18.Models.Accounts
{
    /// <summary>
    /// Счет.
    /// </summary>
    public abstract class AccountBase : IOperations
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double Rate { get; set; } = 0;
        public void AddMoney(int clientId, int accountId, double amount)
        {
            throw new NotImplementedException();
        }

        public void OpenDeposit(int clientId, double amount)
        {
            throw new NotImplementedException();
        }

        public void IssueCredit(int clientId, double amount)
        {
            throw new NotImplementedException();
        }

        public void TransferMoney(int fromClientId, int toClientId, double amount)
        {
            throw new NotImplementedException();
        }
    }
}