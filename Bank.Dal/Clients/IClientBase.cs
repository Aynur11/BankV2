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
        /// <summary>
        /// Id клиента.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Отображаемое имя клиента.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Тип клиента.
        /// </summary>
        ClientType Type { get; set; }
    }
}
