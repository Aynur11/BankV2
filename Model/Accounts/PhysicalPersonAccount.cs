using Model.Clients;

namespace Model.Accounts
{
    /// <summary>
    /// Описывет обычный счет физ. лиц.
    /// </summary>
    public class PhysicalPersonAccount
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
        /// Возможная ставка.
        /// </summary>
        public decimal Rate { get; set; } = 0;

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
