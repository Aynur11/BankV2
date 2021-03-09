using Model.Clients;

namespace Model.Accounts
{
    /// <summary>
    /// Описывет депозит физ. лиц.
    /// </summary>
    public class PhysicalPersonDeposit
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
        public PhysicalPersonClient Client { get; set; }
    }
}