﻿using System.ComponentModel.DataAnnotations.Schema;
using Model.Accounts;
using Model.Clients;

namespace Model.OperationsArchive
{
    /// <summary>
    /// История операций по кредиту для юр. лиц.
    /// </summary>
    public class LegalPersonCreditArchive
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Сумма денег, задействованная при выполнеии операции.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Выполненная операция.
        /// </summary>
        public Operations Operation { get; set; }

        /// <summary>
        /// ID кредита юр. лица.
        /// </summary>
        public int LegalPersonCreditId { get; set; }

        /// <summary>
        /// Кредит юр. лица.
        /// </summary>
        [ForeignKey(nameof(LegalPersonCreditId))]
        public LegalPersonCredit Credit { get; set; }
    }
}
