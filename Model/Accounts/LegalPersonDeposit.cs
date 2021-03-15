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
        [Column(TypeName = "decimal(9, 3)")]
        public decimal Rate { get; set; }

        /// <summary>
        /// Период действия депозита.
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// С капитализацией?
        /// </summary>
        public bool Capitalization { get; set; }

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
