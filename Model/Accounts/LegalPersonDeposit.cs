using Model.Clients;

namespace Model.Accounts
{
    /// <summary>
    /// Описывет депозит юр. лиц.
    /// </summary>
    public class LegalPersonDeposit
    {
        /// <summary>
        /// Идентификатор счета.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Сумма денег на счету.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Ставка.
        /// </summary>
        public decimal Rate { get; set; }

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
