using Bank.Bll;
using Bank.Dal.Accounts;
using Bank.Dal.Clients;
using Bank.Dal.Exceptions;
using NUnit.Framework;
using System;

namespace Tests
{
    public class AccountManagerTests
    {
        [Test]
        public void TransferMoneyValidResultCheck()
        {
            var accountManager = new AccountManager();
            var client = new PhysicalPersonClient("", "", "", DateTime.Now, ClientType.Usual);
            IAccount accountFrom = new PhysicalPersonAccount(12, Currency.Rub, 5000, client);
            accountFrom.Id = 1;

            decimal accountToAmount = 1000;
            IAccount accountTo = new PhysicalPersonAccount(24, Currency.Rub, accountToAmount, client);
            accountTo.Id = 2;
            decimal amountToTransfer = 500;
            accountManager.TransferMoney(accountFrom, accountTo, amountToTransfer);
            Assert.AreEqual(accountToAmount + amountToTransfer, accountTo.Amount, "Ошибка при обновлении суммы на счете получателя.");
        }

        [Test]
        public void TransferMoneyHimselfTransferException()
        {
            var accountManager = new AccountManager();
            var client = new PhysicalPersonClient("", "", "", DateTime.Now, ClientType.Usual);
            IAccount accountFrom = new PhysicalPersonAccount(12, Currency.Rub, 500, client);
            accountFrom.Id = 1;

            decimal amountToTransfer = 500;
            Assert.Throws(typeof(HimselfTransferException),
                () => { accountManager.TransferMoney(accountFrom, accountFrom, amountToTransfer);});
        }

        [Test]
        public void TransferMoneyInsufficientAmountsException()
        {
            var accountManager = new AccountManager();
            var client = new PhysicalPersonClient("", "", "", DateTime.Now, ClientType.Usual);
            IAccount accountFrom = new PhysicalPersonAccount(12, Currency.Rub, 5000, client);
            accountFrom.Id = 1;

            decimal accountToAmount = 1000;
            IAccount accountTo = new PhysicalPersonAccount(24, Currency.Rub, accountToAmount, client);
            accountTo.Id = 2;
            decimal amountToTransfer = 5001;
            Assert.Throws(typeof(InsufficientAmountsException),
                () => { accountManager.TransferMoney(accountFrom, accountTo, amountToTransfer); });
        }

        [Test]
        public void TransferMoneyCurrencyMismatchException()
        {
            var accountManager = new AccountManager();
            var client = new PhysicalPersonClient("", "", "", DateTime.Now, ClientType.Usual);
            IAccount accountFrom = new PhysicalPersonAccount(12, Currency.Usd, 5000, client);
            accountFrom.Id = 1;

            decimal accountToAmount = 1000;
            IAccount accountTo = new PhysicalPersonAccount(24, Currency.Rub, accountToAmount, client);
            accountTo.Id = 2;
            decimal amountToTransfer = 500;
            Assert.Throws(typeof(CurrencyMismatchException),
                () => { accountManager.TransferMoney(accountFrom, accountTo, amountToTransfer); });
        }
    }
}