using Bank.DAL.Clients;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.DAL.Accounts
{
    /// <summary>
    /// Описывет обычный счет юр. лиц.
    /// </summary>
    public class LegalPersonAccount
    {
        /// <summary>
        /// Конструктор для загрузки данных или для создания нового счета для существующего клиента без навигационного свойства.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="currency">Валюта.</param>
        /// <param name="amount">Сумма денег.</param>
        /// <param name="rate">Ставка в процентах.</param>
        public LegalPersonAccount(int clientId, Currencies currency, decimal amount, decimal rate = 0)
        {
            ClientId = clientId;
            Currency = currency;
            Amount = amount;
            Rate = rate;
        }

        /// <summary>
        /// Конструктор для создания нового счета с новым клиентом с навигационным свойством.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="currency">Валюта.</param>
        /// <param name="amount">Сумма денег.</param>
        /// <param name="client">Добавляемый клиент.</param>
        /// <param name="rate">Ставка в процентах.</param>
        public LegalPersonAccount(int clientId, Currencies currency, decimal amount, LegalPersonClient client, decimal rate = 0)
        {
            ClientId = clientId;
            Currency = currency;
            Amount = amount;
            Client = client;
            Rate = rate;
        }

        /// <summary>
        /// Идентификатор счета.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Вид валюты для счета.
        /// </summary>
        public Currencies Currency { get; set; }

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
        /// ID клиента(юр. лицо).
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Клиент (юр. лицо).
        /// </summary>
        [ForeignKey(nameof(ClientId))]
        public LegalPersonClient Client { get; set; }
    }
}
