using Bank.Dal;
using Bank.Dal.Accounts;
using Bank.Dal.Exceptions;
using System;

namespace Bank.Bll
{
    public class AccountManager
    {
        /// <summary>
        /// Перевод денег со счета на счет.
        /// </summary>
        /// <param name="accountFrom">С какого счета переводить.</param>
        /// <param name="accountTo">На какой счет переводить.</param>
        /// <param name="amount">Сумма перевода.</param>
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
    }
}
