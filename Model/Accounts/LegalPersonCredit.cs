using System.ComponentModel.DataAnnotations.Schema;
using Model.Clients;

namespace Model.Accounts
{
    /// <summary>
    /// Описывает кредит юр. лиц.
    /// </summary>
    public class LegalPersonCredit
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
        /// Внешний ключ.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Навигационное свойство.
        /// </summary>
        public LegalPersonClient Client { get; set; }
    }
}
