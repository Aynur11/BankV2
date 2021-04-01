using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Dal
{
    public class CommonRepository : IDisposable
    {
        private bool disposed;
        private readonly BankContext context;

        public CommonRepository()
        {
            context = new BankContext();
        }

        /// <summary>
        /// Сформировать список всех счетов с указанием их клиентов.
        /// </summary>
        /// <returns>Список счетов с клиентами.</returns>
        public List<string> GetAccountsWithClients()
        {
            var req = context.PhysicalPersonAccounts.Join(context.PhysicalPersonClients,
                account => account.ClientId,
                client => client.Id,
                (account, client) => new
                {
                    account.Id,
                    account.Currency,
                    account.Amount,
                    client.FirstName,
                    client.LastName,
                    client.Credits.Count
                });
            var list = new List<string>();
            list.Add(string.Format("{0,6} {1,10} {2,10} {3,15} {4,15} {5,43}", "Id счета", "Валюта", "Сумма", "Имя", "Отчество", "Количество кредитов данного клиента"));
            foreach (var i in req)
            {
                list.Add($"{i.Id,6} {i.Currency,13} {i.Amount,16} {i.FirstName,15} {i.LastName,15} {i.Count,25}");
            }

            return list;
        }

        /// <summary>
        /// Уничтожение объекта.
        /// </summary>
        /// <param name="disposing">Запущено уничтожение?</param>
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
