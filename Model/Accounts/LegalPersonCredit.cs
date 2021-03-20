using Bank.DAL.Clients;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.DAL.Accounts
{
    /// <summary>
    /// Описывает кредит юр. лиц.
    /// </summary>
    public class LegalPersonCredit
    {
        /// <summary>
        /// Конструктор для загрузки данных или для создания нового счета для существующего клиента без навигационного свойства.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="currency">Валюта.</param>
        /// <param name="amount">Сумма денег.</param>
        /// <param name="period">Период действия кредита в месяцах.</param>
        /// <param name="rate">Ставка в процентах.</param>
        public LegalPersonCredit(int clientId, Currency currency, decimal amount, int period, decimal rate = 0)
        {
            ClientId = clientId;
            Currency = currency;
            Amount = amount;
            Period = period;
            Rate = rate;
        }

        /// <summary>
        /// Конструктор для создания нового счета с новым клиентом с навигационным свойством.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="currency">Валюта.</param>
        /// <param name="amount">Сумма денег.</param>
        /// <param name="period">Период действия кредита в месяцах.</param>
        /// <param name="client">Добавляемый клиент.</param>
        /// <param name="rate">Ставка в процентах.</param>
        public LegalPersonCredit(int clientId, Currency currency, decimal amount, int period, LegalPersonClient client, decimal rate = 0)
        {
            ClientId = clientId;
            Currency = currency;
            Amount = amount;
            Period = period;
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
        /// Период действия кредита (в месяцах).
        /// </summary>
        public int Period { get; set; }

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
