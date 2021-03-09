﻿using System.Collections.Generic;
using Model.Accounts;

namespace Model.Clients
{
    /// <summary>
    /// Юридическое лицо.
    /// </summary>
    public class LegalPersonClient
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название компании.
        /// </summary>
        public string CompanyName { get; set; }

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