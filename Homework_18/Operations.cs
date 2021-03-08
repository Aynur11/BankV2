using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_18
{
    interface IOperations
    {
        void AddMoney(int clientId, int accountId, double amount);
        void OpenDeposit(int clientId, double amount);
        void IssueCredit(int clientId, double amount);
        void TransferMoney(int fromClientId, int toClientId, double amount);

    }
}