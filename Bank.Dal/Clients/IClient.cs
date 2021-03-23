using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Dal.Accounts;

namespace Bank.Dal.Clients
{
    public interface IClient<TAccount> : IClient
    where TAccount: class, IAccount
    {
        List<TAccount> Accounts { get; set; }
    }
}
