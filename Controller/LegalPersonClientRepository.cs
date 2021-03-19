using Bank.DAL;
using Bank.DAL.Accounts;
using Bank.DAL.Clients;
using Bank.DAL.OperationsArchive;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bank.BLL
{
    public class LegalPersonClientRepository : IRepository<LegalPersonClient>
    {
        private bool disposed;
        private readonly BankContext context;

        public LegalPersonClientRepository()
        {
            context = new BankContext();
        }

        public List<LegalPersonClient> GetClients()
        {
            return context.LegalPersonClients.ToList();
        }

        public Dictionary<int, string> GetClientNamesWithId()
        {
            return context.LegalPersonClients.ToDictionary(i => i.Id, n => n.CompanyName);
        }

        public List<int> GetAllClientAccountsId(int clientId)
        {
            return context.LegalPersonAccounts.Where(a => a.ClientId == clientId).Select(i => i.Id).ToList();
        }

        public void AddAccount(int clientId, Currencies currency, decimal amount, decimal rate = 0)
        {
            context.LegalPersonAccounts.Add(new LegalPersonAccount(clientId, currency, amount, rate));
            context.LegalPersonAccountArchives.Add(new LegalPersonAccountArchive(amount, Operations.AddAccount,
                clientId));
            context.SaveChanges();
        }

        public void AddCredit(int clientId, Currencies currency, decimal amount, int period, decimal rate)
        {
            context.LegalPersonCredits.Add(new LegalPersonCredit(clientId, currency, amount, period, rate));
            context.LegalPersonCreditArchives.Add(new LegalPersonCreditArchive(amount, Operations.AddCredit,
                clientId));
            context.SaveChanges();
        }

        public void AddDeposit(int clientId, Currencies currency, decimal amount, int period, bool withCapitalization, decimal rate)
        {
            context.LegalPersonDeposits.Add(new LegalPersonDeposit(clientId, currency, amount, period, withCapitalization, rate));
            context.LegalPersonDepositArchives.Add(new LegalPersonDepositArchive(amount, Operations.AddDeposit, clientId));
            context.SaveChanges();
        }

        public void TransferMoney(int fromClientId, int fromAccountId, int toClientId, int toAccountId, decimal amount)
        {
            LegalPersonAccount fromClient = context.LegalPersonAccounts.FirstOrDefault(i => i.ClientId == fromClientId && i.Id == fromAccountId);
            PhysicalPersonAccount toClient = context.PhysicalPersonAccounts.FirstOrDefault(i => i.ClientId == toClientId && i.Id == toAccountId);
            LegalPersonAccount toLegalClient = null;

            if (toClient == null)
            {
                toLegalClient = context.LegalPersonAccounts.FirstOrDefault(i => i.ClientId == toClientId && i.Id == toAccountId);
                if (fromClient.Currency != toLegalClient.Currency)
                {
                    Debug.WriteLine("Обнаружена попытка перевода валюты на другой валютный счет.");
                    return;
                }
            }
            else
            {
                if (fromClient.Currency != toClient.Currency)
                {
                    Debug.WriteLine("Обнаружена попытка перевода валюты на другой валютный счет.");
                    return;
                }
            }

            //if (fromClient == null)
            //{
            //    Debug.WriteLine("Отправитель перевода не обнаружен в БД.");
            //}

            //if (toClient == null && toLegalClient == null)
            //{
            //    Debug.WriteLine("Получатель перевода не обнаружен в БД.");
            //}

            if (fromClient.Amount >= amount)
            {
                if (toClient != null)
                {
                    toClient.Amount += amount;
                }
                else
                {
                    toLegalClient.Amount += amount;
                }
                fromClient.Amount -= amount;
            }
            else
            {
                Debug.WriteLine("Для выполнения перевода недостаточно средств.");
            }

            context.SaveChanges();
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
