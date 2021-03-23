using System.Collections.Generic;
using Bank.Dal.Accounts;

namespace Bank.Dal.Clients
{
    /// <summary>
    /// Юридическое лицо.
    /// </summary>
    public class LegalPersonClient : IClient<LegalPersonAccount>
    {
        public LegalPersonClient(string companyName, ClientType type)
        {
            CompanyName = companyName;
            Type = type;
        }
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя для отображения в UI.
        /// </summary>
        public string DisplayName => $"{Id}: {CompanyName}";

        /// <summary>
        /// Название компании.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Привилегии для клиента.
        /// </summary>
        public ClientType Type { get; set; }

        /// <summary>
        /// Список счетов клиента.
        /// </summary>
        public List<LegalPersonAccount> Accounts { get; set; }

        /// <summary>
        /// Список кредитов клиента.
        /// </summary>
        public List<LegalPersonCredit> Credits { get; set; }

        /// <summary>
        /// Список депозитов клиента.
        /// </summary>
        public List<LegalPersonDeposit> Deposits { get; set; }
    }
}