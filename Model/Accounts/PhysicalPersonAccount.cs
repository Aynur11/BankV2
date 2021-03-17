﻿using System.ComponentModel.DataAnnotations.Schema;
using Model.Clients;

namespace Model.Accounts
{
    /// <summary>
    /// Описывет обычный счет физ. лиц.
    /// </summary>
    public class PhysicalPersonAccount
    {
        /// <summary>
        /// Конструктор для загрузки данных или для создания нового счета для существующего клиента без навигационного свойства.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="amount">Сумма денег.</param>
        /// <param name="rate">Ставка в процентах.</param>
        public PhysicalPersonAccount(int clientId, decimal amount, decimal rate = 0)
        {
            ClientId = clientId;
            Amount = amount;
            Rate = rate;
        }

        /// <summary>
        /// Конструктор для создания нового счета с новым клиентом с навигационным свойством.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="amount">Сумма денег.</param>
        /// <param name="client">Добавляемый клиент.</param>
        /// <param name="rate">Ставка в процентах.</param>
        public PhysicalPersonAccount(int clientId, decimal amount, PhysicalPersonClient client, decimal rate = 0)
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
        /// Возможная ставка (в процентах).
        /// </summary>
        [Column(TypeName = "decimal(9, 3)")]
        public decimal Rate { get; set; }

        /// <summary>
        /// ID клиента(физ. лицо).
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Клиент (физ. лицо).
        /// </summary>
        [ForeignKey(nameof(ClientId))]
        public PhysicalPersonClient Client { get; set; }
    }
}