using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Accounts;

namespace Controller
{
    interface IRepository<T> : IDisposable
        where T : class
    {
        List<T> GetClients();
        void AddAccount(decimal amount, int clientId, decimal rate = 0);
    }
}