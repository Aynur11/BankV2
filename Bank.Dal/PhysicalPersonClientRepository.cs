using Bank.Dal.Accounts;
using Bank.Dal.Clients;
using Bank.Dal.OperationsArchive;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank.Dal
{
    public class PhysicalPersonClientRepository : IRepository<PhysicalPersonClient>
    {
        private bool disposed;
        private readonly BankContext context;

        public PhysicalPersonClientRepository()
        {
            context = new BankContext();
        }
        public List<PhysicalPersonClient> GetClients()
        {
            return context.PhysicalPersonClients.ToList();
        }

        public Dictionary<int, string> GetClientNamesWithId()
        {
            return context.PhysicalPersonClients.ToDictionary(i => i.Id, n => string.Join(' ', n.FirstName, n.MiddleName));
        }

        public List<int> GetAllClientAccountsId(int clientId)
        {
            return context.PhysicalPersonAccounts.Where(a=>a.ClientId == clientId).Select(i => i.Id).ToList();
        }

        public void AddAccount(int clientId, Currency currency, decimal amount, decimal rate = 0)
        {
            context.PhysicalPersonAccounts.Add(new PhysicalPersonAccount(clientId, currency, amount, rate));
            context.PhysicalPersonAccountArchives.Add(new PhysicalPersonAccountArchive(amount, Operation.AddAccount,
                clientId));
            context.SaveChanges();
        }

        public void AddCredit(int clientId, Currency currency, decimal amount, int period, decimal rate)
        {
            context.PhysicalPersonCredits.Add(new PhysicalPersonCredit(clientId, currency, amount, period, rate));
            context.PhysicalPersonCreditArchive.Add(new PhysicalPersonCreditArchive(amount, Operation.AddCredit,
                clientId));
            context.SaveChanges();
        }

        public void AddDeposit(int clientId, Currency currency, decimal amount, int period, bool withCapitalization, decimal rate)
        {
            context.PhysicalPersonDeposits.Add(new PhysicalPersonDeposit(clientId, currency, amount, period, withCapitalization, rate));
            context.PhysicalPersonDepositArchives.Add(new PhysicalPersonDepositArchive(amount, Operation.AddDeposit,
                clientId));
            context.SaveChanges();
        }

        //public void TransferMoney(int fromClientId, int fromAccountId, int toClientId, int toAccountId, decimal amount)
        //{
        //    PhysicalPersonAccount fromClient = context.PhysicalPersonAccounts.FirstOrDefault(i => i.ClientId == fromClientId && i.Id == fromAccountId);
        //    PhysicalPersonAccount toClient = context.PhysicalPersonAccounts.FirstOrDefault(i => i.ClientId == toClientId && i.Id == toAccountId);
        //    LegalPersonAccount toLegalClient = null;

        //    if (toClient == null)
        //    {
        //        toLegalClient = context.LegalPersonAccounts.FirstOrDefault(i => i.ClientId == toClientId && i.Id == toAccountId);
        //        if (fromClient.Currency != toLegalClient.Currency)
        //        {
        //            throw new CurrencyMismatchException(fromClient.Currency, toLegalClient.Currency,
        //                "Обнаружена попытка перевода валюты на другой валютный счет.");
        //        }
        //    }
        //    else
        //    {
        //        if (fromClient.Currency != toClient.Currency)
        //        {
        //            throw new CurrencyMismatchException(fromClient.Currency, toClient.Currency,
        //                "Обнаружена попытка перевода валюты на другой валютный счет.");
        //        }
        //    }

        //    //if (fromClient == null )
        //    //{
        //    //    Debug.WriteLine("Отправитель перевода не обнаружен в БД.");
        //    //}

        //    //if (toClient == null && toLegalClient == null)
        //    //{
        //    //    Debug.WriteLine("Получатель перевода не обнаружен в БД.");
        //    //}

        //    if (fromClient.Amount >= amount)
        //    {
        //        if (toClient != null)
        //        {
        //            toClient.Amount += amount;
        //        }
        //        else
        //        {
        //            toLegalClient.Amount += amount;
        //        }
        //        fromClient.Amount -= amount;
        //    }
        //    else
        //    {
        //        throw new InsufficientAmountsException(fromClient.Amount, "Для выполнения перевода недостаточно средств.");
        //    }

        //    context.SaveChanges();
        //}

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

        /// <summary>
        /// Уничтожение объекта.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
