using System.ComponentModel.DataAnnotations.Schema;
using Model.Clients;

namespace Model.Accounts
{
    /// <summary>
    /// Описывет обычный счет физ. лиц.
    /// </summary>
    public class PhysicalPersonAccount
    {
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
        /// Внешний ключ.
        /// </summary>
        public int ClientId { get; set; }

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
        /// Навигационное свойство.
        /// </summary>
        public PhysicalPersonClient Client { get; set; }
    }
}
