﻿using System.ComponentModel.DataAnnotations.Schema;
using Model.Clients;

namespace Model.Accounts
{
    /// <summary>
    /// Описывет обычный счет юр. лиц.
    /// </summary>
    public class LegalPersonAccount
    {
        public LegalPersonAccount(int clientId, decimal amount, decimal rate = 0)
        {
            ClientId = clientId;
            Amount = amount;
            Rate = rate;
        }

        public LegalPersonAccount(int clientId, decimal amount, LegalPersonClient client, decimal rate = 0)
        {
            ClientId = clientId;
            Amount = amount;
            Client = client;
            Rate = rate;
        }
        /// <summary>
        /// Идентификатор счета.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Сумма денег на счету.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Возможная ставка.
        /// </summary>
        [Column(TypeName = "decimal(9, 3)")]
        public decimal Rate { get; set; } = 0;

        /// <summary>
        /// Внешний ключ.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Навигационное свойство.
        /// </summary>
        public LegalPersonClient Client { get; set; }
    }
}
