using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Dal.OperationsArchive;

namespace Bank.Dal
{
    public class NullRepository : IRepositoryHistory
    {
        private readonly BankContext context;

        public NullRepository()
        {
            context = new BankContext();
        }


        public List<IAccountArchive> GetDepositHistory(int accountId)
        {
            return new List<IAccountArchive>();
        }

        public List<IAccountArchive> GetCreditHistory(int accountId)
        {
            return new List<IAccountArchive>();
        }

        public List<IAccountArchive> GetAccountHistory(int accountId)
        {
            return  new List<IAccountArchive>();
        }

        /// <summary>
        /// Уничтожение объекта.
        /// </summary>
        /// <param name="disposing">Запущено уничтожение?</param>
        protected virtual void Dispose(bool disposing)
        {
        }

        /// <summary>
        /// Уничтожение объекта.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
