using System.ComponentModel.DataAnnotations.Schema;
using Model.Clients;

namespace Model.Accounts
{
    /// <summary>
    /// Описывет депозит юр. лиц.
    /// </summary>
    public class LegalPersonDeposit
    {
        /// <summary>
        /// Конструктор для загрузки данных или для создания нового счета для существующего клиента без навигационного свойства.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="amount">Сумма денег.</param>
        /// <param name="rate">Ставка.</param>
        public LegalPersonDeposit(int clientId, decimal amount, decimal rate = 0)
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
        /// <param name="rate">Ставка.</param>
        public LegalPersonDeposit(int clientId, decimal amount, LegalPersonClient client, decimal rate = 0)
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
