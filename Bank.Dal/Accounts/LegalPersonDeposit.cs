using System.ComponentModel.DataAnnotations.Schema;
using Bank.Dal.Clients;

namespace Bank.Dal.Accounts
{
    /// <summary>
    /// Описывет депозит юр. лиц.
    /// </summary>
    public class LegalPersonDeposit : IAccount
    {
        /// <summary>
        /// Конструктор для загрузки данных или для создания нового счета для существующего клиента без навигационного свойства.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="currency">Валюта.</param>
        /// <param name="amount">Сумма денег.</param>
        /// <param name="period">Период действия депозита в месяцах.</param>
        /// <param name="withCapitalization">С капитализацией?</param>
        /// <param name="rate">Ставка в процентах.</param>
        public LegalPersonDeposit(int clientId, Currency currency, decimal amount, int period, bool withCapitalization, decimal rate = 0)
        {
            ClientId = clientId;
            Currency = currency;
            Amount = amount;
            Period = period;
            WithCapitalization = withCapitalization;
            Rate = rate;
        }

        /// <summary>
        /// Конструктор для создания нового счета с новым клиентом с навигационным свойством.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="currency">Валюта.</param>
        /// <param name="amount">Сумма денег.</param>
        /// <param name="period">Период действия депозита в месяцах.</param>
        /// <param name="withCapitalization">С капитализацией?</param>
        /// <param name="client">Добавляемый клиент.</param>
        /// <param name="rate">Ставка в процентах.</param>
        public LegalPersonDeposit(int clientId, Currency currency, decimal amount, int period, bool withCapitalization, LegalPersonClient client, decimal rate = 0)
        {
            ClientId = clientId;
            Currency = currency;
            Amount = amount;
            Period = period;
            WithCapitalization = withCapitalization;
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
        public Currency Currency { get; set; }

        /// <summary>
        /// Сумма денег на счету.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Ставка (в процентах).
        /// </summary>
        [Column(TypeName = "decimal(9, 3)")]
        public decimal Rate { get; set; }

        /// <summary>
        /// Период действия депозита (в месяцах).
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// С капитализацией?
        /// </summary>
        public bool WithCapitalization { get; set; }

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
