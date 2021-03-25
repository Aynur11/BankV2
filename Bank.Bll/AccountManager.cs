using Bank.Dal;
using Bank.Dal.Accounts;
using Bank.Dal.Exceptions;
using System;

namespace Bank.Bll
{
    public class AccountManager : IDisposable
    {
        private bool disposed;
        private readonly BankContext context;

        public AccountManager()
        {
            context = new BankContext();
        }

        public void TransferMoney(IAccount accountFrom, IAccount accountTo, decimal amount)
        {
            if (accountFrom.Id == accountTo.Id && 
                accountFrom is PhysicalPersonAccount && accountTo is PhysicalPersonAccount || 
                accountFrom is LegalPersonAccount && accountTo is LegalPersonAccount)
            {
                throw new HimselfTransferException(accountFrom, accountTo,"Попытка перевести средства на один и тот же счет.");
            }

            if (accountFrom.Currency != accountTo.Currency)
            {
                throw new CurrencyMismatchException(accountFrom.Currency, accountTo.Currency,
                    "Обнаружена попытка перевода валюты на другой валютный счет.");
            }

            if (accountFrom.Amount < amount)
            {
                throw new InsufficientAmountsException(accountFrom.Amount, "Для выполнения перевода недостаточно средств.");
            }

            accountFrom.Amount -= amount;
            accountTo.Amount += amount;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
