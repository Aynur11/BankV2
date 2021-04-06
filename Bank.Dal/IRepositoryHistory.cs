using System;
using Bank.Dal.OperationsArchive;
using System.Collections.Generic;

namespace Bank.Dal
{
    public interface IRepositoryHistory : IDisposable
    {
        List<IAccountArchive> GetDepositHistory(int accountId);

        List<IAccountArchive> GetCreditHistory(int accountId);

        List<IAccountArchive> GetAccountHistory(int accountId);
    }
}