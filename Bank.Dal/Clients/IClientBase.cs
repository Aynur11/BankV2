using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Dal.Accounts;

namespace Bank.Dal.Clients
{
    public interface IClient
    {
        int Id { get; set; }
        string DisplayName { get; }
        ClientType Type { get; set; }
    }
}
