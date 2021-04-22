namespace Bank.Dal.Accounts
{
    public interface IAccount
    {
        /// <summary>
        /// Идентификатор счета.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Идентификатор клиента.
        /// </summary>
        int ClientId { get; set; }

        /// <summary>
        /// Сумма не счету.
        /// </summary>
        decimal Amount { get; set; }

        /// <summary>
        /// Привязка счета к валюте.
        /// </summary>
        Currency Currency { get; set; }

        /// <summary>
        /// Ставка.
        /// </summary>
        decimal Rate { get; set; }
    }
}